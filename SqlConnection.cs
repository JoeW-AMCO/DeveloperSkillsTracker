using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSkillsTracker
{
    public class SqlConnector
    {
        //Field
        private readonly string _connectionString;

        //Constructor
        public SqlConnector(string connectionString = "data source=ASWW00227\\SQLEXPRESS;initial catalog=SkillsTracker;trusted_connection=true;TrustServerCertificate=True;")
        {
            _connectionString = connectionString;
        }

        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                return command.ExecuteScalar();
            }
        }
    }
}

