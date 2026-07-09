using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SoccerPitch.Models
{
    public class Player
    {

        // primary key player id automatically assigned
        public int PlayerId { get; set; }

        // Image for player jersey url
        public string? JerseyImg { get; set; } = null;

        // required field player name 
        [Required]
        [MaxLength(100, ErrorMessage = "Player name cannot exceed 100 characters.")]
        public string PlayerName { get; set; } = string.Empty;

        // required position of player for view
        [Required]
        [MaxLength(50, ErrorMessage = "Position cannot exceed 50 characters.")]
        public string PreferredPosition { get; set; } = string.Empty;

        [ValidateNever]
        // Rating inputed by user so validate never
        public double OverallRating { get; set; } = 0.0;

        // Goals typically incremented by user
        [ValidateNever]
        public int Goals { get; set; } = 0;

        // Assists typically incremented by user
        [ValidateNever]
        [JsonIgnore]
        public int Assists { get; set; } = 0;

       

        // Foregin key team id 
        [Required]
        public int TeamId { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public Team? Team { get; set; }

    }
}
