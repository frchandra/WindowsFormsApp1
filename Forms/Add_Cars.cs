﻿using System;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Add_Cars : Form
    {
        public Add_Cars()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                CarModel carModel = new CarModel(textBox1.Text, textBox2.Text, comboBox1.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox6.Text);
                carModel.push();
                MessageBox.Show("Car Added Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show("Please Fill The Data Carefully ");
                throw;
            }




            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }
    }
}
