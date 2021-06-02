using System.Data;
using System.Data.OleDb;


namespace WindowsFormsApp1.Models
{
    class LoginModel : MyModel
    {
       
        private string username;
        private string password;
        private string email;
      
        public string Username { get => username; }
        public string Password { get => password; }
        public string Email { get => email; }

        public LoginModel()
        {

        }

        public LoginModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public LoginModel(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
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

        public override void pullById(int id)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from admin where id=" + id + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dataTable = new DataTable();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.username = dataRow["Username"].ToString();
                this.password = dataRow["Password"].ToString();
                this.email = dataRow["Email"].ToString();

            }
            con.Close();
        }

        public override void update()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("UPDATE admin SET admin.Username = '"+username+"', admin.Email = '"+email+"', admin.[Password] = '"+password+"' WHERE(((admin.ID) = 1));", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
