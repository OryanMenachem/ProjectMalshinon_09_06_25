using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class PotentialThreatChecker : DAL
    {
        private static int num_mentions = 0;
        private PotentialThreatChecker(int id)
        {
            string query = @"SELECT num_mentions FROM People WHERE Id = @id;";

            try
            {

                var cmd = new MySqlCommand(query, _conn);


                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    num_mentions = reader.GetInt32("num_mentions");
                }
            }

            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Exception: {ex.Message}. class: PotentialThreatChecker method: constructor");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}. class: PotentialThreatChecker method: constructor");
            }
            finally
            {
                CloseConnection();
            }
        }
        public static bool IsPotentialThreat(int id)
        {
            PotentialThreatChecker potentialThreatChecker = new PotentialThreatChecker(id);
            return num_mentions >= 20;
           
        }
    }
}
