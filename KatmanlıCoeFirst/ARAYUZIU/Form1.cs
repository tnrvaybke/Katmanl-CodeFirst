using Islemler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Varliklar;

namespace ARAYUZIU
{
    public partial class Form1 : Form
    {
        OgrenciIslemleri oi;
        List<Ogrenci> al;
        public Form1()
        {
            if (al == null)al = new List<Ogrenci>();
            if (oi == null) oi = new OgrenciIslemleri();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            yukle();
            
        }

        private void parcala()
        {
          if (dataGridView1.CurrentRow.Index>-1)
            {
                Ogrenci o = oi.TekilGetir(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                label2.Text = o.ID.ToString(); //dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = o.KimlikNo;//dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = o.OgrrenciNo;//dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = o.Ad;//dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = o.Soyad;//dataGridView1.CurrentRow.Cells[4].Value.ToString();
                dateTimePicker1.Value = o.DogumTarihi;//Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value);
                pictureBox1.Image = o.ByteDiziToResim(o.resim);
                numericUpDown1.Value = yasHesapla(o.DogumTarihi);
            }
            else
            {
                MessageBox.Show("Kayıt Seçiniz");
            }
        }

        private void yukle()
        {
            al = oi.TamaminiGetir().OrderByDescending(o => o.ID).ToList();
            ArayuzListesiYildizla(al);
            dataGridView1.DataSource = al;
            dataGridView1.Columns[0].Visible = false;
            ResimSutunAyarla();
        }

        private void ArayuzListesiYildizla(List<Ogrenci> liste)
        {
            foreach (Ogrenci ogrenci in liste)
            {
                ogrenci.KimlikNo = ogrenci.Kisalt(ogrenci.KimlikNo);
                ogrenci.OgrrenciNo = ogrenci.Kisalt(ogrenci.OgrrenciNo);
                ogrenci.Ad = ogrenci.Kisalt(ogrenci.Ad);
                ogrenci.Soyad = ogrenci.Kisalt(ogrenci.Soyad);
            }
        }
        void temizle()
        {
            label2.Text = "-1";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.Value =DateTime.Today;
            numericUpDown1.Value = 0;
            pictureBox1.Image = null;
        }
        void ArayuzdenVeriYukle()
        {
            dataGridView1.DataSource = null;
            ArayuzListesiYildizla(al);
            dataGridView1.DataSource = al;
            ResimSutunAyarla();
        }
       
        void ResimSutunAyarla()
        {
            dataGridView1.Columns[0].Visible=false;
            dataGridView1.Columns[6].Visible = false;
            DataGridViewImageColumn rs=new DataGridViewImageColumn();
            rs.Width=200;
            rs.HeaderText = "Resim";
            rs.DataPropertyName = "resim";
            rs.ImageLayout=DataGridViewImageCellLayout.Stretch;
            rs.ReadOnly=true;
            dataGridView1.Columns.Insert(6,rs);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ogrenci o=new Ogrenci();
            o.KimlikNo=textBox1.Text;
            o.OgrrenciNo=textBox2.Text;
            o.Ad=textBox3.Text;
            o.Soyad=textBox4.Text;
            o.DogumTarihi=dateTimePicker1.Value;
            o.resim=o.ResimToByteDizi(pictureBox1.Image);
            oi.Ekle(o);
            al.Add(o);
            ArayuzdenVeriYukle();
            temizle();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Today>=dateTimePicker1.Value)
            {
                numericUpDown1.Value = yasHesapla(dateTimePicker1.Value);
            }
        }

        private decimal yasHesapla(DateTime tarih)
        {
            DateTime dGunu = tarih;
            DateTime bugun = DateTime.Now;
            int yas = bugun.Year - dGunu.Year;
            if (dGunu > bugun.AddYears(-yas))
            {
                yas--;
            }
            return (sbyte)yas;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            parcala();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label2.Text!="-1")
            {
                Ogrenci so = al.Where(o => o.ID == Convert.ToInt32(label2.Text)).FirstOrDefault();
                if (so != null)
                {
                    oi.sil(so);
                    al.Remove(so);
                    ArayuzdenVeriYukle();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Silinecek Öğrenciyi Seçiniz");
                }
            }
            else
            {
                MessageBox.Show("Kayıt Seçiniz");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length==0)
            {
                yukle();
            }
            else 
            { 
                List<Ogrenci> gl = oi.Sorgula(o=>o.KimlikNo.Contains(textBox5.Text)|| o.OgrrenciNo.Contains(textBox5.Text)||
                o.Ad.ToLower().Contains(textBox5.Text.ToLower())|| o.Soyad.Contains(textBox5.Text.ToLower()));
                ArayuzListesiYildizla(gl);
                dataGridView1.DataSource = gl;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label2.Text!="-1"&&(textBox1.Text.IndexOf("*")==-1|| textBox2.Text.IndexOf("*") == -1 || 
                textBox3.Text.IndexOf("*") == -1 || textBox4.Text.IndexOf("*") == -1))
            {
                Ogrenci go=al.Where(o=>o.ID==Convert.ToInt32(label2.Text)).FirstOrDefault();
                if (go!=null)
                {
                    go.KimlikNo = textBox1.Text;
                    go.OgrrenciNo = textBox2.Text;
                    go.Ad = textBox3.Text;
                    go.Soyad = textBox4.Text;
                    go.DogumTarihi = dateTimePicker1.Value;
                    go.resim = go.ResimToByteDizi(pictureBox1.Image);
                    oi.guncelle(go);
                    ArayuzdenVeriYukle();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Güncellenecek Öğrenciyi Seçiniz");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f= new Form2();
            f.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 fd= new Form3();
            fd.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 fü = new Form4();
            fü.ShowDialog();
        }
    }
}
