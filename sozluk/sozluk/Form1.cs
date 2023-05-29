using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace sozluk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source="+Application.StartupPath+"\\vt_sozluk.accdb");


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbCommand guncellekomutu = new OleDbCommand("update ingturkce set turkce='" + textBox2.Text + "' where ingilizce='" + textBox1.Text + "'",baglantim);
                guncellekomutu.ExecuteNonQuery();
                baglantim.Close();
                MessageBox.Show("Sözcük Veri Tabanında Güncellendi...", "Veri Tabanı İşlemleri");
                textBox1.Clear(); 
                textBox2.Clear(); 
            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Veri tabanı işlemleri");
                baglantim.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbCommand eklekomutu = new OleDbCommand("insert into ingturkce (ingilizce,turkce) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglantim);
                eklekomutu.ExecuteNonQuery();
                baglantim.Close();
                MessageBox.Show("Sözcük Veri Tabanına Eklendi...", "Veri Tabanı işlemleri");
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Veri tabanı işlemleri");
                baglantim.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbCommand silkomutu = new OleDbCommand("delete from ingturkce where ingilizce='" + textBox1.Text + "'", baglantim);
                silkomutu.ExecuteNonQuery();
                baglantim.Close();
                MessageBox.Show("Sözcük Veri Tabanından Silindi...", "Veri Tabanı İşlemleri");
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Veri Tabanı işlemleri");
                baglantim.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                baglantim.Open();
                OleDbCommand aramakomutu = new OleDbCommand("select ingilizce,turkce from ingturkce where ingilizce like'" + textBox1.Text + "%'", baglantim);
                OleDbDataReader oku = aramakomutu.ExecuteReader();
                while (oku.Read())
                {
                    listBox1.Items.Add(oku["ingilizce"].ToString() + "=" + oku["turkce"].ToString());
                }
                baglantim.Close();
            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Veri tabanı işlemleri");
                baglantim.Close();
            }
        }
    }
}
