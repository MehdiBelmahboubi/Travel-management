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
    public partial class Transport : Form
    {
        public Transport()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1L0PT5EA;Initial Catalog=Application_Voyage;Integrated Security=True");

        private void Recherche_Click(object sender, EventArgs e)
        {
            rech(int.Parse(textBox1.Text));
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Transport where Id_Transport=@id;", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            con.Open();
            int i = cmd.ExecuteNonQuery();
            try
            {
                if (i != 0)
                {
                    MessageBox.Show("Supression valide.");
                }
                else
                {
                    MessageBox.Show("Problem au niveau de supression !!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            button1_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Transport set Adress_Depart=@add,Adress_Arriver=@ada,Date_Depart=@date,Type_Transport=@typ, Prix_Transport =@pr where Id_Hotel=@id;", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@add", textBox2.Text);
            cmd.Parameters.AddWithValue("@ada", textBox3.Text);
            cmd.Parameters.AddWithValue("@date", textBox4.Text);
            cmd.Parameters.AddWithValue("@typ", textBox5.Text);
            cmd.Parameters.AddWithValue("@pr", textBox6.Text);
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Modification valide.");
                }
                else
                {
                    MessageBox.Show("Problem au niveau de modification !!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            button1_Click(sender, e);
        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Transport values(@id,@add,@ada,@date,@typ,@pr);", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@add", textBox2.Text);
            cmd.Parameters.AddWithValue("@ada", textBox3.Text);
            cmd.Parameters.AddWithValue("@date", textBox4.Text);
            cmd.Parameters.AddWithValue("@typ", textBox5.Text);
            cmd.Parameters.AddWithValue("@pr", textBox6.Text);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            try
            {
                if (i != 0)
                {
                    MessageBox.Show("Insertion valide.");
                }
                else
                {
                    MessageBox.Show("Problem au niveau d'insertion !!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            button1_Click(sender, e);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void rech(int a)
        {
            SqlCommand cmd = new SqlCommand("select * from Transport where Id_Transport=" + a + ";", con);
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read() == true)
                {
                    this.textBox1.Text = dr[0].ToString();
                    this.textBox2.Text = dr[1].ToString();
                    this.textBox3.Text = dr[2].ToString();
                    this.textBox4.Text = dr[3].ToString();
                    this.textBox5.Text = dr[4].ToString();
                    this.textBox6.Text = dr[5].ToString();
                }
                else
                {
                    MessageBox.Show("Problem de recherche!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int position = this.dataGridView1.CurrentRow.Index;
            int IDvoy = int.Parse(this.dataGridView1.Rows[position].Cells[0].Value.ToString());
            rech(IDvoy);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Transport;", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox1.Text = dr[0].ToString();
                this.textBox2.Text = dr[1].ToString();
                this.textBox3.Text = dr[2].ToString();
                this.textBox4.Text = dr[3].ToString();
                this.textBox5.Text = dr[4].ToString();
                this.textBox6.Text = dr[5].ToString();

            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Transport;", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.textBox1.Text = dr[0].ToString();
                this.textBox2.Text = dr[1].ToString();
                this.textBox3.Text = dr[2].ToString();
                this.textBox4.Text = dr[3].ToString();
                this.textBox5.Text = dr[4].ToString();
                this.textBox6.Text = dr[5].ToString();
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Transport where Id_Transport<@id;", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.textBox1.Text = dr[0].ToString();
                this.textBox2.Text = dr[1].ToString();
                this.textBox3.Text = dr[2].ToString();
                this.textBox4.Text = dr[3].ToString();
                this.textBox5.Text = dr[4].ToString();
                this.textBox6.Text = dr[5].ToString();
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Transport where Id_Transport>@id;", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox1.Text = dr[0].ToString();
                this.textBox2.Text = dr[1].ToString();
                this.textBox3.Text = dr[2].ToString();
                this.textBox4.Text = dr[3].ToString();
                this.textBox5.Text = dr[4].ToString();
                this.textBox6.Text = dr[5].ToString();
            }
            con.Close();
        }

        private void Transport_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.ColumnCount = 6;
            this.dataGridView1.Columns[0].Name = "Identity";
            this.dataGridView1.Columns[1].Name = "Adress Depart";
            this.dataGridView1.Columns[2].Name = "Adress Arriver";
            this.dataGridView1.Columns[3].Name = "Date Depart";
            this.dataGridView1.Columns[4].Name = "Type Transport";
            this.dataGridView1.Columns[5].Name = "Prix Transport";
            SqlCommand cmd = new SqlCommand("select * from Transport;", con);
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Transport", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            ds.Tables.Add("Transport");
            ds.Tables["Transport"].Load(sdr);
            string chm = "";
            saveFileDialog1.Filter = "XML FILES |*.xml";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                chm = saveFileDialog1.FileName + ".xml";
            }
            ds.WriteXml(chm);
            MessageBox.Show("Création fichier XML est terminée !");
            sdr.Close();
            sdr = null;
            cmd = null;
            con.Close();
        }
    }
}
