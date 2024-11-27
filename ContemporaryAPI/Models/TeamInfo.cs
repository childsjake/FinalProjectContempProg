using System;
using System.ComponentModel.DataAnnotations;

namespace ContemporaryAPI.Models
{
    public class TeamInfo
    {
        // Unique identifier (Primary Key)
        [Key]
        public int Id { get; set; }

        // Full name
        [Required]
        [MaxLength(200)]
        public string FullName { get; set; } = string.Empty;

        // Birthdate
        [Required]
        public DateTime Birthdate { get; set; }

        // College program: CEAS, CECH, ArtsSci, DAAP, etc
        [Required]
        [MaxLength(100)]
        public string CollegeProgram { get; set; } = string.Empty;

        // Freshmen, Sophomore, Junior, Senior
        [Required]
        [MaxLength(50)]
        public string ProgramYear { get; set; } = string.Empty;
    }
}
