using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SoccerPitch.Models
{
    public class Formation
    {
        // Primary key formation id
        public int FormationId { get; set; }

        // Formation name
        [Required]
        [MaxLength(20, ErrorMessage = "Formation Name Cannot Exceed 20 Characters")]
        public string FormationName { get; set; } = string.Empty;

        // Collection of formation slots
        [ValidateNever]
        public ICollection<FormationSlot> FormationSlots { get; set; } = new List<FormationSlot>();

    }
}
