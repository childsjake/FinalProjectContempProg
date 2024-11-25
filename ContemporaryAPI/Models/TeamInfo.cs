using System.ComponentModel.DataAnnotations;

namespace ContemporaryAPI.Models
{
    public class TeamInfo
    {
        // Unique identifier(Primary Key)
        [Key]
        public int Id { get; set; }

        // Full name
        public string FullName { get; set; } = string.Empty;

        // Birthdate
        public DateTime Birthdate { get; set; }

        // College program: CEAS, CECH, ArtsSci, DAAP, etc
        public string CollegeProgram { get; set; } = string.Empty;

        // Freshmen, Sophmore, Junior, Senior
        public string ProgramYear { get; set; } = string.Empty;
    }
}
