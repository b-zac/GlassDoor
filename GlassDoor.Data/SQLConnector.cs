using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GlassDoor.Data
{
    // SQL Connection helper, handling execution of SQL Queries / Store Procedures
    public class SQLConnector
    {
        // Method to create database Connection String
        private static String GetConnectionString()
        {
            // Assign name of database
            string dbname = "glassdoorhonoursdb";

            // If dbname is empty, return null
            if (string.IsNullOrEmpty(dbname)) return null;

            // Database credentials
            string username = "zachar";
            string password = "z4ch4r2020!";
            string hostname = "glassdoordb.database.windows.net";

            // Return Connection String
            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }

        // Method to retrieve DataRow object form database
        public static void Retrieve(Action<SqlCommand> _CommandAction, Action<DataRow> _Callback = null)
        {
            // Create new SQL connection using the Connection String
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                // Create new SQL command
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;      // Set SQL command type to stored procedure

                    _CommandAction.Invoke(command);     // Get configuration of the query and parameters from calling member

                    command.Connection = connection;        // Set connection object on the command

                    connection.Open();      // Open connection to SQL

                    SqlDataReader reader = command.ExecuteReader();     // Execute command on SQL server
                    var dataTable = new DataTable();        // Create new Data store object

                    if (reader.HasRows)     // Check if SQL returned any rows
                    {
                        dataTable.Load(reader);     // Load all rows into the data table object
                    }

                    reader.Close();     // Close reader
                    connection.Close();     // Close connection to SQL server

                    if (dataTable.Rows.Count > 0)       // Check if rows were returned
                        _Callback.Invoke(dataTable.Rows[0]);        // Return first row
                    else
                        _Callback.Invoke(null);     // Return null if SQL didn't return anything

                }
            }
        }

        // Method to retrieve multiple results from SQL
        public static void RetrieveMultiple(Action<SqlCommand> _CommandAction, Action<DataTable> _Callback = null)
        {
            // Create new SQL connection using the Connection String
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                // Create new SQL command
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;      // Set the SQL type to stored procedure

                    _CommandAction.Invoke(command);     // Get configuration of the query and parameters from calling member

                    command.Connection = connection;        // Set connection object on the command

                    connection.Open();      // Open connection to SQL

                    SqlDataReader reader = command.ExecuteReader();     // Execute command on SQL server

                    var dataTable = new DataTable();        // Create new Data store object

                    if (reader.HasRows)     // Check if rows were returned
                    {
                        dataTable.Load(reader);     // Return first row
                    }

                    reader.Close();     // Close reader
                    connection.Close();     // Close connection to SQL server

                    _Callback.Invoke(dataTable);        // Return null if SQL didn't return anything

                }
            }
        }

        //public static void RetrieveMultiTableSet(Action<SqlCommand> _CommandAction, Action<DataSet> _Callback = null)
        //{
        //    using (SqlConnection connection = new SqlConnection(GetConnectionString()))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.CommandType = System.Data.CommandType.StoredProcedure;

        //            _CommandAction.Invoke(command);

        //            command.Connection = connection;

        //            connection.Open();

        //            SqlDataReader reader = command.ExecuteReader();

        //            var dataset = new DataSet();

        //            while (!reader.IsClosed)
        //            {
        //                DataTable t = new DataTable();
        //                t.Load(reader);
        //                dataset.Tables.Add(t);
        //            }


        //            reader.Close();
        //            connection.Close();

        //            _Callback.Invoke(dataset);

        //        }
        //    }
        //}

        // Non Query executor which doesn't return any data but returns the number of affected items in table
        public static int UpdateOne(Action<SqlCommand> _CommandAction)
        {
            // Create new SQL connection using the Connection String
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                // Create new SQL command
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;      // Set the SQL type to stored procedure

                    _CommandAction.Invoke(command);     // Get configuration of the query and parameters from calling member

                    command.Connection = connection;        // Set connection object on the command

                    connection.Open();      // Open connection to SQL

                    int rowsAffected = command.ExecuteNonQuery();       // Get the number of affected records

                    connection.Close();     // Close connection to SQL server

                    return rowsAffected;        // Return number of affeted records
                }
            }

        }

    }
}
