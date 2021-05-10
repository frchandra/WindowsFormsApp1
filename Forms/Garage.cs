using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Garage : Form, Interface1
    {        
        public Garage()
        {
            InitializeComponent();
        }

        private void Garage_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        public void fillGrid()
        {
            CarModel carModel = new CarModel();
            dataGridView1.DataSource =  carModel.getDataTable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            RentCarModel rentCarModel = new RentCarModel();
            DataTable dataTable = rentCarModel.getNotReturnded(i);
            dataGridView2.DataSource = dataTable;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            CarModel carModel = new CarModel(textBox1.Text, textBox1.Text);
            DataTable dataTable = carModel.search();
            dataGridView1.DataSource = dataTable; 
        }

    }
}
