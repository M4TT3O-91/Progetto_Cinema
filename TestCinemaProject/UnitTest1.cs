using Cinema.DataHelper;

namespace TestCinemaProject
{
    public class Tests
    {

        private SqlDataHelper _sqlDataHelper;  
        [SetUp]
        public void Setup()
        {
            _sqlDataHelper = new SqlDataHelper("Server = LAPTOP-0AAVA4N0; Database = WebApi; Trusted_Connection = True;");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}