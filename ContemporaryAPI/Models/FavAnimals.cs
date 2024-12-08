using System.ComponentModel.DataAnnotations;

namespace ContemporaryAPI.Models
{
    public class FavAnimals
    {
        //Unique identifier (Primary Key)
        [Key]
        public int Id { get; set; }

        //Favorite Mammal
        [Required]
        [MaxLength(50)]
        public string Mammal { get; set; } = string.Empty;

        //Favorite Bird
        [Required]
        [MaxLength(50)]
        public string Bird { get; set; } = string.Empty;

        //Favorite Reptile
        [Required]
        [MaxLength(50)]
        public string Reptile { get; set; } = string.Empty;

        //Favorite Amphibian
        [Required]
        [MaxLength(50)]
        public string Amphibian { get; set; } = string.Empty;

        //Favorite Fish
        [Required]
        [MaxLength(50)]
        public string Fish { get; set; } = string.Empty;

        //Favorite Bug
        [Required]
        [MaxLength(50)]
        public string Bug { get; set; } = string.Empty;
    }
}
