using Islemler;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARAYUZIU
{
    public partial class Form4 : Form
    {
        OgrenciIslemleri oi;
        public Form4()
        {
            oi = new OgrenciIslemleri();
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            RaporYukle();
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

        private void RaporYukle()
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "ARAYUZIU.Report1.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSet1", oi.TamaminiGetir());
            reportViewer1.LocalReport.DataSources.Add(rds);
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
