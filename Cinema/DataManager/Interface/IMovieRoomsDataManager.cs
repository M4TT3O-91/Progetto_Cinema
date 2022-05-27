using Cinema.Models;

namespace Cinema.DataManager.Interface
{
    public interface IMovieRoomsDataManager
    {
        public IEnumerable<MoviesRoomsViewModels> GetMovieRoomByCinemaID(int cinemaID);


    }
}
