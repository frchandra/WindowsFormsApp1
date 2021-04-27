﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class MemberModel
    {
        private int id;
        private string name;
        private string img_Path;
        private string email;
        private string contact;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RentCar.accdb");

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

        public MemberModel(int id)
        {
            this.id = id;
        }

        public MemberModel()
        {

        }


        public void pull()
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
                name = dataRow["Name"].ToString();
                email = dataRow["Email"].ToString();
                contact = dataRow["Contact"].ToString();
            }

        }

        public void push()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand( "insert into Members_Info(Name, ID_Card, Email, Contact) values('"+ name +"', '"+ img_Path +"', '"+ email + "', '"+ contact +"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void update(string img_Path)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("update Members_Info set Name='" + name + "', ID_Card='" + img_Path + "',  Email='" + email + "', Contact='" + contact + "' where id=" + id + " ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void update()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("update Members_Info set Name='" + name + "', Email='" + email + "', Contact='" + contact + "' where id=" + id + " ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public OleDbCommand getCmd(string def = "select * from Members_Info")
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand(def, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return cmd;
        }
    }
}
