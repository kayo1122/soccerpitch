using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoccerPitch.Models
{
    public class Team
    {
        // Primary key team id automatically assigned
        public int TeamId { get; set; }

        // Image of team url
        [DisplayName("Team Image")]
        public string? TeamImg { get; set; } = null;

        // get team name required field
        [Required]
        [MaxLength(100, ErrorMessage = "Team name cannot exceed 100 characters.")]
        [DisplayName("Team Name")]
        public string TeamName { get; set; } = string.Empty;

        // Team will have an ICollection of all its player inputed by user
        [ValidateNever]
        public ICollection<Player> Players { get; set; } = new List<Player>();

        // standing will be automatically generated later on but initially updated by user so validate never
        [ValidateNever]
        public int Standing { get; set; } = 0;

        // foreign key for player need to set to required
        [Required]
        [DisplayName("User")]
        public int UserId { get; set; }
    }
}