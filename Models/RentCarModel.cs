﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class RentCarModel
    {
        private int id;
        private int member_Id;
        private int car_Id;
        private string rent_Date;
        private string return_Date;
        private string total_Price;
        private bool is_Returned;
        private OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RentCar.accdb");

        public int Id { get => id; }
        public int Member_Id { get => member_Id; }
        public int Car_Id { get => car_Id; }
        public string Rent_Date { get => rent_Date; }
        public string Return_Date { get => return_Date; }
        public string Total_Price { get => total_Price; }
        public bool Is_Returned { get => is_Returned; }


        public RentCarModel(int member_Id, int car_Id, string rent_Date, string return_Date, string total_Price, bool is_Returned)
        {            
            this.member_Id = member_Id;
            this.car_Id = car_Id;
            this.rent_Date = rent_Date;
            this.return_Date = return_Date;
            this.total_Price = total_Price;
            this.is_Returned = is_Returned;
        }

        public void push()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand(" INSERT INTO Rent_Car (MemberID, CarID, Rent_Date, Return_Date, Total_Price, Is_Returned) VALUES ('" + member_Id + "', '" + car_Id + "', '" + rent_Date + "', '" + return_Date + "', '" + total_Price + "', '" + Convert.ToByte(is_Returned) + "') ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
