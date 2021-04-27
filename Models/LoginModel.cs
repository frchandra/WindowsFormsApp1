using System;
using System.Collections.Generic;
using System.Data.OleDb;


namespace WindowsFormsApp1.Models
{
    class LoginModel
    {
        private string username;
        private string password;
        private OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RentCar.accdb");

        public LoginModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public OleDbCommand pull()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from admin where Username='" + username + "' and Password='" + password + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return cmd;
        }

      
        

    }
}
