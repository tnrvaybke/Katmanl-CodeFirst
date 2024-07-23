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
    public partial class Form2 : Form
    {
        private DerslerIslemleri derslerIslemleri;
        private List<Dersler> arayuzlistesi;
        public Form2()
        {
            derslerIslemleri = new DerslerIslemleri();
            arayuzlistesi = new List<Dersler>();
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            yukle();
        }

        private void yukle()
        {
            arayuzlistesi = derslerIslemleri.TamaminiGetir().OrderByDescending(d => d.ID).ToList();
            dataGridView1.DataSource = arayuzlistesi;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Ders Kodu";
            dataGridView1.Columns[2].HeaderText = "Ders Adı";
            dataGridView1.Columns[3].HeaderText = "Akts";

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode== Keys.B)
            {
                if(dataGridView1.Rows.Count==0)
                {
                    Dersler d=new Dersler();
                    d.ID = -1;
                    d.dersKodu = "-1";
                    d.dersAdi = "-1";
                    d.akts = -1;
                    derslerIslemleri.Ekle(d);
                    yukle();
                }
                else if (dataGridView1.Rows[0].Cells[1].Value.ToString()!="-1"&& dataGridView1.Rows[0].Cells[2].Value.ToString() != "-1" &&
                    dataGridView1.Rows[0].Cells[3].Value.ToString() != "-1")
                {
                    Dersler d = new Dersler();
                    d.ID = -1;
                    d.dersKodu = "-1";
                    d.dersAdi = "-1";
                    d.akts = -1;
                    derslerIslemleri.Ekle(d);
                    yukle();
                }
            }
            //else if ((e.Control && e.KeyCode == Keys.Delete) && dataGridView1.SelectedRows.Count > 0)
            //{
            //    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            //    {
            //        Dersler sd = derslerIslemleri.TekilGetir(a => a.ID == Convert.ToInt32(dataGridView1.SelectedRows[i].Cells[0].Value));
            //        derslerIslemleri.sil(sd);
            //    }
            //    yukle();
            //}
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex>-1)
            {
                Dersler gd = derslerIslemleri.TekilGetir(d => d.ID == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                gd.dersKodu = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                gd.dersAdi = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                gd.akts =Convert.ToInt16( dataGridView1.CurrentRow.Cells[3].Value.ToString());
                derslerIslemleri.guncelle(gd);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                yukle();
            }
            else
            {
                List<Dersler> geciciliste= new List<Dersler>();
                geciciliste = derslerIslemleri.Sorgula(d=>d.dersKodu.ToUpper().Contains(textBox1.Text)|| d.dersAdi.ToUpper().Contains(textBox1.Text.ToUpper()));
                dataGridView1.DataSource = geciciliste;
            }
        }
    }
}
