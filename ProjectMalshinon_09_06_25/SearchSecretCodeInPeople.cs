using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class SearchSecretCodeInPeople : DAL
    {   
        
        public  bool SecretCodeExistsInTabla(int secretCode)
        {

         
            bool result = false;

            string query = @"SELECT SecretCode FROM People WHERE SecretCode = @secretCode;";

            try
            {
                using (var cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@SecretCode", secretCode);

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
                CloseConnection();
            }
            return result;


        }
    }
}
