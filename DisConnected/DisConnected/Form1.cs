using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisConnected
{
    public partial class Form1 : Form
    {
        string CS = ConfigurationManager.ConnectionStrings["Cstring"].ConnectionString;
        MySqlConnection conn;
        MySqlDataAdapter DA;
        DataSet DS;
        MySqlCommandBuilder CB;
        int CurrentIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(CS);
            DA = new MySqlDataAdapter("select * from _emp", conn);
            CB = new MySqlCommandBuilder(DA);
            DS = new DataSet();
            DA.Fill(DS,"_emp");
            Navigate(CurrentIndex);
        }
        private void Navigate(int index)
        {
            textBox1.Text = DS.Tables[0].Rows[index][0].ToString();
            textBox2.Text = DS.Tables[0].Rows[index][1].ToString();
            textBox3.Text = DS.Tables[0].Rows[index][2].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CurrentIndex = DS.Tables[0].Rows.Count-1;
            Navigate(CurrentIndex);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentIndex = 0;
            Navigate(CurrentIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CurrentIndex > 0)
            {
                CurrentIndex--;
                Navigate(CurrentIndex);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CurrentIndex < DS.Tables[0].Rows.Count - 1)
            {
                CurrentIndex++;
                Navigate(CurrentIndex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataRow row= DS.Tables[0].NewRow();
            row[1]= textBox2.Text;
            row[2]= textBox3.Text;
            DS.Tables[0].Rows.Add(row);
            DA.Update(DS.Tables[0]);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            DataRow row = DS.Tables[0].Rows[CurrentIndex];
            row[1] = textBox2.Text;
            row[2] = textBox3.Text;
            DA.Update(DS.Tables[0]);
            MessageBox.Show("Update Succesfully...");
            button8_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DS.Tables[0].Rows[CurrentIndex].Delete();
            DA.Update(DS.Tables[0]);
        }
    }
}
