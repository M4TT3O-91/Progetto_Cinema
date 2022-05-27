using Cinema.DataManager.Interface;
using Cinema.Models;
using System.Data.SqlClient;

namespace Cinema.DataManager
{
    public class SqlFilmManager : IFilmDataManager
    {
        private readonly string _connectionString;
        public SqlFilmManager(string connectionString)
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

        public void ClearMovieRoom(int roomID)
        {
            throw new NotImplementedException();
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

        public FilmsViewModels GetFilmByID(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT * FROM Films WHERE FilmID = @FilmID;";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("FilmID", id);
            using var reader = command.ExecuteReader();
            var movie = new FilmsViewModels();
            while (reader.Read())
            {
                movie.ID = int.Parse(reader["FilmID"].ToString());
                movie.Author = reader["Author"].ToString();
                movie.Title = reader["Title"].ToString();
                movie.Duration = decimal.Parse(reader["Duration"].ToString());
                movie.Producer = reader["Producer"].ToString();
                movie.Genre = reader["Genre"].ToString();
            }
            return movie;
        }
    }
}
