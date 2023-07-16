using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_voyage_projet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0) 
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadform(new Client());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadform(new Employer());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new Agence());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadform(new Voyage());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadform(new Hotel());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadform(new Transport());
        }

        bool sidebarexpand;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(sidebarexpand)
            {
                sidebar.Width -= 10;
                if(sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarexpand = false;
                    timer1.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if(sidebar.Width==sidebar.MaximumSize.Width)
                {
                    sidebarexpand = true;
                    timer1.Stop();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
