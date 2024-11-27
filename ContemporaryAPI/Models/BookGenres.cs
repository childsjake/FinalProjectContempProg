using System.ComponentModel.DataAnnotations;

namespace ContemporaryAPI.Models
{
    public class BookGenres
    {
        // Unique identifier (Primary Key)
        [Key]
        public int Id { get; set; }

        // Genre fields with string values representing the genre of a book.
        [Required]
        [MaxLength(200)]
        public string Fantasy { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Scifi { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Romance { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Historical { get; set; } = string.Empty;
    }
}
