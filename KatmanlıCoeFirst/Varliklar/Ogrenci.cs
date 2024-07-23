using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Varliklar
{
    [Table("Ogrenciler")]
    public class Ogrenci
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int ID { get; set; }
        [MaxLength(11)]
       public string KimlikNo { get; set; }
        [MaxLength(11)]
       public string OgrrenciNo { get; set; }
        [MaxLength(100)]
       public string Ad { get; set; }
        [MaxLength(100)]
       public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public byte[] resim { get; set; }
        public short yas { get { return yasHesapla(); } }

        private short yasHesapla()
        {
            DateTime dGunu = DogumTarihi;
            DateTime bugun=DateTime.Now;
            int yas=bugun.Year-dGunu.Year;
            if (dGunu>bugun.AddYears(-yas))
            {
                yas--;
            }
            return (short)yas;
        }

        public Ogrenci()
        {
            
        }

        public Ogrenci(int ID, string kimlikNo, string ogrrenciNo, string ad, string soyad, DateTime dogumTarihi, byte[] resim)
        {
           this.ID = ID;
            KimlikNo = kimlikNo;
            OgrrenciNo = ogrrenciNo;
            Ad = ad;
            Soyad = soyad;
            DogumTarihi = dogumTarihi;
            this.resim = resim;
        }
        public string Kisalt(string uzun)
        {
            string kısa=uzun.Substring(0, 2);
            for (int i = 2;i<uzun.Length;i++)
            {
                kısa += "*";
            }
            return kısa;
        }
        public byte[] ResimToByteDizi(Image gelenResim)
        {
            using (var ms=new MemoryStream())
            {
                Bitmap bmp = new Bitmap(gelenResim);
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public Image ByteDiziToResim(byte[] gelenByteDizi)
        {
            using (var ms=new MemoryStream(gelenByteDizi))
            {
                return Image.FromStream(ms);
            }
        }

    }
   
}
