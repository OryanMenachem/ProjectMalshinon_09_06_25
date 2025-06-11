using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class SelectFromTable : DAL
    {
        private Person Select(string value)
        {


        
            string query = $@"SELECT * FROM People WHERE FirstName = @value;";


            try
            {
                var cmd = new MySqlCommand(query, _conn);
                
                cmd.Parameters.AddWithValue("@value", value);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Person person = new Person(
                    reader.GetInt32("Id"),
                    reader.GetString("FirstName"),
                    reader.GetString("LastName"),
                    reader.GetInt32("SecretCode"),
                    reader.GetString("Type"),
                    reader.GetInt32("num_reports"),
                    reader.GetInt32("num_mentions"));

                    return person;
                }
                

            }
            catch (MySqlException ex)
            {

                Console.WriteLine($"My SQL exception: {ex.Message}. class: SelectFromTable method: Select");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"General exception: {ex.Message}. class: SelectFromTable method: Select ");
            }
            finally
            {
                CloseConnection();
            }
            return null;


        }
        /// <summary>
        /// Static method to get the result.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Person GetPerson(string value)
        {
            SelectFromTable selectFromTable = new SelectFromTable();

            Person person = selectFromTable.Select(value);

            return person;
        }
    }
}
