using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

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
        public string Name { get; set; }

        // required position of player for view
        [Required]
        [MaxLength(50, ErrorMessage = "Position cannot exceed 50 characters.")]
        public string Position { get; set; }

        // Jersey number typically inputed by user
        [ValidateNever]
        public int JerseyNumber { get; set; } = 0;

        // Goals typically incremented by user
        [ValidateNever]
        public int Goals { get; set; } = 0;

        // Assists typically incremented by user
        [ValidateNever]
        public int Assists { get; set; } = 0;

        // Foregin key team id 
        [Required]
        public int TeamId { get; set; }

    }
}
