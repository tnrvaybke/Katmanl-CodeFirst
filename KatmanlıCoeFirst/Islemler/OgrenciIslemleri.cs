using InterFaceler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar;
using VeriBaglantisi;

namespace Islemler
{
    public class OgrenciIslemleri : VTIslemlerI<Ogrenci>
    {
        private OgrenciDAL ogrenciDAL;
        public OgrenciIslemleri()
        {
            if (ogrenciDAL==null)
            {
                ogrenciDAL = new OgrenciDAL();
            }
        }
        public void Ekle(Ogrenci kayit)
        {
            ogrenciDAL.Ekle(kayit);
        }

        public void guncelle(Ogrenci kayit)
        {
            ogrenciDAL.guncelle(kayit);
        }

        public void sil(Ogrenci kayit)
        {
           ogrenciDAL.sil(kayit);
        }

        public List<Ogrenci> Sorgula(Func<Ogrenci, bool> filtre)
        {
          return  ogrenciDAL.Sorgula(filtre);
        }

        public List<Ogrenci> TamaminiGetir()
        {
            return ogrenciDAL.TamaminiGetir();
        }

        public Ogrenci TekilGetir(Func<Ogrenci, bool> filtre)
        {
           return ogrenciDAL.TekilGetir(filtre);
        }

        public Ogrenci TekilGetir(int ID)
        {
           return ogrenciDAL.TekilGetir(ID);
        }

        public void TopluEkle(List<Ogrenci> eklenecekliste)
        {
            ogrenciDAL.TopluEkle(eklenecekliste);
        }

        public void TopluSil(List<Ogrenci> silinecekliste)
        {
            ogrenciDAL.TopluSil(silinecekliste);
        }
    }
}
