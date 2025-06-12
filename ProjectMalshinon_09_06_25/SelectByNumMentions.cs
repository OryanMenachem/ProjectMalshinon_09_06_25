using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class SelectByNumMentions : DAL
    {
       
        private List<Person> SelectByNumMentionsBigEquals20()
        {
            string query = @"SELECT * FROM People WHERE num_mentions >= 20 ;";

            List<Person> personList = new List<Person>();
            try
            {

                var cmd = new MySqlCommand(query, _conn);
           
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    personList.Add(new Person (
                    reader.GetInt32("Id"),
                    reader.GetString("FirstName"),
                    reader.GetString("LastName"),
                    reader.GetInt32("SecretCode"),
                    reader.GetString("Type"),
                    reader.GetInt32("num_reports"),
                    reader.GetInt32("num_mentions")));
                }
            }

            catch (MySqlException ex)
            {
                TextColors.ErrorColor($"MySQL Exception: {ex.Message}. class: SelectByNumMentions method: SelectByNumMentionsBigEquals20");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}. class: SelectByNumMentions method: SelectByNumMentionsBigEquals20");
            }
            finally
            {
                CloseConnection();
            }
            return personList;
        }

        public static List<Person> GetPersonList()
        {
            SelectByNumMentions selectByNumMentions = new SelectByNumMentions();
            return selectByNumMentions.SelectByNumMentionsBigEquals20();
           
        }
    }
}
