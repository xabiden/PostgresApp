using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgresApp
{
    public partial class WorkingWithDB : Form
    {
        private static readonly string server = "localhost";
        private static readonly string port = "5434";
        private static readonly string serverUserId = "postgres";
        private static readonly string serverPassword = "O4fU32kCs3";
        private static readonly string databaseName = "postgres";


        private string connectionString = $"Server={server};Port={port};User Id={serverUserId};Password={serverPassword};Database={databaseName};";

        private NpgsqlConnection connection;
        private string query;
        private DataTable dt;
        private NpgsqlCommand cmd;
        public WorkingWithDB()
        {
            InitializeComponent();
        }
        private void WorkingWithDB_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(connectionString);
            Select();
        }

        private void Select()
        {
            try
            {
                connection.Open();
                query = @"SELECT * FROM USERS";
                cmd = new NpgsqlCommand(query, connection);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReaderAsync().Result);
                connection.Close();

                dgvData.DataSource = null;
                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
