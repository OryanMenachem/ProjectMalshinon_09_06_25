using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class InsertRowInTableIntelReports : DAL
    {
        private InsertRowInTableIntelReports(int reporter_id, int target_id, string text)
        {
            string query = @"INSERT INTO intelReports(Reporter_id, Target_id, Text) VALUES (@reporter_id, @target_id, @text);";
                             

            try
            {

                var cmd = new MySqlCommand(query, _conn);
                
                cmd.Parameters.AddWithValue(@"reporter_id", reporter_id);
                cmd.Parameters.AddWithValue(@"target_id", target_id);
                cmd.Parameters.AddWithValue(@"text", text);

                cmd.ExecuteNonQuery();

                TextColors.SuccessfullColor("The report was successfully added\n");


            }
            catch (MySqlException ex)
            {
               
                TextColors.ErrorColor($"MySQL Error: {ex.Message}. class: InsertRowInTableIntelReports method: constructor");
            }
            catch (Exception ex)
            {
            
                TextColors.ErrorColor($"General Error: {ex.Message}. class: InsertRowInTableIntelReports method: constructor");
            }
            finally
            {
                CloseConnection();
            }
        }

        public static void Insert(int reporter_id, int target_id, string text)
        {
            InsertRowInTableIntelReports insertRowInTableIntelReports = new InsertRowInTableIntelReports(reporter_id, target_id, text);

        }
    }
}
