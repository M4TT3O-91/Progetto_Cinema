using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class CinemasViewModels
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
