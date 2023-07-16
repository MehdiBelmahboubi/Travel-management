using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace App_voyage_projet
{
    public partial class connexion : Form
    {
        public connexion()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1L0PT5EA;Initial Catalog=Application_Voyage;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Employer where CIN_emp=@cin and passE=@mdp;", con);
            cmd.Parameters.AddWithValue("@cin",textBox1.Text);
            cmd.Parameters.AddWithValue("@mdp", textBox2.Text);
            con.Open();
            SqlDataReader dr =  cmd.ExecuteReader();
            if(dr.Read())
            {
                Form1 f = new Form1();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                label7.Visible = true;
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control; 
            panel4.BackColor = Color.White;
            textBox2.BackColor = Color.White;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void connexion_Load(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
             
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void textBox2_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
