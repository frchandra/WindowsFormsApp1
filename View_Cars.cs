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
   
    public partial class View_Cars : Form
    { 
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rental_Mobil;Integrated Security=True;Pooling=False");
        public View_Cars()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void View_Cars_Load(object sender, EventArgs e)
        {

            displayCars();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cars_Info where Brand like('%"+ textBox1.Text + "%') or Model like('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                i = Convert.ToInt32(dataTable.Rows.Count.ToString());
                dataGridView1.DataSource = dataTable;
                con.Close();

                if ( i == 0)
                {
                    MessageBox.Show("Not Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Cars_Info set Brand='"+ Brand.Text +"', Model='"+ Model.Text +"', Transmision='"+ Transmision.Text +"', Max_Passenger='"+ Max_Passenger.Text +"', Price='"+ Price.Text +"', Quantity='"+ Quantity.Text +"' where id="+i+"    ";
                cmd.ExecuteNonQuery();
                con.Close();
                displayCars();
                MessageBox.Show("Record Updated");
                panel2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true; 
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cars_Info where id="+i+"";
                cmd.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                foreach(DataRow dataRow in dataTable.Rows)
                {
                    Brand.Text = dataRow["Brand"].ToString();
                    Model.Text = dataRow["Model"].ToString();
                    Transmision.Text = dataRow["Transmision"].ToString();
                    Max_Passenger.Text = dataRow["Max_Passenger"].ToString();
                    Price.Text = dataRow["Price"].ToString();
                    Quantity.Text = dataRow["Quantity"].ToString();


                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void displayCars()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cars_Info";
                cmd.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;


                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
