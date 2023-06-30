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
using System.Configuration;

namespace Electricity
{
    public partial class Form1 : Form
    {
        DataBaseClass db = new DataBaseClass();
        //Dictionary<string,string> electricity = new Dictionary<string, string>();
        double electricityPrice = 4.1;
       
        // DateTime dateTime = new DateTime();
        public Form1()
        {
            InitializeComponent();
            //electricity.Add("28.04.2023 14:30:00", "22875");
            //listBox1.DataSource = new BindingSource(electricity, null);
            //listBox1.DisplayMember = "Key";
            //listBox1.ValueMember = "Value";
            LoadData();
           
            
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text= Convert.ToString(listBox1.SelectedValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int res = Convert.ToInt32(textBox2.Text) - Convert.ToInt32(textBox1.Text);
            double result = Convert.ToDouble(res) * electricityPrice;
            resultLabel.Text = Convert.ToString(result);

            string query = $"INSERT INTO Electricity(monthdate, electricity) VALUES('{Convert.ToString(DateTime.Today)}', '{textBox2.Text}')";
             SqlCommand sqlCommand = new SqlCommand(query, db.GetConnection());
            db.OpenConnection();
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Добавленно!");
            }
            else
            {
                MessageBox.Show("Не добавленно! =(");
            }
            db.CloseConnection();
            LoadData();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            
        }
        private void LoadData()
        {
            db.OpenConnection();
            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string queryString = $"SELECT * FROM Electricity";
            SqlCommand sqlCommand = new SqlCommand(queryString, db.GetConnection());
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataSet);
            this.listBox1.DataSource = dataSet.Tables[0];
            this.listBox1.DisplayMember = "monthdate";
            this.listBox1.ValueMember = "electricity";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.OpenConnection();
            string query = $"DELETE FROM Electricity WHERE  electricity = '{textBox1.Text}';";

            SqlCommand sqlCommand = new SqlCommand(query, db.GetConnection());

            
            //sqlCommand.ExecuteNonQuery();
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Удалено!");
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Не удалено! =(");
            }
            db.CloseConnection();
            LoadData();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
