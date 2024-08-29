using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connected
{
    public partial class Form1 : Form
    {
        int currentindex=0;
        private AgentDAL dal = new AgentDAL();
        List<Agent> l;
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {



            Agent agent = new Agent()
            {
                ID = int.Parse(textBox1.Text),
                Name = textBox2.Text.ToString(),
                Mobile = long.Parse(textBox3.Text),

            };
            dal.saveAgent(agent);

            Form1_Load(sender, e);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            l = dal.getAllAgents();
            dataGridView1.DataSource = l;
            navigate(currentindex);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentindex = 0;
            navigate(currentindex); 


        }

        private void navigate(int  index)
        {
            textBox1.Text = l[index].ID.ToString();
            textBox2.Text = l[index].Name.ToString();
            textBox3.Text = l[index].Mobile.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentindex > 0)
            {
                currentindex--;
                navigate(currentindex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentindex < l.Count-1)
            {
                currentindex++;
                navigate(currentindex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentindex = l.Count - 1;
            navigate(currentindex); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;   
            textBox3.Text = string.Empty;   
            textBox1.Focus();   

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(textBox1.Text);
            dal.deleteAgent(ID);

            Form1_Load(sender, e);
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox1.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Agent agent = new Agent()
            {
                ID = int.Parse(textBox1.Text),
                Name = textBox2.Text.ToString(),
                Mobile = long.Parse(textBox3.Text),

            };
            dal.updateAgent(agent);
            Form1_Load(sender, e);
        }
    }
}
