using Cinema.DataManager.Interface;
using Cinema.Models;
using System.Data.SqlClient;

namespace Cinema.DataManager
{
    public class SqlSpectatorManager : ISpectatorDataManager
    {
        private readonly string _connectionString;
        public SqlSpectatorManager(string connectionString)
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
        public void AddSpectatorToMovieRoom(int roomID)
        {
            throw new NotImplementedException();
        }


    }
}
