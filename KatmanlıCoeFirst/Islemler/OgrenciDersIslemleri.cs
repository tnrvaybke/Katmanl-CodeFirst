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
    public class OgrenciDersIslemleri : VTIslemlerI<OgrenciDers>
    {
        private OgrenciDersDAL OgrenciDersDAL;
        public OgrenciDersIslemleri()
        {
            if (OgrenciDersDAL==null)
            {
                OgrenciDersDAL = new OgrenciDersDAL();
            }
        }
        public void Ekle(OgrenciDers kayit)
        {
            OgrenciDersDAL.Ekle(kayit);
        }

        public void guncelle(OgrenciDers kayit)
        {
            OgrenciDersDAL.guncelle(kayit);
        }

       

        public void sil(OgrenciDers kayit)
        {
            OgrenciDersDAL.sil(kayit);
        }

        public List<OgrenciDers> Sorgula(Func<OgrenciDers, bool> filtre)
        {
          return  OgrenciDersDAL.Sorgula(filtre);
        }

        public List<OgrenciDers> TamaminiGetir()
        {
            return OgrenciDersDAL.TamaminiGetir();
        }

        public OgrenciDers TekilGetir(Func<OgrenciDers, bool> filtre)
        {
           return OgrenciDersDAL.TekilGetir(filtre);
        }

        public OgrenciDers TekilGetir(int ID)
        {
           return OgrenciDersDAL.TekilGetir(ID);
        }

        public void TopluEkle(List<OgrenciDers> eklenecekliste)
        {
            OgrenciDersDAL.TopluEkle(eklenecekliste);
        }

        public void TopluSil(List<OgrenciDers> silinecekliste)
        {
            OgrenciDersDAL.TopluSil(silinecekliste);
        }
    }
}
