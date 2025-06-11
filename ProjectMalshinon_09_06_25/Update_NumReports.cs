using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace ProjectMalshinon_09_06_25
{
    internal class Update_NumReports : DAL
    {
        private Update_NumReports(int id) 
        {
            string query = @"UPDATE People SET num_reports = num_reports + 1 WHERE Id = @id;";

            try
            {

                var cmd = new MySqlCommand(query, _conn);
                

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Exception: {ex.Message}. class: UpdateNumberOfReports method: constructor");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}. class: UpdateNumberOfReports method: constructor");
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void UpdateReports(int id)
        {
            Update_NumReports updateNumberOfReports = new Update_NumReports(id);

            Console.WriteLine("Num of reports updated successfully\n");
        }

    }
}
