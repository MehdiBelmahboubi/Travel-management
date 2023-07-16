﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace App_voyage_projet
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1L0PT5EA;Initial Catalog=Application_Voyage;Integrated Security=True");

        private void Client_Load(object sender, EventArgs e)
        {
            con.Open();
            this.dataGridView1.Rows.Clear();
            this.comboBox1.Items.Clear();
            this.comboBox2.Items.Clear();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.ColumnCount = 10;
            this.dataGridView1.Columns[0].Name = "Identity";
            this.dataGridView1.Columns[1].Name = "Nom";
            this.dataGridView1.Columns[2].Name = "Prenom";
            this.dataGridView1.Columns[3].Name = "CIN";
            this.dataGridView1.Columns[4].Name = "Telphone";
            this.dataGridView1.Columns[5].Name = "Mot de passe";
            this.dataGridView1.Columns[6].Name = "Date de naissance";
            this.dataGridView1.Columns[7].Name = "Age";
            this.dataGridView1.Columns[8].Name = "Identity agence";
            this.dataGridView1.Columns[9].Name = "Numero voyage";
            SqlCommand cmd = new SqlCommand("select * from Client;", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9]);
                this.comboBox1.Items.Add(dr[8]);
                this.comboBox2.Items.Add(dr[9]);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Recherche_Click(object sender, EventArgs e)
        {
            rech(int.Parse(textBox1.Text));
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Client where Id_Client=@id;", con);
            cmd.Parameters.AddWithValue("@id",int.Parse(textBox1.Text));
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
            SqlCommand cmd = new SqlCommand("update Client set Nom=@nom,Prenom=@pr,CIN=@cin,Tel_Client=@tel,Motdepasse=@mdp,Date_Naissance=@dtn,Id_Agence=@idag,Num_Voyage=@num,imagec=@img where Id_Client=@id;", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@nom",textBox2.Text);
            cmd.Parameters.AddWithValue("@pr", textBox3.Text);
            cmd.Parameters.AddWithValue("@cin", textBox4.Text);
            cmd.Parameters.AddWithValue("@tel", textBox5.Text);
            cmd.Parameters.AddWithValue("@mdp", textBox6.Text);
            cmd.Parameters.AddWithValue("@dtn", textBox7.Text);
            cmd.Parameters.AddWithValue("@idag",int.Parse(comboBox1.Text));
            cmd.Parameters.AddWithValue("@num", int.Parse(comboBox2.Text));
            cmd.Parameters.AddWithValue("@img", textBox11.Text);

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
            SqlCommand cmd = new SqlCommand("insert into Client values(@id,@nom,@pr,@cin,@tel,@mdp,@dtn,@idag,@num,@img);", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@nom", textBox2.Text);
            cmd.Parameters.AddWithValue("@pr", textBox3.Text);
            cmd.Parameters.AddWithValue("@cin", textBox4.Text);
            cmd.Parameters.AddWithValue("@tel", textBox5.Text);
            cmd.Parameters.AddWithValue("@mdp", textBox6.Text);
            cmd.Parameters.AddWithValue("@dtn", textBox7.Text);
            cmd.Parameters.AddWithValue("@idag", int.Parse(comboBox1.Text));
            cmd.Parameters.AddWithValue("@num", int.Parse(comboBox2.Text));
            cmd.Parameters.AddWithValue("@img", textBox11.Text);
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
            this.textBox6.Clear();
            this.textBox7.Clear();
            this.textBox8.Clear();
            this.textBox11.Clear();
        }
        public void rech(int a)
        {
            SqlCommand cmd = new SqlCommand("select * from Client where Id_Client=" + a + ";", con);
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
                    this.textBox7.Text = dr[6].ToString();
                    this.textBox8.Text = dr[7].ToString();
                    this.comboBox1.Text = dr[8].ToString();
                    this.comboBox2.Text = dr[9].ToString();
                    this.textBox11.Text = dr[10].ToString();
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
            int IDclient = int.Parse(this.dataGridView1.Rows[position].Cells[0].Value.ToString());
            rech(IDclient);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Client;",con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                this.textBox1.Text = dr[0].ToString();
                this.textBox2.Text = dr[1].ToString();
                this.textBox3.Text = dr[2].ToString();
                this.textBox4.Text = dr[3].ToString();
                this.textBox5.Text = dr[4].ToString();
                this.textBox6.Text = dr[5].ToString();
                this.textBox7.Text = dr[6].ToString();
                this.textBox8.Text = dr[7].ToString();
                this.comboBox1.Text = dr[8].ToString();
                this.comboBox2.Text = dr[9].ToString();
                this.textBox11.Text = dr[10].ToString();
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Client;", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.textBox1.Text = dr[0].ToString();
                this.textBox2.Text = dr[1].ToString();
                this.textBox3.Text = dr[2].ToString();
                this.textBox4.Text = dr[3].ToString();
                this.textBox5.Text = dr[4].ToString();
                this.textBox6.Text = dr[5].ToString();
                this.textBox7.Text = dr[6].ToString();
                this.textBox8.Text = dr[7].ToString();
                this.comboBox1.Text = dr[8].ToString();
                this.comboBox2.Text = dr[9].ToString();
                this.textBox11.Text = dr[10].ToString();
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Client where Id_Client < @id;", con);
            cmd.Parameters.AddWithValue("@id",int.Parse(textBox1.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.textBox1.Text = dr[0].ToString();
                this.textBox2.Text = dr[1].ToString();
                this.textBox3.Text = dr[2].ToString();
                this.textBox4.Text = dr[3].ToString();
                this.textBox5.Text = dr[4].ToString();
                this.textBox6.Text = dr[5].ToString();
                this.textBox7.Text = dr[6].ToString();
                this.textBox8.Text = dr[7].ToString();
                this.comboBox1.Text = dr[8].ToString();
                this.comboBox2.Text = dr[9].ToString();
                this.textBox11.Text = dr[10].ToString();
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Client where Id_Client > @id;", con);
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
                this.textBox7.Text = dr[6].ToString();
                this.textBox8.Text = dr[7].ToString();
                this.comboBox1.Text = dr[8].ToString();
                this.comboBox2.Text = dr[9].ToString();
                this.textBox11.Text = dr[10].ToString();
            }
            con.Close();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Load(@"image\" +textBox11.Text);
            }
            catch
            {
                pictureBox1.Load(@"image\vide.jpg");
            }
        }

        private void textBox11_MouseClick(object sender, MouseEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(openFileDialog1.FileName);
                string nomPhoto = donnerNomChe() + extension;
                File.Copy(openFileDialog1.FileName, "image/" + nomPhoto);
                textBox11.Text = nomPhoto;
            }
        }
        private string donnerNomChe()
        {
            string nomche;
            //  Random r = new Random();
            //Méthode 1 nom = Convert.ToInt64(r.Next() * 10000).ToString();
            //Méthode 2
            nomche = DateTime.Now.ToString("ddMMyyyyhhmmss");
            return nomche;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Client", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            ds.Tables.Add("Client");
            ds.Tables["Client"].Load(sdr);
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
