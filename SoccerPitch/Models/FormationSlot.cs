using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SoccerPitch.Models;

public class FormationSlot
{
    // primary key
    public int FormationSlotId { get; set; }

    [Required]
    public string PositionCode { get; set; } = string.Empty;

    // X coordinate of formation slot
    [Required]
    public decimal xPosition  { get; set; }

    // X coordinate of formation slot
    [Required]
    public decimal yPosition { get; set; }

    // Foreign Key
    public int FormationId { get; set; }
    [Required]
    public ICollection<Formation> Formation { get; set; } = new List<Formation>();
}