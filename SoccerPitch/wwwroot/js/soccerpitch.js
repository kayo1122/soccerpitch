// Gets the teams array from the global data if none exists use an empty array
const teams = window.teamsData || [];
/* layout data */
/* id - tracks what slot it is
   label - displays what postition it is in an empty slot
   top/left - CSS percentage positions to place the slots visually on the pitch
*/
const formations = {
    "4-3-3": [
        { id: "gk", label: "GK", top: "85%", left: "46%" },
        { id: "lb", label: "LB", top: "65%", left: "15%" },
        { id: "cb1", label: "CB", top: "65%", left: "36%" },
        { id: "cb2", label: "CB", top: "65%", left: "56%" },
        { id: "rb", label: "RB", top: "65%", left: "77%" },
        { id: "cm1", label: "CM", top: "45%", left: "25%" },
        { id: "cm2", label: "CM", top: "45%", left: "46%" },
        { id: "cm3", label: "CM", top: "45%", left: "67%" },
        { id: "lw", label: "LW", top: "20%", left: "18%" },
        { id: "st", label: "ST", top: "18%", left: "46%" },
        { id: "rw", label: "RW", top: "20%", left: "74%" },
    ],
    "4-4-2": [
        { id: "gk", label: "GK", top: "85%", left: "46%" },
        { id: "lb", label: "LB", top: "65%", left: "15%" },
        { id: "cb1", label: "CB", top: "65%", left: "36%" },
        { id: "cb2", label: "CB", top: "65%", left: "56%" },
        { id: "rb", label: "RB", top: "65%", left: "77%" },
        { id: "lm", label: "LM", top: "45%", left: "15%" },
        { id: "cm1", label: "CM", top: "45%", left: "36%" },
        { id: "cm2", label: "CM", top: "45%", left: "56%" },
        { id: "rm", label: "RM", top: "45%", left: "77%" },
        { id: "st1", label: "ST", top: "20%", left: "33%" },
        { id: "st2", label: "ST", top: "20%", left: "59%" },
    ],
    "3-5-2": [
        { id: "gk", label: "GK", top: "85%", left: "46%" },
        { id: "cb1", label: "CB", top: "65%", left: "25%" },
        { id: "cb2", label: "CB", top: "65%", left: "46%" },
        { id: "cb3", label: "CB", top: "65%", left: "67%" },
        { id: "lm", label: "LM", top: "45%", left: "10%" },
        { id: "cm1", label: "CM", top: "45%", left: "28%" },
        { id: "cm2", label: "CM", top: "45%", left: "46%" },
        { id: "cm3", label: "CM", top: "45%", left: "64%" },
        { id: "rm", label: "RM", top: "45%", left: "82%" },
        { id: "st1", label: "ST", top: "20%", left: "33%" },
        { id: "st2", label: "ST", top: "20%", left: "59%" },
    ]
};
/* Tracks the current application state.
   currentFormation - currently selected formation (defaults to 4-3-3)
   currentTeamIndex - index of the selected team tab
   slotAssignments - stores which player is assigned to each position
   draggedPlayer - stores the player currently being dragged during drag-and-drop
*/

let currentFormation = "4-3-3";
let currentTeamIndex = 0;
let slotAssignments = {};
let draggedPlayer = null;
let selectedTeamId = null;


function renderTeamTabs() {
    const tabs = document.getElementById("teamTabs");
    /* if teams is empty show a message */
    if (!teams || teams.length === 0) {
        tabs.innerHTML = '<span style="color:#8fa89a;font-size:0.8rem;">No teams found</span>';
        document.getElementById("playerList").innerHTML =
            '<div class="no-teams">Add teams and players first.</div>';
        return;
    }
    /* Otherwise, create an HTML tab for each team
       The currently selected team receives the "active" class
       Clicking a tab calls selectTeam() with that team's index
    */
    tabs.innerHTML = teams.map((t, i) =>
        `<div class="team-tab ${i === currentTeamIndex ? 'active' : ''}
        "onclick="selectTeam(${i})">${t.TeamName}</div>`
    ).join('');
}
/* Changes the selected team and refreshes the sidebar */
function selectTeam(i) {
    currentTeamIndex = i;
    selectedTeamId = teams[i].TeamId;
    renderTeamTabs();
    renderPlayers();
}
/* renderPlayers draws the sidebar list of players */
/* gets the div where the player cards will be displayed */
function renderPlayers() {
    const list = document.getElementById("playerList");
    if (!teams || teams.length === 0) return;
    /* gets the currently selected team and its list of players */
    const team = teams[currentTeamIndex];
    const players = team.Players || [];
    /*if team is empty display a message*/
    if (players.length === 0) {
        list.innerHTML = '<div class="no-teams">No players in this team.</div>';
        return;
    }
    /* creates a Set containing the IDs of players already placed
   on the field or substitutes bench so they can be greyed out
   and no longer dragged from the player list*/
    const placedIds = new Set([
        ...Object.values(slotAssignments).map(p => p.PlayerId),
        ...Object.values(subAssignments).map(p => p.PlayerId)
    ]);
    /* create the HTML for each player card in the sidebar, including initials,
   name, preferred position, and overall rating */
    list.innerHTML = players.map(p => {
        const initials = p.PlayerName.split(' ').map(n => n[0]).join('').slice(0, 2).toUpperCase();
        const placed = placedIds.has(p.PlayerId);
        return `
                        <div class="player-card ${placed ? 'placed' : ''}"
                             draggable="${!placed}"
                             data-player-id="${p.PlayerId}"
                             ondragstart="onDragStart(event, ${p.PlayerId})"
                             ondragend="onDragEnd(event)">

                             <div class="player-avatar">${initials}</div>
                            <div class="player-info">
                                <div class="name">${p.PlayerName}</div>
                                <div class="pos">${p.PreferredPosition}</div>
                            </div>
                            <div class="player-rating">${p.OverallRating > 0 ? p.OverallRating.toFixed(0) : '—'}</div>
                        </div>`;
    }).join('');
}
/* js for modal buttons */
function openEditTeamModal() {
    const team = teams[currentTeamIndex];

    if (!team) {
        showToast("No team selected.");
        return;
    }

    window.location.href = `/Team/Edit/${team.TeamId}`;
}

function openDeleteTeamModal() {
    const team = teams[currentTeamIndex];
    if (!team) {
        showToast("No team selected.");
        return;
    }
    new bootstrap.Modal(document.getElementById('deleteTeamModal-' + team.TeamId)).show();
}
/* changes formation and clears all player assignments */
function setFormation(f) {
    currentFormation = f;
    slotAssignments = {};
    subAssignments = {};
    renderSlots();
    renderPlayers();
    renderSubs();
}
/*allows team to be edited */
let playerCount = 1;

/*adds new player row in add team button */
function addPlayerRow() {
    let container = document.getElementById("createPlayerRows");
    let playerHTML = `
        <div class="row g-2 mb-2 player-row">
            <div class="col-6">
                <input type="text"
                       class="form-control"
                       name="Players[${playerCount}].PlayerName"
                       placeholder="Player Name" />
            </div>
            <div class="col-6">
                <input type="text"
                       class="form-control"
                       name="Players[${playerCount}].PreferredPosition"
                       placeholder="Position" />
            </div>
        </div>
    `;

    container.insertAdjacentHTML("beforeend", playerHTML);
    playerCount++;

}
function addPlayer(teamId) {

    let container = document.getElementById("newPlayers-" + teamId);
    let index = container.children.length;
    let playerHTML = `
        <div class="row g-2 mb-2 player-row">

            <div class="col-6">
                <input type="text"
                       class="form-control"
                       name="Players[${index}].PlayerName"
                       placeholder="Player Name"
                       maxlength="100"
                       required />
            </div>
            <div class="col-6">
                <input type="text"
                       class="form-control"
                       name="Players[${index}].PreferredPosition"
                       placeholder="Position"
                       maxlength="50"
                       required />
            </div>
            <input type="hidden"
                   name="Players[${index}].TeamId"
                   value="${teamId}" />
            <input type="hidden"
                   name="Players[${index}].OverallRating"
                   value="0" />
            <input type="hidden"
                   name="Players[${index}].Goals"
                   value="0" />
            <input type="hidden"
                   name="Players[${index}].Assists"
                   value="0" />
        </div>
    `;

    container.insertAdjacentHTML("beforeend", playerHTML);
}
/* draws all position slots on the pitch based on selected formation */
function renderSlots() {
    const pitch = document.getElementById("pitch");
    /* remove any existing player slots before drawing new ones */
    pitch.querySelectorAll('.player-slot').forEach(s => s.remove());

    const slots = formations[currentFormation];
    slots.forEach(slot => {
        /* check whether a player has already been assigned to position */
        const assigned = slotAssignments[slot.id];
        const div = document.createElement('div');
        div.className = 'player-slot';
        div.style.top = slot.top;
        div.style.left = slot.left;
        div.dataset.slotId = slot.id;

        div.innerHTML = `
                        <div class="slot-circle ${assigned ? 'filled' : ''}"
                             ondragover="onDragOver(event)"
                             ondragleave="onDragLeave(event)"
                             ondrop="onDrop(event, '${slot.id}')"
                             onclick="${assigned ? `removeFromSlot('${slot.id}')` : ''}">
                            ${assigned
                ? `<span class="player-name-slot">${assigned.PlayerName.split(' ').slice(-1)[0]}</span>
                                   <span style="font-size:0.5rem;color:#2ecc71;">${assigned.PreferredPosition}</span>`
                : slot.label}
                        </div>
                        <div class="slot-label">${slot.label}</div>`;
        /* add the completed slot to pitch */
        pitch.appendChild(div);
    });
}
/* combines players from every team into one array */
function getAllPlayers() {
    return teams.flatMap(t => t.Players || []);
}
/* stores the player being dragged and applies drag styling */
function onDragStart(e, playerId) {
    draggedPlayer = getAllPlayers().find(p => p.PlayerId === playerId);
    e.target.classList.add('dragging');
    e.dataTransfer.effectAllowed = 'move';
}
/* removes drag styling and clears the dragged player */
function onDragEnd(e) {
    e.target.classList.remove('dragging');
    draggedPlayer = null;
}
/* allows player to be dropped onto a slot */
function onDragOver(e) {
    e.preventDefault();
    e.currentTarget.classList.add('drag-over');
}
/* removes the drag over highlight when cursor leaves the slot */
function onDragLeave(e) {
    e.currentTarget.classList.remove('drag-over');
}
/* places selected player into selected position slot*/
function onDrop(e, slotId) {
    e.preventDefault();
    e.currentTarget.classList.remove('drag-over');
    if (!draggedPlayer) return;
    /* remove the player from any existing pitch position */
    for (const [sid, p] of Object.entries(slotAssignments)) {
        if (p.PlayerId === draggedPlayer.PlayerId) delete slotAssignments[sid];
    }
    /* remove player from sub becnh if necessary */
    for (const [i, p] of Object.entries(subAssignments)) {
        if (p.PlayerId === draggedPlayer.PlayerId) delete subAssignments[i];
    }
    /* assign the player to the new positon and refresh the interface */
    slotAssignments[slotId] = draggedPlayer;
    renderSlots();
    renderPlayers();
    renderSubs();
}
/* removes player from selected pitch position */
function removeFromSlot(slotId) {
    delete slotAssignments[slotId];
    renderSlots();
    renderPlayers();
    renderSubs();
}
/* sends current lineup to the server to be saved */
async function saveLineup() {
    /* build an array containing all assigned players */
    const players = Object.entries(slotAssignments).map(([slotId, p]) => ({
        playerId: p.PlayerId,
        playerName: p.PlayerName,
        position: p.PreferredPosition,
        slotId: slotId
    }));
    if (players.length === 0) {
        showToast("Place at least one player first!");
        return;
    }

    const payload = { formation: currentFormation, players };

    try {
        const res = await fetch('/SoccerPitch/SaveLineup', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        });
        const data = await res.json();
        showToast(data.message);
    } catch {
        showToast("Failed to save lineup.");
    }
}
/* displays a temporary notification message for the user */
function showToast(msg) {
    const t = document.getElementById("toast");
    t.textContent = msg;
    t.classList.add("show");
    setTimeout(() => t.classList.remove("show"), 3000);
}
/* maximum number of sub players allowed*/
const MAX_SUBS = 7;
/* stores which players have been assigned to sub slot */
let subAssignments = {};
/* draws the bench and displays assigned players */
function renderSubs() {
    const list = document.getElementById("subsList");
   
    list.innerHTML = Array.from({ length: MAX_SUBS }, (_, i) => {
        const player = subAssignments[i];
        return `
                        <div class="sub-slot ${player ? 'filled' : ''}"
                             ondragover="onSubDragOver(event)"
                             ondragleave="onSubDragLeave(event)"
                             ondrop="onSubDrop(event, ${i})"
                             onclick="${player ? `removeFromSub(${i})` : ''}">
                            <span class="sub-number">${i + 12}</span>
                            ${player
                ? `<div class="player-avatar" style="width:28px;height:28px;font-size:0.65rem;background:#2ecc71;border-radius:50%;display:flex;align-items:center;justify-content:center;font-weight:700;color:#0f1923;">
                                        ${player.PlayerName.split(' ').map(n => n[0]).join('').slice(0, 2).toUpperCase()}
                                   </div>
                                   <div class="player-info">
                                       <div class="name" style="font-size:0.78rem;">${player.PlayerName}</div>
                                       <div class="pos">${player.PreferredPosition}</div>
                                   </div>
                                   <span style="font-size:0.65rem;color:#e74c3c;cursor:pointer;">✕</span>`
                : `<span class="sub-empty-label">Drop player here</span>`
            }
                        </div>`;
    }).join('');
}
/* allows player to be dropped on sub slot */
function onSubDragOver(e) {
    e.preventDefault();
    e.currentTarget.classList.add('drag-over');
}
/* removes highlight from sub spot */
function onSubDragLeave(e) {
    e.currentTarget.classList.remove('drag-over');
}
/* places the dragged player into the selected sub slot */
function onSubDrop(e, index) {
    e.preventDefault();
    e.currentTarget.classList.remove('drag-over');
    if (!draggedPlayer) return;

    // Remove from pitch slots if already placed there
    for (const [sid, p] of Object.entries(slotAssignments)) {
        if (p.PlayerId === draggedPlayer.PlayerId) delete slotAssignments[sid];
    }
    // Remove from other sub slots
    for (const [i, p] of Object.entries(subAssignments)) {
        if (p.PlayerId === draggedPlayer.PlayerId) delete subAssignments[i];
    }

    subAssignments[index] = draggedPlayer;
    renderSlots();
    renderPlayers();
    renderSubs();
}
/* remove player from sub bench */
function removeFromSub(index) {
    delete subAssignments[index];
    renderPlayers();
    renderSubs();
}
/* initializes the page by rendering all interface elements*/
function init() {
    renderTeamTabs();
    renderPlayers();
    renderSlots();
    renderSubs();
}

init();