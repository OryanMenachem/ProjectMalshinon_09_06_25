using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class SearchPersonInPeople : DAL
    {
        private MySqlConnection _conn;

        public SearchPersonInPeople() : base() 
        {
            _conn = OpenConnection();
        }



        /// <summary>
        /// If the first name exists in the "People" table, returns true otherwise returns false.
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public bool SearchPerson(string firstName) 
        {
        
            
            bool result = false;

            string query = @"SELECT FirstName FROM People WHERE FirstName = @firstName;";

            try
            {
                using (var cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);

                    using (var reader = cmd.ExecuteReader())
                        if (reader.Read())
                        {
                            result = true;
                        }
                }
           

            }
            catch (MySqlException ex) 
            {
                Console.WriteLine($"My SQL exception: {ex.Message}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"General exception: {ex.Message}");
            }
            finally 
            {
                _conn.Close(); 
            }
            return result;


        }




    }

  
    
}
