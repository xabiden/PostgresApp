using System;
using System.Windows.Forms;

namespace PostgresApp
{
    public partial class WorkingWithDB : Form
    {
        PostgreSQLService data = new PostgreSQLService();

        public WorkingWithDB()
        {
            InitializeComponent();
        }
        private void WorkingWithDB_Load(object sender, EventArgs e)
        {
            dgvData.DataSource = null;
            dgvData.DataSource = data.Select(EUSersColumnNames.id, EUSersColumnNames.domainName, EUSersColumnNames.email, EUSersColumnNames.telegramId); //грязь
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            data.Insert(txtBoxDomainName.ToString(), txtBoxEmail.ToString(), txtBoxTgId.ToString());
            dgvData.DataSource = data.Select(EUSersColumnNames.id, EUSersColumnNames.domainName, EUSersColumnNames.email, EUSersColumnNames.telegramId);
        }
    }
}
