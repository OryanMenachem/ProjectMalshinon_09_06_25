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

            Person person = new Person();

            string query = $@"SELECT * FROM People WHERE FirstName = @value;";


            try
            {
                using (var cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@value", value);
                

                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            person.Id = reader.GetInt32("Id");
                            person.FirstName = reader.GetString("FirstName");
                            person.LastName = reader.GetString("LastName");
                            person.SecretCode = reader.GetInt32("SecretCode");
                            person.Type = reader.GetString("Type");
                            person.num_reports = reader.GetInt32("num_reports");
                            person.num_mentions = reader.GetInt32("num_mentions");


                        }
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
            return person;


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
