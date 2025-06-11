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
        protected static MySqlConnection _conn;


        /// <summary>
        /// Runs the method - OpenConnection().
        /// </summary>
        public DAL() 
        {
            try
            {
                OpenConnection();
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

        /// <summary>
        ///  Creates a new connection to the database and opens it.
        /// </summary>
        /// <returns>MySqlConnection value</returns>
        public MySqlConnection OpenConnection() 
        {
            if (_conn == null)
            {
                _conn = new MySqlConnection(connStr);
            }

            if (_conn != null && _conn.State == System.Data.ConnectionState.Closed)  // Makes sure the connection is closed.
            {
                _conn.Open();
                //Console.WriteLine("Connection successful.\n");
            }
            return _conn;




        }


        /// <summary>
        /// Closes the connection to the database.
        /// </summary>
        public void CloseConnection() 
        {
            if (_conn != null &&  _conn.State == System.Data.ConnectionState.Open) // Makes sure the connection is open.
            {
                _conn.Close(); 
                _conn = null;
                //Console.WriteLine("The connection was successfully disconnected.\n");
            }
        }



    }
}
