using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Rent_Car : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RentCar.accdb");

        public Rent_Car()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;

            MemberModel memberModel = new MemberModel();
            i = memberModel.searchByName(Name1.Text);


            //OleDbCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select Name, Email, Contact from Members_Info where Name='"+ Name1.Text +"' ";
            //cmd.ExecuteNonQuery();

            //DataTable dataTable = new DataTable();
            //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            //dataAdapter.Fill(dataTable);
            //i = Convert.ToInt32(dataTable.Rows.Count.ToString());
            
            if (i == 0)
            {
                MessageBox.Show("Can't Find This Name");
            }
            else
            {
                Name2.Text = memberModel.Name;
                Email.Text = memberModel.Email;
                Contact.Text = memberModel.Contact;

                //foreach ( DataRow dataRow in dataTable.Rows)
                //{
                //    Name2.Text = dataRow["Name"].ToString();
                //    Email.Text = dataRow["Email"].ToString();
                //    Contact.Text = dataRow["Contact"].ToString();
                //}
            }


        }

        private void Rent_Car_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void Brand_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;
            if (e.KeyCode != Keys.Enter)
            {
                listBox1.Items.Clear();

                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct Brand  from Cars_Info where Brand like('%" + Brand.Text + "%')";
                cmd.ExecuteNonQuery();

                DataTable dataTable = new DataTable();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                count = Convert.ToInt32(dataTable.Rows.Count.ToString());

                if(count > 0)
                {
                    listBox1.Visible = true;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        listBox1.Items.Add(dataRow["Brand"].ToString());
                    }
                }

            }
        }

        private void Brand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Brand.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false; 
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Brand.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e) //rent button
        {
            int car_availableQty = 0;
            int car_ID = 0; 
            int member_ID = 0;
            CarModel carModel = new CarModel(Brand.Text, Model.Text, Transmision.Text);
            MemberModel memberModel = new MemberModel(Name2.Text, Email.Text, Contact.Text);
            
            
            carModel.pullByBMT();
            car_availableQty = carModel.Available_Quantity;
            car_ID = carModel.Id;

            //OleDbCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;                      
            //cmd.CommandText = "select * from Cars_Info where Brand='"+ Brand.Text +"' AND Model='"+ Model.Text +"' AND Transmision='"+ Transmision.Text +"'  ";
            //cmd.ExecuteNonQuery();

            //DataTable dataTable = new DataTable();
            //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            //dataAdapter.Fill(dataTable);

            //foreach(DataRow dataRow in dataTable.Rows)
            //{
            //    car_Quantity = Convert.ToInt32(dataRow["Available_Quantity"]) ;
            //    car_ID = Convert.ToInt32(dataRow["ID"]);

            //}



            memberModel.pullByNEC();
            member_ID = memberModel.Id;
            //cmd.CommandText = "select * from Members_Info where Name='" + Name2.Text + "' AND Email='" + Email.Text + "' AND Contact='" + Contact.Text +"' ";
            //cmd.ExecuteNonQuery();

            //dataTable = new DataTable();
            //dataAdapter = new OleDbDataAdapter(cmd);
            //dataAdapter.Fill(dataTable);

            //foreach (DataRow dataRow in dataTable.Rows)
            //{
            //    member_ID = Convert.ToInt32(dataRow["ID"]);

            //}


            if (car_availableQty > 0)
            {
                RentCarModel rentCarModel = new RentCarModel(member_ID, car_ID, dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString(), Label_Total_Price.Text, false);
                rentCarModel.push();
                carModel.updateAvailableQty();

                //cmd.CommandText = "insert into Rent_Car (Car_ID, Member_ID) values('"+ Name2.Text +"','"+ Email.Text +"','"+ Contact.Text +"','"+ Brand.Text +"','"+ Model.Text +"','"+ Transmision.Text + "','" + Label_PricePerDay.Text + "','" + dateTimePicker1.Value.ToString() + "','" + dateTimePicker2.Value.ToString()+ "','" + Label_Total_Price.Text + "', "+ 0 +" )";
                //cmd.ExecuteNonQuery();



                //OleDbCommand cmd1 = con.CreateCommand();
                //cmd1.CommandType = CommandType.Text;
                //cmd1.CommandText = "update Cars_Info set Available_Quantity=Available_Quantity-1 where Model='" + Model.Text + "' AND Transmision='" + Transmision.Text + "' ";
                //cmd1.ExecuteNonQuery();


                MessageBox.Show("Data Added Successfully");
            }
            else
            {
                MessageBox.Show("Car Are Not Available for Now");
            }


           
        }


        private void Model_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox2.Focus();
                listBox2.SelectedIndex = 0;
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Model.Text = listBox2.SelectedItem.ToString();
                listBox2.Visible = false;
            }
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Model.Text = listBox2.SelectedItem.ToString();
            listBox2.Visible = false;
        }


        private void Model_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;
            if (e.KeyCode != Keys.Enter)
            {
                listBox2.Items.Clear();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct Model from Cars_Info where Brand=('" + Brand.Text + "') AND Model like ('%"+ Model.Text +"%') ";
                cmd.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                count = Convert.ToInt32(dataTable.Rows.Count.ToString());

                if (count > 0)
                {
                    listBox2.Visible = true;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        listBox2.Items.Add(dataRow["Model"].ToString());
                    }
                }

            }
        }

        private void Transmision_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;
            if (e.KeyCode != Keys.Enter)
            {
                listBox3.Items.Clear();

                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select distinct Transmision from Cars_Info where Model=('" + Model.Text + "') AND Transmision like ('%"+ Transmision.Text +"%') ";
                cmd.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                count = Convert.ToInt32(dataTable.Rows.Count.ToString());

                if (count > 0)
                {
                    listBox3.Visible = true;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        listBox3.Items.Add(dataRow["Transmision"].ToString());
                    }
                }

            }
        }

        private void Transmision_KeyDown(object sender, KeyEventArgs e)
       {
            if (e.KeyCode == Keys.Down)
            {
                listBox3.Focus();
                listBox3.SelectedIndex = 0;
            }
        }

        private void listBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Transmision.Text = listBox3.SelectedItem.ToString();
                listBox3.Visible = false;
            }
        }

        private void listBox3_MouseClick(object sender, MouseEventArgs e)
        {
            Transmision.Text = listBox3.SelectedItem.ToString();
            listBox3.Visible = false;

            
           
        }


        private void button3_Click(object sender, EventArgs e)//calcuate price
        {


            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Price from Cars_info where Brand='" + Brand.Text + "' AND Model= '"+ Model.Text +"' AND Transmision='"+ Transmision.Text +"' ";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;
            TimeSpan timeSpan = date2 - date1;


            foreach (DataRow dataRow in dataTable.Rows)
            {
                Label_PricePerDay.Text = dataRow["Price"].ToString();
                double totalPrice = Math.Ceiling(timeSpan.TotalDays) * Convert.ToInt32(dataRow["Price"]);

                Label_Total_Price.Text = totalPrice.ToString();
               
            }
           
        }
    }
}
