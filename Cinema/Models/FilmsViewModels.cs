using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class FilmsViewModels
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Producer { get; set; }

        [PositiveNotZero(ErrorMessage = "Duration must be positive number and greater than 0")]
        public decimal Duration { get; set; }
    }
}
