using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class SelectBy : DAL
    {
        private  List<Person> SelectByType(string type)
        {

            List<Person> personList = new List<Person>();

            string query = $@"SELECT * FROM People WHERE Type = @type;";


            try
            {
                using (var cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@type", type);


                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            personList.Add(new Person(
                            reader.GetInt32("Id"),
                            reader.GetString("FirstName"),
                            reader.GetString("LastName"),
                            reader.GetInt32("SecretCode"),
                            reader.GetString("Type"),
                            reader.GetInt32("num_reports"),
                            reader.GetInt32("num_mentions")));
                             
                            

                        }
                }

            }
            catch (MySqlException ex)
            {

                Console.WriteLine($"My SQL exception: {ex.Message}. class: SelectBy method: SelectByType");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"General exception: {ex.Message}. class: SelectBy method: SelectByType ");
            }
            finally
            {
                CloseConnection();
            }
            return personList;
        }

        public static List<Person> GetSelectByType(string type)
        {
            SelectBy selectBy = new SelectBy();

            return selectBy.SelectByType(type);
        }
    }
}
