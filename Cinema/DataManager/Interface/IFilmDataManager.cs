using Cinema.Models;

namespace Cinema.DataHelper.Interface
{
    public interface IFilmDataManager
    {
        public IEnumerable<MoviesRoomsViewModels> GetMovieRoomByCinemaID(int cinemaID);

        public int AddNewFilm(FilmsViewModels film);
        public bool DeleteFilmByID(int id);


        public void ClearMovieRoom(int roomID);

    }
}
