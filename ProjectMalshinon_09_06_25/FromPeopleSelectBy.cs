using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class FromPeopleSelectBy : DAL
    {

        private Person SelectByFirstName(string firstName)
        {

            string query = $@"SELECT * FROM People WHERE FirstName = @firstName;";


            try
            {
                var cmd = new MySqlCommand(query, _conn);

                cmd.Parameters.AddWithValue("@firstName", firstName);

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

                TextColors.ErrorColor($"My SQL exception: {ex.Message}. class: FromPeopleSelectBy method: SelectByFirstName");
            }
            catch (Exception ex)
            {

                TextColors.ErrorColor($"General exception: {ex.Message}. class: FromPeopleSelectBy method: SelectByFirstName ");
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
        public static Person GetSelectByFirstName(string value)
        {
            FromPeopleSelectBy fromPeopleSelectBy = new FromPeopleSelectBy();

            Person person = fromPeopleSelectBy.SelectByFirstName(value);

            return person;
        }



        private  List<Person> SelectPersonByType(string type)
        {

            List<Person> personList = new List<Person>();

            string query = $@"SELECT * FROM People WHERE Type = @type;";


            try
            {
                var cmd = new MySqlCommand(query, _conn);
                
                cmd.Parameters.AddWithValue("@type", type);


                var reader = cmd.ExecuteReader();

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

            catch (MySqlException ex)
            {

                TextColors.ErrorColor($"My SQL exception: {ex.Message}. class: FromPeopleSelectBy method: SelectPersonByType");
            }
            catch (Exception ex)
            {

                TextColors.ErrorColor($"General exception: {ex.Message}. class: FromPeopleSelectBy method: SelectPersonByType ");
            }
            finally
            {
                CloseConnection();
            }

            return personList;
        }

        public static List<Person> GetSelectByType(string type)
        {
            FromPeopleSelectBy fromPeopleSelectBy = new FromPeopleSelectBy();

            return fromPeopleSelectBy.SelectPersonByType(type);
        }
    }
}
