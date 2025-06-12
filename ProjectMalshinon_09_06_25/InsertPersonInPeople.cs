using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class InsertPersonInPeople : DAL
    {
        private InsertPersonInPeople(string firstName, string lastName, int secretCode, string type = "reporter") 
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
                TextColors.ErrorColor($"MySQL Exception {ex.Message}. class: InsertPersonInPeople method: constructor");
            }
            catch (Exception ex)
            {
                TextColors.ErrorColor($"General Exception: {ex.Message}. class: InsertPersonInPeople method: constructor");
            }
            finally
            {
                CloseConnection();
            }
            TextColors.SuccessfullColor($"{firstName +" "+ lastName}, Added successfully\n");
        }

        public static void Insert(string firstName, string lastName, int secretCode, string type = "reporter")
        {
            if (!SearchValueInMalshinonDB.ValueExists("People", "FirstName", firstName))
            {
                InsertPersonInPeople insertRowInTable = new InsertPersonInPeople(firstName, lastName, secretCode, type);
               
            }
            else
            {
                TextColors.SuccessfullColor($"{firstName +" "+ lastName} already exists in the system.");
            }
        }
    
    }
}
