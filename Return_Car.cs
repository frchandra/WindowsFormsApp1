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
    public partial class Return_Car : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rental_Mobil;Integrated Security=True;Pooling=False");
        public Return_Car()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            fillGrid(textBox1.Text);

        }

        private void Return_Car_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void fillGrid(string Name)
        {
          
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Rent_Car where Name='"+ Name.ToString() +"' AND Is_Returned = "+ 0 +" ";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Rent_Car where id="+i+" ";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            foreach(DataRow dataRow in dataTable.Rows)
            {
                Label_Model.Text = dataRow["Model"].ToString();
                Label_Transmision.Text = dataRow["Transmision"].ToString();
                Rent_Date.Text = Convert.ToString(dataRow["Rent_Date"].ToString());
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Rent_Car set Return_Date='"+ dateTimePicker1.Value.ToString() +"', Is_Returned="+ 1 +" where id=" + i + " ";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update Cars_Info set Available_Quantity=Available_Quantity+1 where Model='"+ Label_Model.Text +"' AND Transmision='"+ Label_Transmision.Text +"' ";
            cmd1.ExecuteNonQuery();

            MessageBox.Show("Car Returned Successfully");

            
            panel3.Visible = true;
            fillGrid(textBox1.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            double fine = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Rent_Car where Model= '" + Label_Model.Text + "' AND Transmision='" + Label_Transmision.Text + "' AND Name='"+ textBox1.Text +"' ";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            DateTime date2 = dateTimePicker1.Value;


            foreach (DataRow dataRow in dataTable.Rows)
            {
                DateTime date0 = Convert.ToDateTime(dataRow["Rent_Date"]);
                DateTime date1 = Convert.ToDateTime(dataRow["Return_Date"]);
                TimeSpan timeSpan1 = date2 - date0;
                TimeSpan timeSpan0 = date1 - date0;
                if (Math.Ceiling(timeSpan1.TotalDays) > Math.Ceiling(timeSpan0.TotalDays))
                {
                    label3.Visible = true;
                    label3.Text = string.Concat("Car returned in ", Convert.ToString(Math.Round(timeSpan1.TotalDays-timeSpan0.TotalDays)), " days late");
                    fine = Math.Round(timeSpan1.TotalDays - timeSpan0.TotalDays) * Convert.ToInt32(dataRow["Price"]);

                }
                else
                {
                    label3.Visible = false;
                }

                label6.Text = string.Concat(Convert.ToString(dataRow["Price"]), " + ", fine.ToString());





            }
        }
    }
}
