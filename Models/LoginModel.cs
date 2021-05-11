using System.Data;
using System.Data.OleDb;


namespace WindowsFormsApp1.Models
{
    class LoginModel : MyModel
    {
        private string username;
        private string password;
        //private OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RentCar.accdb");

        public LoginModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public DataTable getInfo()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from admin where Username='" + username + "' and Password='" + password + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dataTable = new DataTable();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
