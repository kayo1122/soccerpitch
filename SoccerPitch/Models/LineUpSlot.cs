namespace SoccerPitch.Models;

public class LineUpSlot
{
    int TeamLineUpSlotId { get; set; }
    int TeamId { get; set; }
    Team Team { get; set; }
    int FormationSlotId { get; set; }
    FormationSlot FormationSlot { get; set; }
    int? PlayerId { get; set; }
    Player? Player { get; set; }
}