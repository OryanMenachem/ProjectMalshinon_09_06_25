using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class InsertRowInTablePeople : DAL
    {
        private InsertRowInTablePeople(string firstName, string lastName, int secretCode, string type = "reporter", int num_reports = 0, int num_mentions = 0) 
        {
            string query = @"INSERT INTO People(FirstName, LastName, SecretCode, Type, Num_reports, Num_mentions) VALUES (@firstName, @lastName, @secretCode, @type, @num_reports, @num_mentions)";

            try
            {

                using (var cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue(@"firstName", firstName);
                    cmd.Parameters.AddWithValue(@"lastName", lastName);
                    cmd.Parameters.AddWithValue(@"secretCode", secretCode);
                    cmd.Parameters.AddWithValue(@"type", type);
                    cmd.Parameters.AddWithValue(@"num_reports", num_reports);
                    cmd.Parameters.AddWithValue(@"num_mentions", num_mentions);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}. class: InsertRowInTablePeople method: constructor");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}. class: InsertRowInTablePeople method: constructor");
            }
            finally
            {
                CloseConnection();
            }
            Console.WriteLine("Added successfully.");
        }

        public static void Insert(string firstName, string lastName, int secretCode, string type = "reporter", int num_reports = 0, int num_mentions = 0)
        {
            InsertRowInTablePeople insertRowInTable = new InsertRowInTablePeople(firstName, lastName, secretCode, type, num_reports, num_mentions);
            
        }
    
    }
}
