using Cinema.Models;

namespace Cinema.Support
{
    public static class Helper
    {
        public static decimal CalculateDiscount(DateTime birthDate)
        {
            if (DateTime.Now.Year - birthDate.Year == 5)
                return 50;
            else if (DateTime.Now.Year - birthDate.Year == 70)
                return 10;
            else
                return 0;
        }

        public static TicketsViewModels ApplyDiscount(TicketsViewModels ticket, DateTime birthDate)
        {
            var discount = CalculateDiscount(birthDate);
            ticket.Discount = discount;
            ticket.Price = (ticket.Price * discount) / 100;
            return ticket;
        }

        public static bool IsforbiddenUnder14(DateTime spec)
        {
            if (DateTime.Now.Year - spec.Year < 14)
                return true;
            
            return false;
        }
    }
}
