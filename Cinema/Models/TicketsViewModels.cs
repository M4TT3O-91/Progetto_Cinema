using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class TicketsViewModels
    {
        public int ID { get; set; }
        [PositiveNotZero(ErrorMessage ="Ticket price must be positive and not 0")]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        [Required]
        public int SpectatorID { get; set; }
        [Required]
        public int FilmID { get; set; }
        public bool IsValid { get; set; }

    }
}
