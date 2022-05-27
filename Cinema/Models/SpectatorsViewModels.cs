using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class SpectatorsViewModels
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime BirthDate { get; set; }
    }
}
