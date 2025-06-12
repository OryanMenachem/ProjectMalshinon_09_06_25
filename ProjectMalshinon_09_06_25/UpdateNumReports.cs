using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace ProjectMalshinon_09_06_25
{
    internal class UpdateNumReports : DAL
    {
        private UpdateNumReports(int id) 
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
                TextColors.ErrorColor($"MySQL Exception: {ex.Message}. class: UpdateNumReports method: constructor");
            }
            catch (Exception ex)
            {
                TextColors.ErrorColor($"General Exception: {ex.Message}. class: UpdateNumReports method: constructor");
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void UpdateReports(int id)
        {
            UpdateNumReports updateNumberOfReports = new UpdateNumReports(id);

            TextColors.SuccessfullColor("Num of reports updated successfully\n");
        }

    }
}
