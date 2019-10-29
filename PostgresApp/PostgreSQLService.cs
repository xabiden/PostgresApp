using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PostgresApp
{
    class PostgreSQLService : IDataBasesService
    {
        private static readonly string server = "localhost";
        private static readonly string port = "5434";
        private static readonly string serverUserId = "postgres";
        private static readonly string serverPassword = "O4fU32kCs3";
        private static readonly string databaseName = "postgres";

        private string connectionString = $"Server={server};Port={port};User Id={serverUserId};Password={serverPassword};Database={databaseName};";

        private NpgsqlConnection connection;
        private string query;
        private DataTable dataTable;
        private NpgsqlCommand cmd;

        public PostgreSQLService()
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public DataTable Select(params EUSersColumnNames[] columnNames)
        {
            try
            {              
                var comaSeparatedColumns = string.Join(",", columnNames);

                query = $@"SELECT {comaSeparatedColumns} FROM USERS";

                cmd = new NpgsqlCommand(query, connection);

                dataTable = new DataTable();

                connection.Open();

                dataTable.Load(cmd.ExecuteReaderAsync().Result);

                connection.Close();

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}"); //пока что так, раз логирования нет
                connection.Close();
                return null;
            }
        }

        public void Insert( string domainName, string email, string telegramId)
        {
            try
            {
                query = $"INSERT INTO USERS ({EUSersColumnNames.domainName}, {EUSersColumnNames.email}, {EUSersColumnNames.telegramId}) " +
                        $"VALUES ({domainName}, {email}, {telegramId})";

                cmd = new NpgsqlCommand(query, connection);

                connection.Open();

                cmd.Parameters.AddWithValue("DOMAINNAME", domainName);
                cmd.Parameters.AddWithValue("EMAIL", email);
                cmd.Parameters.AddWithValue("TELEGRAMID", telegramId);
                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}");
                connection.Close();
            }
        }
    }
}
