using Cinema.DataHelper;
using Cinema.Models;

namespace TestCinemaProject
{
    public class FilmTests
    {

        private SqlFilmHelper _sqlFilmHelper;

        [SetUp]
        public void Setup()
        {
            _sqlFilmHelper = new SqlFilmHelper("Server = LAPTOP-0AAVA4N0; Database = CinemaProject; Trusted_Connection = True;");
        }

        [Test]
        public void Get_Movies_passing_Movies_Room_ID()
        {
            bool res = _sqlFilmHelper.GetMovieRoomByCinemaID(1).Any();
            Assert.IsTrue(res);
        }

        [Test]
        public void Insert_and_delete_New_Film()
        {
            FilmsViewModels film = new FilmsViewModels { 
                Title = "Film",
                Author = "author ",
                Producer = "producer",
                Genre = "Horror",
                Duration = 120,
            };

            int filmID = _sqlFilmHelper.AddNewFilm(film);
            bool deleteResult = _sqlFilmHelper.DeleteFilmByID(filmID);
            Assert.IsTrue(filmID != 0);
            Assert.IsTrue(deleteResult);
        }


    }
}