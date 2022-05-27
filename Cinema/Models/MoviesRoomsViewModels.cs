using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class MoviesRoomsViewModels
    {
        public int ID { get; set; }
        
        public int CinemaID { get; set; }

        public int FilmID { get; set; }

        [PositiveNotZero(ErrorMessage ="Max seatings must be a positive number greater than 0")]
        public int MaxSeatings { get; set; }

        [PositiveNumber(ErrorMessage ="Seating must be a positive number")]
        public int Seatings { get; set; }

        public string FilmTitle { get; set; }
    }
}
