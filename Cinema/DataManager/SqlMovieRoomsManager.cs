using Cinema.DataManager.Interface;
using Cinema.Models;
using System.Data.SqlClient;

namespace Cinema.DataManager
{
    public class SqlMovieRoomsManager : IMovieRoomsDataManager
    {

        private readonly string _connectionString;

        public SqlMovieRoomsManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<MoviesRoomsViewModels> GetMovieRoomByCinemaID(int cinemaID)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT * FROM MovieRooms WHERE CinemaID = @CinemaID;";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("CinemaID", cinemaID);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new MoviesRoomsViewModels
                {
                    ID = int.Parse(reader["RoomID"].ToString()),
                    CinemaID = int.Parse(reader["CinemaID"].ToString()),
                    MaxSeatings = int.Parse(reader["MaxSeatings"].ToString()),
                    Seatings = int.Parse(reader["Seatings"].ToString()),
                    FilmID = int.Parse(reader["FilmID"].ToString()),
                };
            }

        }
    }
}
