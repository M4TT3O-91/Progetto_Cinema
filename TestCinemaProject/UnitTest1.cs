using Cinema.DataHelper;
using Cinema.Models;

namespace TestCinemaProject
{
    public class Tests
    {

        private SqlDataHelper _sqlDataHelper;

        [SetUp]
        public void Setup()
        {
            _sqlDataHelper = new SqlDataHelper("Server = LAPTOP-0AAVA4N0; Database = CinemaProject; Trusted_Connection = True;");
        }

        [Test]
        public void Insert_and_Delete_Spectator()
        {
            SpectatorsViewModels spec = new SpectatorsViewModels
            {
                BirthDate = DateTime.Now,
                Name = "Roberto",
                Surname = "Bruno",
            };
            int spectatorID = _sqlDataHelper.AddSpectator(spec);
            bool deleteResult = _sqlDataHelper.DeleteSpectator(spectatorID);

            Assert.IsTrue(spectatorID != 0);
            Assert.IsTrue(deleteResult);
        }

        [Test]
        public void Get_Movies_passing_Movies_Room_ID()
        {
            bool res = _sqlDataHelper.GetMovieRoomByCinemaID(1).Any();
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

            int filmID = _sqlDataHelper.AddNewFilm(film);
            bool deleteResult = _sqlDataHelper.DeleteFilmByID(filmID);
            Assert.IsTrue(filmID != 0);
            Assert.IsTrue(deleteResult)
        }


    }
}