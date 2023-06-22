using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electricity
{
    public partial class Form1 : Form
    {
        Dictionary<string,string> electricity = new Dictionary<string, string>();
        double electricityPrice = 4.1;
        // DateTime dateTime = new DateTime();
        public Form1()
        {
            InitializeComponent();
            electricity.Add("28.04.2023 14:30:00", "22875");
            listBox1.DataSource = new BindingSource(electricity, null);
            listBox1.DisplayMember = "Key";
            listBox1.ValueMember = "Value";
            
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text= Convert.ToString(listBox1.SelectedValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int res = Convert.ToInt32(textBox2.Text) - Convert.ToInt32(textBox1.Text);
            double result = Convert.ToDouble(res) * electricityPrice;
            electricity.Add(Convert.ToString(DateTime.Now), Convert.ToString(textBox2.Text));
            listBox1.DataSource = new BindingSource(electricity, null);
            resultLabel.Text = Convert.ToString(result);
            
            
        }
    }
}
