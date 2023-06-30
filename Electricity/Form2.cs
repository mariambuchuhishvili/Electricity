using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Electricity
{
    public partial class Form2 : Form
    {
        DataBaseClass db = new DataBaseClass();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var monthdate = Convert.ToString(monthCalendar1.SelectionStart);
            var electricityValue = textBox1.Text;

            string query = $"INSERT INTO Electricity(monthdate, electricity) VALUES('{monthdate}', '{electricityValue}')";

            SqlCommand sqlCommand = new SqlCommand(query, db.GetConnection());

            db.OpenConnection();
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Добавленно!");
                this.Close();
            }
            else 
            {
                MessageBox.Show("Не добавленно! =(");
            }
            db.CloseConnection();
        }
    }
}
