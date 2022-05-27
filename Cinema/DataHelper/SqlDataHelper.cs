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

                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Name", spectator.Name);
                command.Parameters.AddWithValue("Surname", spectator.Surname);
                command.Parameters.AddWithValue("BirthDate", spectator.BirthDate);

                return Convert.ToInt32(command.ExecuteScalar());         
        }

        public bool DeleteSpectator(int id)
        {
            var query = @"DELETE FROM [dbo].[Spectators]
                            WHERE SpectatorID = @SpectatorID";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("SpectatorID", id);

            return command.ExecuteNonQuery() != 0;
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
