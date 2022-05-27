using Cinema.Models;
using System.Data.SqlClient;

namespace Cinema.DataHelper
{
    public class SqlDataHelper : IDataHelper
    {
        private readonly string _connectionString;
        public SqlDataHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddSpectator(SpectatorsViewModels spectator)
        {
            var query = @"INSERT INTO Spectators
                                   ([Name]
                                   ,[Surname]
                                   ,[BirthDate])
                             VALUES
                                   (@Name
                                   ,@Surname
                                   ,@BirthDate);SELECT @@IDENTITY AS 'Identity';";
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Name", spectator.Name);
                command.Parameters.AddWithValue("Surname", spectator.Surname);
                command.Parameters.AddWithValue("BirthDate", spectator.BirthDate);

                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
        }


        public void AddSpectatorToMovieRoom(int roomID)
        {
            throw new NotImplementedException();
        }

        public void ClearMovieRoom(int roomID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MoviesRoomsViewModels> GetMovieRoomByCinemaID(int cinemaID)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                var query = "SELECT * FROM MoviesRooms WHERE CinemaID = @CinemaID;";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("CinemaID", cinemaID);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new MoviesRoomsViewModels
                    {
                        ID = int.Parse(reader["RoomID"].ToString()),
                        CinemaID = int.Parse(reader["CinemaID"].ToString()),
                        MaxSeatings = int.Parse(reader["MaxSeating"].ToString()),
                        Seatings = int.Parse(reader["MaxSeating"].ToString()),
                        FilmID = int.Parse(reader["FilmID"].ToString()),
                    };
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
    }
}
