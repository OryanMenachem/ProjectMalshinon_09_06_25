using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class UpdateNumMention : DAL
    {
        private UpdateNumMention(int id)
        {
            string query = @"UPDATE People SET num_mentions = num_mentions + 1 WHERE Id = @id;";

            try
            {

                var cmd = new MySqlCommand(query, _conn);
                

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                
            }
            catch (MySqlException ex)
            {
                TextColors.ErrorColor($"MySQL Exception: {ex.Message}. class: UpdateNumMention method: constructor");
            }
            catch (Exception ex)
            {
                TextColors.ErrorColor($"General Exception: {ex.Message}. class: UpdateNumMention method: constructor");
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void Update(int id)
        {
            UpdateNumMention updateNumMention = new UpdateNumMention(id);

            TextColors.SuccessfullColor("Num of Mention updated successfully\n");
        }
    }
}
