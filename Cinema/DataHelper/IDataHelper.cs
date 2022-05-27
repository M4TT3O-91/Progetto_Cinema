using Cinema.Models;

namespace Cinema.DataHelper
{
    public interface IDataHelper
    {
        public IEnumerable<MoviesRoomsViewModels> GetMovieRoomByCinemaID(int cinemaID);

        public int AddSpectator(SpectatorsViewModels spectator);

        public void AddSpectatorToMovieRoom(int roomID);
        public void ClearMovieRoom(int roomID);

    }
}
