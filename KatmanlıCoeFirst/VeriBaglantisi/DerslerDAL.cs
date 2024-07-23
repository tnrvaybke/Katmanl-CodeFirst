using InterFaceler;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar;

namespace VeriBaglantisi
{
    public class DerslerDAL : VTIslemlerI<Dersler>
    {
        public void Ekle(Dersler kayit)
        {
            using (VeriTabaniContext vt=new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Added;
                vt.SaveChanges();
            }
        }

        public void guncelle(Dersler kayit)
        {
           using(VeriTabaniContext vt= new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Modified;
                vt.SaveChanges();
            }
        }

       

        public void sil(Dersler kayit)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Deleted;
                vt.SaveChanges();
            }
        }

        public List<Dersler> Sorgula(Func<Dersler, bool> filtre)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
               return filtre== null ? vt.Set<Dersler>().ToList():
                    vt.Set<Dersler>().Where(filtre).ToList();
            }
        }

        public List<Dersler> TamaminiGetir()
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<Dersler>().ToList();
            }
        }

        public Dersler TekilGetir(Func<Dersler, bool> filtre)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<Dersler>().SingleOrDefault(filtre);
            }
        }

        public Dersler TekilGetir(int ID)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<Dersler>().SingleOrDefault(o=>o.ID==ID);
            }
        }

        public void TopluEkle(List<Dersler> eklenecekliste)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                foreach (Dersler eleman in eklenecekliste)
                {
                    vt.Entry(eleman).State = EntityState.Added;
                }
                vt.SaveChanges();
            }
        }

        public void TopluSil(List<Dersler> silinecekListe)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                foreach (Dersler eleman in silinecekListe)
                {
                    vt.Entry(eleman).State = EntityState.Deleted;
                }
                vt.SaveChanges();
            }
        }
    }
}
