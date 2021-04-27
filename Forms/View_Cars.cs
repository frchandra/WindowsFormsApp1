using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
   
    public partial class View_Cars : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RentCar.accdb");

        public View_Cars()
        {
            InitializeComponent();
        }

        private void View_Cars_Load(object sender, EventArgs e)
        {
            displayCars();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                CarModel carModel = new CarModel(textBox1.Text, textBox1.Text);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(carModel.search());
                DataTable dataTable = new DataTable();               
                dataAdapter.Fill(dataTable);
                i = Convert.ToInt32(dataTable.Rows.Count.ToString());
                dataGridView1.DataSource = dataTable;          

                if ( i == 0)
                    MessageBox.Show("Not Found");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                CarModel carModel = new CarModel(i, Brand.Text, Model.Text, Transmision.Text, Max_Passenger.Text, Price.Text, Quantity.Text);
                carModel.update();
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
                CarModel carModel = new CarModel(i);
                carModel.pull();

                Brand.Text = carModel.Brand;
                Model.Text = carModel.Model;
                Transmision.Text = carModel.Transmision;
                Max_Passenger.Text = carModel.Max_Passenger.ToString();
                Price.Text = carModel.Price.ToString();
                Quantity.Text = carModel.Quantity.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public void displayCars()
        {
            try
            {
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cars_Info";
                cmd.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
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
    }
}
