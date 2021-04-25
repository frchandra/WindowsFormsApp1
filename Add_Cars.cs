using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Add_Cars : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RentCar.accdb");

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


            OleDbCommand cmd = new OleDbCommand(" INSERT INTO Cars_Info (Brand, Model, Transmision, Max_Passenger, Price, Quantity, Available_Quantity) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + comboBox1.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox6.Text + "') ", con);

            /**/

            //string Brand = textBox1.Text;
            //string Model = textBox2.Text;
            //string Transmision = comboBox1.Text;
            //int Max_Passenger = Convert.ToInt32(textBox4.Text);
            //int Price = Convert.ToInt32(textBox5.Text);
            //int Quantity = Convert.ToInt32(textBox6.Text);
            //int Available_Quantity = Convert.ToInt32(textBox6.Text);


            

            //OleDbCommand cmd = new OleDbCommand("INSERT INTO Cars_Info VALUES ( @Brand, @Model, @Transmision, @Max_Passenger, @Price, @Quantity, @Available_Quantity)", con);

            
            //cmd.Parameters.AddWithValue("@Brand", Brand.Trim());
            //cmd.Parameters.AddWithValue("@Model", Model.Trim());
            //cmd.Parameters.AddWithValue("@Transmision", Transmision.Trim());
            //cmd.Parameters.AddWithValue("@Max_Passenger", Max_Passenger);
            //cmd.Parameters.AddWithValue("@Price", Price);
            //cmd.Parameters.AddWithValue("@Quantity", Quantity);
            //cmd.Parameters.AddWithValue("@Available_Quantity", Available_Quantity);




            cmd.ExecuteNonQuery();
            con.Close();






            MessageBox.Show("Car Added Successfully");

            //textBox1.Text = "";
            //textBox2.Text = "";
            //textBox4.Text = "";
            //textBox5.Text = "";
            //textBox6.Text = "";

        }

        private void Add_Cars_Load(object sender, EventArgs e)
        {

        }
    }
}
