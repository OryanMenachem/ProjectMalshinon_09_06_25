using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace ProjectMalshinon_09_06_25
{
    internal class UpdateNumberOfReports : DAL
    {
        private UpdateNumberOfReports(int id) 
        {
            string query = @"UPDATE People SET num_reports = num_reports + 1 WHERE Id = @id;";

            try
            {

                using (var cmd = new MySqlCommand(query, _conn))
                {

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.GetType().Name} ----- {ex.Message}. class: UpdateNumberOfReports method: constructor");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}. class: UpdateNumberOfReports method: constructor");
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void UpdateReports(int id)
        {
            UpdateNumberOfReports updateNumberOfReports = new UpdateNumberOfReports(id);

            Console.WriteLine("Num of reports updated successfully");
        }

    }
}
