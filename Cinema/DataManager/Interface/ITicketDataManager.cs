using Cinema.Models;
namespace Cinema.DataManager.Interface
{
    public interface ITicketDataManager
    {
        public int AddTicket(TicketsViewModels ticket, DateTime birthDate);
        public bool ChangeTicketStateByRoomID(int roomID, bool state);
    }
}
