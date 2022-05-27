using Cinema.DataHelper;
using Cinema.Models;

namespace TestCinemaProject
{
    public class SpectatoTests
    {

        private SqlSpectatorManager _sqlSpectatorManager;

        [SetUp]
        public void Setup()
        {
            _sqlSpectatorManager = new SqlSpectatorManager("Server = LAPTOP-0AAVA4N0; Database = CinemaProject; Trusted_Connection = True;");
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
            int spectatorID = _sqlSpectatorManager.AddSpectator(spec);
            bool deleteResult = _sqlSpectatorManager.DeleteSpectator(spectatorID);

            Assert.IsTrue(spectatorID != 0);
            Assert.IsTrue(deleteResult);
        }




    }
}