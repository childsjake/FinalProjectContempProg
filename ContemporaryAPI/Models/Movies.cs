using System;
using System.ComponentModel.DataAnnotations;

namespace ContemporaryAPI.Models
{
    public class Movies
    {
        // Unique identifier (Primary Key)
        [Key]
        public int Id { get; set; }

        // Movie title
        [Required]
        [MaxLength(200)]
        public string title { get; set; } = string.Empty;

        // Release date
        [Required]
        public DateTime releaseDate { get; set; }

        // Director name
        [Required]
        [MaxLength(100)]
        public string directorName { get; set; } = string.Empty;

        // Genre
        [Required]
        [MaxLength(50)]
        public string genre { get; set; } = string.Empty;
    }
}
