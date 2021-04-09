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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class View_Members : Form, Interface1
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rental_Mobil;Integrated Security=True;Pooling=False");
        int i = 0;
        string wanted_path;
        DialogResult result;
        string pwd = Pass.GetRandomPassword(20);
        public View_Members()
        {
            InitializeComponent();
        }

        private void View_Members_Load(object sender, EventArgs e)
        {
            
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            fillGrid();
            
          
        }

        public void fillGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Members_Info";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            Bitmap img;
            DataGridViewImageColumn imageCol1 = new DataGridViewImageColumn();
            imageCol1.Width = 500;
            imageCol1.HeaderText = "ID_Card";
            imageCol1.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageCol1.Width = 100;
            dataGridView1.Columns.Add(imageCol1);


            foreach (DataRow dataRow in dataTable.Rows)
            {
                img = new Bitmap(@"..\..\" + dataRow["ID_Card"].ToString());
                dataGridView1.Rows[i].Cells[5].Value = img;
                dataGridView1.Rows[i].Height = 100;
                i++;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                int i = 0;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Members_Info where Name like('%"+ textBox1.Text +"%')";
                cmd.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                Bitmap img;
                DataGridViewImageColumn imageCol1 = new DataGridViewImageColumn();
                imageCol1.Width = 500;
                imageCol1.HeaderText = "ID_Card";
                imageCol1.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imageCol1.Width = 100;
                dataGridView1.Columns.Add(imageCol1);


                foreach (DataRow dataRow in dataTable.Rows)
                {
                    img = new Bitmap(@"..\..\" + dataRow["ID_Card"].ToString());
                    dataGridView1.Rows[i].Cells[5].Value = img;
                    dataGridView1.Rows[i].Height = 100;
                    i++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string j = (dataGridView1.SelectedCells[0].Value.ToString());
            int i = Convert.ToInt32(j);
            

            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Members_Info where id=" + i + "  ";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable); 
            foreach( DataRow dataRow in dataTable.Rows)
            {
                Name.Text = dataRow["Name"].ToString();
                Email.Text = dataRow["Email"].ToString();
                Contact.Text = dataRow["Contact"].ToString();


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG files (*.jpeg)|*.jpeg|PNG FIles (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (result == DialogResult.OK)
            {
                string j = (dataGridView1.SelectedCells[0].Value.ToString());
                int i = Convert.ToInt32(j);
                string img_path;
                File.Copy(openFileDialog1.FileName, wanted_path + "\\ID_Card\\" + pwd + ".jpg");
                img_path = "ID_Card\\" + pwd + ".jpg";

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Members_Info set Name='"+ Name.Text +"', ID_Card='"+ img_path.ToString() +"',  Email='"+ Email.Text +"', Contact='"+ Contact.Text +"' where id="+ i  +" ";
                cmd.ExecuteNonQuery();
                fillGrid();
                MessageBox.Show("Record Updated Successfully");


            }
            else if(result == DialogResult.Cancel)
            {
                string j = (dataGridView1.SelectedCells[0].Value.ToString());
                int i = Convert.ToInt32(j);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Members_Info set Name='" + Name.Text + "',  Email='" + Email.Text + "', Contact='" + Contact.Text + "' where id=" + i + " ";
                cmd.ExecuteNonQuery();
                fillGrid();
                MessageBox.Show("Record Updated Successfully");
            }
        }
    }
}
