using Cinema.Models;

namespace Cinema.DataHelper.Interface
{
    public interface ITicketDataManager
    {
        public int AddTicket(TicketsViewModels ticket);

        public bool InvalidateTicketByRoomID(int roomID, bool state);
    }
}
