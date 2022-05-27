using Cinema.Models;

namespace Cinema.DataManager.Interface
{
    public interface IFilmDataManager
    {
        public FilmsViewModels GetFilmByID(int id);
        public int AddNewFilm(FilmsViewModels film);
        public bool DeleteFilmByID(int id);
        public void ClearMovieRoom(int roomID);

    }
}
