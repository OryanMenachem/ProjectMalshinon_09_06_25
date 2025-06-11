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
        private InsertRowInTablePeople(string firstName, string lastName, int secretCode, string type = "reporter") 
        {
            string query = @"INSERT INTO People(FirstName, LastName, SecretCode, Type) VALUES (@firstName, @lastName, @secretCode, @type)";

            try
            {

                var cmd = new MySqlCommand(query, _conn);
                
                cmd.Parameters.AddWithValue(@"firstName", firstName);
                cmd.Parameters.AddWithValue(@"lastName", lastName);
                cmd.Parameters.AddWithValue(@"secretCode", secretCode);
                cmd.Parameters.AddWithValue(@"type", type);
                  

                cmd.ExecuteNonQuery();
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Exception {ex.Message}. class: InsertRowInTablePeople method: constructor");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}. class: InsertRowInTablePeople method: constructor");
            }
            finally
            {
                CloseConnection();
            }
            Console.WriteLine("Added successfully.");
        }

        public static void Insert(string firstName, string lastName, int secretCode, string type = "reporter")
        {
            InsertRowInTablePeople insertRowInTable = new InsertRowInTablePeople(firstName, lastName, secretCode, type);
            
        }
    
    }
}
