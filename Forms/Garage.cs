using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Garage : Form
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

        private void button1_Click(object sender, EventArgs e)
        {
            CarModel carModel = new CarModel(textBox1.Text, textBox1.Text);
            DataTable dataTable = carModel.search();
            dataGridView1.DataSource = dataTable; 
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = Convert.ToInt32(dataGridView2.SelectedCells[1].Value.ToString());
            MemberModel memberModel = new MemberModel(i);
            memberModel.pullById();
            textBox2.Text = memberModel.Email;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            ////(username, password)
            //smtp.Credentials = new NetworkCredential("xxx@gmail.com", "xxx");
            ////(from, to, subject, body)
            //MailMessage mail = new MailMessage("xxx@gmail.com", textBox2.Text, "Rent-A-Car Notification", textBox3.Text);
            //mail.Priority = MailPriority.High;
            //smtp.Send(mail);
            //MessageBox.Show("Mail Has Been Sent");
        }
    }
}
