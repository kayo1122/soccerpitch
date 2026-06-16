using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SoccerPitch1.Models
{
    public class Team
    {
        // Primary key team id automatically assigned
        public int TeamId { get; set; }

        // Image of team url
        public string? TeamImg { get; set; } = null;

        // get team name required field
        [Required]
        [MaxLength(100, ErrorMessage = "Team name cannot exceed 100 characters.")]
        public string TeamName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Formation cannot exceed 50 characters.")]
        public string Formation { get; set; }

        [ValidateNever]
        public string Coach { get; set; } = string.Empty;

        // standing will be automatically generated later on but initially updated by user so validate never
        [ValidateNever]
        public int Standing { get; set; } = 0;

        // foreign key for player need to set to required
        [Required]
        public int UserId { get; set; }
    }
}