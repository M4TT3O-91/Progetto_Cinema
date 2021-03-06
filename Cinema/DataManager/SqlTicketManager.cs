using Cinema.DataManager.Interface;
using Cinema.Models;
using Cinema.Support;
using System.Data.SqlClient;

namespace Cinema.DataManager
{
    public class SqlTicketManager : ITicketDataManager
    {
        private readonly string _connectionString;

        public SqlTicketManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddTicket(TicketsViewModels ticket, DateTime birthDate)
        {
            if (Helper.IsforbiddenUnder14(birthDate))
                throw new Exception("This Film is forbidden under 14 years old");

            ticket = Support.Helper.ApplyDiscount(ticket, birthDate);
            var query = @" INSERT INTO [dbo].[Tickets]
                               ([Price]
                               ,[Discount]
                               ,[SpectatorID]
                               ,[FilmID]
                               ,[IsValid])
                         VALUES
                               (@Price, @Discount, @SpectatorID, @FilmID, @IsValid);SELECT @@IDENTITY AS 'Identity';";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Price", ticket.Price);
            command.Parameters.AddWithValue("Discount", ticket.Discount);
            command.Parameters.AddWithValue("SpectatorID", ticket.SpectatorID);
            command.Parameters.AddWithValue("FilmID", ticket.FilmID);
            command.Parameters.AddWithValue("IsValid", ticket.IsValid);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public bool ChangeTicketStateByRoomID(int roomID, bool state)
        {
            var query = @"UPDATE Tickets
                            SET IsValid = @state
                            WHERE(FilmID = (SELECT FilmID FROM MovieRooms WHERE RoomID = @RoomID))";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("RoomID", roomID);
            command.Parameters.AddWithValue("state", state);
            return command.ExecuteNonQuery() != 0;
        }

        

    }

}
