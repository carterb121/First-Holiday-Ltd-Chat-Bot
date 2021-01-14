using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using First_Holiday_Ltd_Chat_Bot.dto;
using First_Holiday_Ltd_Chat_Bot.Interfaces;

namespace First_Holiday_Ltd_Chat_Bot.Repository
{
    public class DestinationRepositoryLogic : IDestinationRepository
    {
        public List<Destination> RetrieveDestinationsByType(List<Destination> list, string type)
        {
            try
            {
                string connectionString = "Server=.;Database=HolidayDestinations;Trusted_Connection=True;";
                string storedProcedure = "GetDestinationByType";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = command.Parameters.Add("@type", SqlDbType.VarChar);
                parameter.Value = type;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Destination destination = new Destination();
                    destination.Id = reader.GetInt32(0);
                    destination.Name = reader.GetString(1);
                    destination.Description = reader.GetString(2);
                    destination.HolidayType = reader.GetString(3);
                    destination.Country = reader.GetString(4);
                    destination.Cost = reader.GetDecimal(5);
                    destination.SuitableForSolo = reader.GetBoolean(6);
                    destination.SuitableForCouple = reader.GetBoolean(7);
                    destination.SuitableForFamily = reader.GetBoolean(8);
                    destination.SuitableForLargeParty = reader.GetBoolean(9);
                    destination.Rating = reader.GetDecimal(10);

                    list.Add(destination);
                }

                connection.Close();
            }
            catch
            {
                Console.WriteLine("I am really sorry, we are having issues finding you your dream holiday!");
                Console.WriteLine("Please try again soon!");
                AppStart.Main();
            }

            return list;
        }
    }
}
