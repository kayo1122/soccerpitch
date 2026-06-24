using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SoccerPitch.Models;

public class TeamLineUpSlot
{
    // primary key
    public int TeamLineUpSlotId { get; set; }

    // foreign key
    public int TeamId { get; set; }


    [ValidateNever]
    public Team Team { get; set; }

    // foregin key
    public int FormationSlotId { get; set; }

    [ValidateNever]
    public FormationSlot FormationSlot { get; set; }

    // foregin key
    public int? PlayerId { get; set; }

    [ValidateNever]
    public Player? Player { get; set; }
}