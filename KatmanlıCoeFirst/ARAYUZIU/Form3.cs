using Islemler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Varliklar;

namespace ARAYUZIU
{
    public partial class Form3 : Form
    {
        DerslerIslemleri di;
        OgrenciIslemleri oi;
        OgrenciDersIslemleri odi;
        public Form3()
        {
            di = new DerslerIslemleri();
            oi = new OgrenciIslemleri();
            odi = new OgrenciDersIslemleri();
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ogrenciyukle();
            dersyukle();
            ogrencidersyukle();
        }

        private void ogrencidersyukle()
        {
            dataGridView3.DataSource = odi.TamaminiGetir().Select(x =>
          new
          {
              x.ID,
              DersID=x.ID,
              OGRID=x.OgrenciID,
              x.Ogrenci.OgrrenciNo,
              x.Ogrenci.Ad,
              x.Ogrenci.Soyad,
              x.Ogrenci.KimlikNo,
              x.Dersler.dersKodu,
              x.Dersler.dersAdi
             

          }).ToList();
            for (int i = 0;i<3;i++)
            {
                dataGridView3.Columns[i].Visible = false;
            }
           
        }

        private void dersyukle()
        {
            dataGridView2.DataSource = di.TamaminiGetir().Select(d =>
           new
           {
               d.ID,
               d.dersKodu,
               d.dersAdi
               
           }).ToList();
            dataGridView2.Columns[0].Visible = false;
        }

        private void ogrenciyukle()
        {
            dataGridView1.DataSource = oi.TamaminiGetir().Select(o=>
            new
            {
                o.ID,
                o.OgrrenciNo,
                o.KimlikNo,
                o.Ad,
                o.Soyad
            }).ToList();
            dataGridView1.Columns[0].Visible = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = oi.TamaminiGetir().Select(o =>
           new
           {
               o.ID,
               o.OgrrenciNo,
               o.KimlikNo,
               o.Ad,
               o.Soyad
           }).Where(o=>o.KimlikNo.Contains(textBox1.Text)||o.OgrrenciNo.Contains(textBox1.Text)||o.Ad.ToLower().Contains(textBox1.Text)
           ||o.Soyad.ToLower().Contains(textBox1.Text)).ToList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = di.TamaminiGetir().Select(d =>
          new
          {
              d.ID,
              d.dersKodu,
              d.dersAdi

          }).Where(d=>d.dersKodu.ToLower().Contains(textBox2.Text)||d.dersAdi.ToLower().Contains(textBox2.Text)).ToList();
            dataGridView2.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index>-1&&dataGridView2.SelectedRows.Count>0)
            {
                int oID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                OgrenciDers od=new OgrenciDers();
                od.OgrenciID = oID;
                foreach (DataGridViewRow item in dataGridView2.SelectedRows)
                {
                    int dID = Convert.ToInt32(item.Cells[0].Value);
                    od.DersID = dID;
                    OgrenciDers varMİ= odi.Sorgula(x=>x.DersID==dID&&x.OgrenciID==oID).FirstOrDefault();
                    if (varMİ!=null)
                    {
                        MessageBox.Show("Aynı Kayıt Olduğundan Eklenemedi");
                        continue;
                    }
                    odi.Ekle(od);
                }
                ogrencidersyukle();
            }
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.Delete) && dataGridView3.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridView3.SelectedRows.Count; i++)
                {
                    OgrenciDers od = odi.TekilGetir(ods => ods.ID == Convert.ToInt32(dataGridView3.SelectedRows[i].Cells[0].Value));
                    odi.sil(od);
                }
                ogrencidersyukle();

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView3.DataSource = odi.TamaminiGetir().Select(x =>
            new
            {
                x.ID,
                DersID = x.ID,
                OGRID = x.OgrenciID,
                x.Ogrenci.OgrrenciNo,
                x.Ogrenci.Ad,
                x.Ogrenci.Soyad,
                x.Ogrenci.KimlikNo,
                x.Dersler.dersKodu,
                x.Dersler.dersAdi


            }).Where(x => x.OgrrenciNo.Contains(textBox3.Text) || x.KimlikNo.Contains(textBox3.Text) || x.Ad.ToLower().Contains(textBox3.Text)
            || x.Soyad.ToLower().Contains(textBox3.Text) || x.dersKodu.ToLower().Contains(textBox3.Text) || x.dersAdi.ToLower().Contains(textBox3.Text)).ToList();
            for (int i = 0; i < 3; i++)
            {
                dataGridView3.Columns[i].Visible = false;
            }
        }
    }
}
