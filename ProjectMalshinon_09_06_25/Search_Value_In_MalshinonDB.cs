using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace ProjectMalshinon_09_06_25
{
    internal class Search_Value_In_MalshinonDB : DAL
    {




        /// <summary>
        /// If the value exists in the "People" table returns true otherwise returns false.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool SearchPerson(string table, string column, string value) 
        {
        
            bool result = false;

            string query = $@"SELECT {column} FROM {table} WHERE {column} = @value;";
           

            //Console.WriteLine(query);
            try
            {
                using (var cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@value", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = true;
                        }
                    }
                    
                }
           
           

            }
            catch (MySqlException ex) 
            {
                Console.WriteLine($"My SQL exception:  {ex}. class: Search_Value_In_MalshinonDB method: SearchPerson");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"General exception: {ex.Message}.  class: Search_Value_In_MalshinonDB method: SearchPerson");
            }
            finally 
            {
                CloseConnection();
            }
            return result;


        }
        /// <summary>
        /// Static method to get the result.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValueExists(string table, string column, string value)
        {
            Search_Value_In_MalshinonDB searchValueInMalshinonDB = new Search_Value_In_MalshinonDB();

            bool result = searchValueInMalshinonDB.SearchPerson(table, column, value);

            return result;
        }




    }

  
    
}
