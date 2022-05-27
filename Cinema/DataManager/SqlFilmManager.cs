using Cinema.DataHelper.Interface;
using Cinema.Models;
using System.Data.SqlClient;

namespace Cinema.DataHelper
{
    public class SqlFilmHelper : IFilmDataManager
    {
        private readonly string _connectionString;
        public SqlFilmHelper(string connectionString)
        {
            _connectionString = connectionString;
        }



        public int AddNewFilm(FilmsViewModels film)
        {
            var query = @"INSERT INTO[dbo].[Films]
                                   ([Title]
                                   ,[Genre]
                                   ,[Author]
                                   ,[Producer]
                                   ,[Duration])
                             VALUES
                                   (@Title
                                   ,@Genre
                                   ,@Author
                                   ,@Producer
                                   ,@Duration);SELECT @@IDENTITY AS 'Identity';";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Title", film.Title);
            command.Parameters.AddWithValue("Genre", film.Genre);
            command.Parameters.AddWithValue("Author", film.Author);
            command.Parameters.AddWithValue("Producer", film.Producer);
            command.Parameters.AddWithValue("Duration", film.Duration);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public bool DeleteFilmByID(int id)
        {
            var query = @"DELETE FROM Films
                            WHERE FilmID = @FilmID";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("FilmID", id);

            return command.ExecuteNonQuery() != 0;
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

        public void AddSpectatorToMovieRoom(int roomID)
        {
            
        }

        public void ClearMovieRoom(int roomID)
        {
            throw new NotImplementedException();
        }


    }
}
