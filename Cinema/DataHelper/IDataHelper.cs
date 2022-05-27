using Cinema.Models;

namespace Cinema.DataHelper
{
    public interface IDataHelper
    {
        public IEnumerable<MoviesRoomsViewModels> GetMovieRoomByCinemaID(int cinemaID);

        public int AddSpectator(SpectatorsViewModels spectator);
        public bool DeleteSpectator(int id);

        public int AddNewFilm(FilmsViewModels film);
        public bool DeleteFilmByID(int id);

        public void AddSpectatorToMovieRoom(int roomID);
        public void ClearMovieRoom(int roomID);

    }
}
