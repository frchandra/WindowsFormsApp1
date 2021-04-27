﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class CarModel
    {
        private int id;
        private string brand;
        private string model;
        private string transmision;
        private int price;
        private int max_Passenger;
        private int quantity;
        private int available_Quantity;
        private OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RentCar.accdb");

        public int Id { get { return id; } }
        public string Brand { get { return brand; } }
        public string Model { get { return model; } }
        public string Transmision { get { return transmision; } }
        public int Price { get { return price; } }
        public int Max_Passenger { get { return max_Passenger; } }
        public int Quantity { get { return quantity; } }
        public int Available_Quantity { get { return available_Quantity; } }

        public CarModel(string brand, string model, string transmision, string max_Passenger, string price, string quantity, string available_Quantity)
        {
            this.brand = brand;
            this.model = model;
            this.transmision = transmision;
            this.price = Convert.ToInt32(price);
            this.max_Passenger = Convert.ToInt32(max_Passenger);
            this.quantity = Convert.ToInt32(quantity);
            this.available_Quantity = Convert.ToInt32(available_Quantity);
        }

        public CarModel(int id, string brand, string model, string transmision, string max_Passenger, string price, string quantity)
        {
            this.id = id;
            this.brand = brand;
            this.model = model;
            this.transmision = transmision;
            this.price = Convert.ToInt32(price);
            this.max_Passenger = Convert.ToInt32(max_Passenger);
            this.quantity = Convert.ToInt32(quantity);
        }

        public CarModel(string brand, string model)
        {
            this.brand = brand;
            this.model = model;
        }

        public CarModel(int id)
        {
            this.id = id;
        }


        public void push()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand(" INSERT INTO Cars_Info (Brand, Model, Transmision, Max_Passenger, Price, Quantity, Available_Quantity) VALUES ('" + brand + "', '" + model + "', '" + transmision + "', '" + max_Passenger + "', '" + price + "', '" + quantity + "', '" + available_Quantity + "') ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void pull()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Cars_Info where id=" + this.id + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dataTable = new DataTable();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            
            foreach (DataRow dataRow in dataTable.Rows)
            {
                brand = dataRow["Brand"].ToString();
                model = dataRow["Model"].ToString();
                transmision = dataRow["Transmision"].ToString();
                max_Passenger = Convert.ToInt32(dataRow["Max_Passenger"].ToString()) ;
                price = Convert.ToInt32(dataRow["Price"].ToString());
                quantity = Convert.ToInt32(dataRow["Quantity"].ToString());


            }
        }

        public void update()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("update Cars_Info set Brand='" + brand + "', Model='" + model + "', Transmision='" + transmision + "', Max_Passenger='" + max_Passenger + "', Price='" + price + "', Quantity='" + quantity + "' where id=" + id + "    ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public OleDbCommand search()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Cars_Info where Brand like('%" + brand + "%') or Model like('%" + model + "%') ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return cmd;

        }







    }
}
