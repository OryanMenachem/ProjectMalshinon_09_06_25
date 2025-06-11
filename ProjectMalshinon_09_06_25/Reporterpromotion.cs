using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Compiler;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class ReporterPromotion : DAL
    {
        string text = "";
        int num_reports;

        public ReporterPromotion(int reporter_id)
        {
            GetText(reporter_id);
            GetNumReports(reporter_id);
            PromotionToPotentialAgent(reporter_id);
        }

        private void GetText(int reporter_id)
        {
            string query = @"SELECT Text FROM `intelreports` WHERE Reporter_id = @reporter_id;";
           
            try
            {

                var cmd = new MySqlCommand(query, _conn);


                cmd.Parameters.AddWithValue("@reporter_id", reporter_id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    text += reader.GetString("Text");
                }




            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Exception: {ex.Message}. class: ReporterPromotion method: GetText");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}. class: ReporterPromotion method: GetText");
            }
            finally
            {
                CloseConnection();
            }

          
        }

                   
        private void GetNumReports(int reporter_id)
        {
            string query = @"SELECT num_reports FROM People WHERE Id = @reporter_id;";
            
            try
            {
                OpenConnection();

                var cmd = new MySqlCommand(query, _conn);
                

                cmd.Parameters.AddWithValue("@reporter_id", reporter_id);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    num_reports = reader.GetInt32("num_reports");
                }
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Exception: {ex.Message}. class: ReporterPromotion method: GetNumReports");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}. class: ReporterPromotion method: GetNumReports");
            }
            finally
            {
                CloseConnection();
            }
        
        }

        private void PromotionToPotentialAgent(int reporter_id)
        {
            if (num_reports >= 10 && (text.Length / num_reports) >= 100)
            {
                string query = @"UPDATE People SET Type = 'potential_agent' WHERE Id = @reporter_id;";

                try
                {
                    OpenConnection();

                    var cmd = new MySqlCommand(query, _conn);


                    cmd.Parameters.AddWithValue("@reporter_id", reporter_id);

                    cmd.ExecuteReader();
                  

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Exception: {ex.Message}. class: ReporterPromotion method: PromotionToPotentialAgent");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Exception: {ex.Message}. class: ReporterPromotion method: PromotionToPotentialAgent");
                }
                finally
                {
                    CloseConnection();
                }
                Console.WriteLine("The reporter is promoted to a potential agent.");

            }
            else
            {
                Console.WriteLine("Didn't bring enough information to become a potential agent.");
            }
        }

    }
    
}
