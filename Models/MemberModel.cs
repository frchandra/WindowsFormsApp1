using System;
using System.Data;
using System.Data.OleDb;


namespace WindowsFormsApp1.Models
{
    class MemberModel : MyModel
    {
        private int id;
        private string name;
        private string img_Path;
        private string email;
        private string contact;
       

        public int Id { get => id; }
        public string Name { get => name; }
        public string Img_Path { get => img_Path; }
        public string Email { get => email; }
        public string Contact { get => contact; }
        

        public MemberModel(int id, string name, string email, string contact)
        {
            this.id = id;
            this.name = name;            
            this.email = email;
            this.contact = contact;
        }
        public MemberModel(string name, string img_Path, string email, string contact)
        {
            this.name = name;
            this.img_Path = img_Path;
            this.email = email;
            this.contact = contact;
        }
        public MemberModel()
        {

        }


        public override void pullById(int id)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Members_Info where id = "+ id +" ", con);
            cmd.ExecuteNonQuery();
            con.Close();

            DataTable dataTable = new DataTable();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.id = Convert.ToInt32(dataRow["ID"]);
                name = dataRow["Name"].ToString();
                email = dataRow["Email"].ToString();
                contact = dataRow["Contact"].ToString();
            }
        }
        public void pullByNEC(string name, string email, string contact)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Members_Info where Name='" + name + "' AND Email='" + email + "' AND Contact='" + contact + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();

            DataTable dataTable = new DataTable();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.id = Convert.ToInt32(dataRow["ID"]);
                this.name = dataRow["Name"].ToString();
                this.email = dataRow["Email"].ToString();
                this.contact = dataRow["Contact"].ToString();
            }
        }
        public override void push()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Members_Info(Name, ID_Card, Email, Contact) values('" + name + "', '" + img_Path + "', '" + email + "', '" + contact + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public int searchByName(string name)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Members_Info where Name='"+ name +"' ", con);
            cmd.ExecuteNonQuery();
            con.Close();

            DataTable dataTable = new DataTable();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.name = dataRow["Name"].ToString();
                email = dataRow["Email"].ToString();
                contact = dataRow["Contact"].ToString();
            }
            int i = Convert.ToInt32(dataTable.Rows.Count.ToString());
            return i;
        }

        public void update(string img_Path)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("update Members_Info set Name='" + name + "', ID_Card='" + img_Path + "',  Email='" + email + "', Contact='" + contact + "' where id=" + id + " ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void update()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("update Members_Info set Name='" + name + "', Email='" + email + "', Contact='" + contact + "' where id=" + id + " ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override void deleteById(int id)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("delete from Members_Info  where id=" + id + " ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int getIdbyName(string name)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Members_Info where Name = '" + name + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();

            DataTable dataTable = new DataTable();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            dataAdapter.Fill(dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                id = Convert.ToInt32(dataRow["ID"]);
            }
            return id;
        }

        public DataTable getCmd(string def = "select * from Members_Info")
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand(def, con);
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dataTable = new DataTable();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            return dataTable;            
        }
    }
}
