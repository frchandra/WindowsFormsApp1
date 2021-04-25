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
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rental_Mobil;Integrated Security=True;Pooling=False");

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RentCar.accdb");


        int count = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from admin where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "' ";

            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            count = Convert.ToInt32( dataTable.Rows.Count.ToString());
            if(count == 0)
            {
                MessageBox.Show("username/password doesnt match");

            }
            else
            {
                this.Hide();
                MDI_User mDI_User = new MDI_User();
                mDI_User.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Open();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
