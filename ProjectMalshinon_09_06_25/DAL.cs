using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ProjectMalshinon_09_06_25
{
    internal class DAL
    {
        private string connStr = "server=localhost;user=root;password=;database=Malshinon";
        private MySqlConnection conn;


        public DAL()  // Creates a single instance of "conn".
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
        
        }
        public void  OpenConnection() // Opens the connection to the database.
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)  // Makes sure the connection is closed.
                {
                    conn.Open();
                    Console.WriteLine("Connection successful.");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySql Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
            }
      
        }
          


        public void CloseConnection() // Closes the connection to the database.
        {
            if (conn.State == System.Data.ConnectionState.Open) // Makes sure the connection is open.
            {
                conn.Close(); 
                conn = null;
                Console.WriteLine("The connection was successfully disconnected.");
            }
        }

        public MySqlConnection GetConnection() // Access to the show - "coon".
        {
            return conn;
        }


    }
}
