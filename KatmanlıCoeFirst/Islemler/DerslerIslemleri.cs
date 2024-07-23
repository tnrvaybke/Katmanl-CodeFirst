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
    public class DerslerIslemleri : VTIslemlerI<Dersler>
    {
        private DerslerDAL DerslerDAL;
        public DerslerIslemleri()
        {
            if (DerslerDAL==null)
            {
                DerslerDAL = new DerslerDAL();
            }
        }
        public void Ekle(Dersler kayit)
        {
            DerslerDAL.Ekle(kayit);
        }

        public void guncelle(Dersler kayit)
        {
            DerslerDAL.guncelle(kayit);
        }

        public void sil(Dersler kayit)
        {
            DerslerDAL.sil(kayit);
        }

        public List<Dersler> Sorgula(Func<Dersler, bool> filtre)
        {
          return  DerslerDAL.Sorgula(filtre);
        }

        public List<Dersler> TamaminiGetir()
        {
            return DerslerDAL.TamaminiGetir();
        }

        public Dersler TekilGetir(Func<Dersler, bool> filtre)
        {
           return DerslerDAL.TekilGetir(filtre);
        }

        public Dersler TekilGetir(int ID)
        {
           return DerslerDAL.TekilGetir(ID);
        }

        public void TopluEkle(List<Dersler> eklenecekliste)
        {
            DerslerDAL.TopluEkle(eklenecekliste);
        }

        public void TopluSil(List<Dersler> silinecekliste)
        {
            DerslerDAL.TopluSil(silinecekliste);
        }
    }
}
