using System;
using System.Windows.Forms;

namespace PostgresApp
{
    public partial class WorkingWithDB : Form
    {
        public WorkingWithDB()
        {
            InitializeComponent();
        }
        private void WorkingWithDB_Load(object sender, EventArgs e)
        {
            var data = new PostgreSQLService();

            dgvData.DataSource = null;
            dgvData.DataSource = data.Select(EUSersColumnNames.domainName, EUSersColumnNames.email, EUSersColumnNames.telegramId);
        }
    }
}
