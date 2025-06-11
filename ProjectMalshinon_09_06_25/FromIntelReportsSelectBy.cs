using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectMalshinon_09_06_25
{
    internal class FromIntelReportsSelectBy : DAL
    {
        private List<IntelReports> SelectIntelReportsBy_ReporterId(int reporter_id)
        {

            List<IntelReports> intelReportsList = new List<IntelReports>();

            string query = $@"SELECT * FROM IntelReports WHERE Reporter_id = @reporter_id;";


            try
            {
                var cmd = new MySqlCommand(query, _conn);
                
                cmd.Parameters.AddWithValue("@reporter_id", reporter_id);


                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    intelReportsList.Add(new IntelReports(
                    reader.GetInt32("Id"),
                    reader.GetInt32("Reporter_id"),
                    reader.GetInt32("Target_id"),
                    reader.GetString("Text"),
                    Convert.ToString(reader.GetDateTime("Timestamp"))));



                }
                

            }
            catch (MySqlException ex)
            {

                Console.WriteLine($"My SQL exception: {ex.Message}. class: FromIntelReportsSelectBy method: SelectIntelReportsBy_ReporterId");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"General exception: {ex.Message}. class: FromIntelReportsSelectBy method: SelectIntelReportsBy_ReporterId ");
            }
            finally
            {
                CloseConnection();
            }
            return intelReportsList;
        }

        public static List<IntelReports> GetIntelReportsList(int reporter_id)
        {
            FromIntelReportsSelectBy fromIntelReportsSelectBy = new FromIntelReportsSelectBy();

            return fromIntelReportsSelectBy.SelectIntelReportsBy_ReporterId(reporter_id);
        }
    }
}
