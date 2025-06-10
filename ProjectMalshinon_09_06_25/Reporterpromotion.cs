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

        string FirstName = "";
        int Reporter_id = 0;

        int NumWordsInAllReports = 0;

        int NumReports = 0;

        public ReporterPromotion(string firstName, int reporter_id)
        {
            FirstName = firstName;
            Reporter_id = reporter_id;
        }



        /// <summary>
        /// Check that the number of reports of the reporter is equal to or greater than ten.
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        private void CheckingNumberReports()
        {
            string query = $@"SELECT num_reports FROM People WHERE FirstName = @FirstName;";

            try
            {
                using (var cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);


                    using (var reader = cmd.ExecuteReader())
                        if (reader.Read())
                        {
                            NumReports = reader.GetInt32("num_reports");
                        }



                }

            }
            catch (MySqlException ex)
            {

                Console.WriteLine($"My SQL exception: {ex.Message}. class: SelectFromTable method: Select");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"General exception: {ex.Message}. class: SelectFromTable method: Select ");
            }
            finally
            {
                CloseConnection();
            }


        }

        private void CheckingTheNumberOfWordsInReports()
        {
            string query = $@"SELECT Text FROM IntelReports WHERE Reporter_id = @Reporter_id;";

            string reports = "";


            try
            {
                using (var cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@Reporter_id", Reporter_id);


                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            reports += reader.GetString("Text");
                        }



                }

            }
            catch (MySqlException ex)
            {

                Console.WriteLine($"My SQL exception: {ex.Message}. class: SelectFromTable method: Select");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"General exception: {ex.Message}. class: SelectFromTable method: Select ");
            }
            finally
            {
                CloseConnection();
            }

   
            NumWordsInAllReports = reports.Length;







        }

        public void Reporter_promotion_to_potential_agent()
        {

            if (NumReports >= 10 && (NumWordsInAllReports / NumReports) >= 100)
            {
                string query = @"UPDATE people SET Type = potential_agent WHERE FirstName = @FirstName;";

                try
                {

                    using (var cmd = new MySqlCommand(query, _conn))
                    {

                        cmd.Parameters.AddWithValue("@FirstName", FirstName);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}. class: InsertRowInTablePeople method: constructor");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}. class: InsertRowInTablePeople method: constructor");
                }
                finally
                {
                    CloseConnection();
                }
                Console.WriteLine($"The reporter {FirstName} is promoted to a potential agent.");

            }

        }

    }
}
