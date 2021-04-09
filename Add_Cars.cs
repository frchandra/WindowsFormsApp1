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

namespace WindowsFormsApp1
{
    public partial class Add_Cars : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rental_Mobil;Integrated Security=True;Pooling=False");

        public Add_Cars()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Cars_Info values('"+ textBox1.Text +"', '"+ textBox2.Text + "', '"+ comboBox1.Text + "', "+ textBox4.Text +", "+ textBox5.Text +", "+ textBox6.Text + ", " + textBox6.Text + ") ";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Car Added Successfully");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void Add_Cars_Load(object sender, EventArgs e)
        {

        }
    }
}
