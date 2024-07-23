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
    public class OgrenciDAL : VTIslemlerI<Ogrenci>
    {
        public void Ekle(Ogrenci kayit)
        {
            using (VeriTabaniContext vt=new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Added;
                vt.SaveChanges();
            }
        }

        public void guncelle(Ogrenci kayit)
        {
           using(VeriTabaniContext vt= new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Modified;
                vt.SaveChanges();
            }
        }

        public void sil(Ogrenci kayit)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Deleted;
                vt.SaveChanges();
            }
        }

        public List<Ogrenci> Sorgula(Func<Ogrenci, bool> filtre)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
               return filtre== null ? vt.Set<Ogrenci>().ToList():
                    vt.Set<Ogrenci>().Where(filtre).ToList();
            }
        }

        public List<Ogrenci> TamaminiGetir()
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<Ogrenci>().ToList();
            }
        }

        public Ogrenci TekilGetir(Func<Ogrenci, bool> filtre)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<Ogrenci>().SingleOrDefault(filtre);
            }
        }

        public Ogrenci TekilGetir(int ID)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<Ogrenci>().SingleOrDefault(o=>o.ID==ID);
            }
        }

        public void TopluEkle(List<Ogrenci> eklenecekliste)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                foreach (Ogrenci eleman in eklenecekliste)
                {
                    vt.Entry(eleman).State = EntityState.Added;
                }
                vt.SaveChanges();
            }
        }

        public void TopluSil(List<Ogrenci> silinecekListe)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                foreach (Ogrenci eleman in silinecekListe)
                {
                    vt.Entry(eleman).State = EntityState.Deleted;
                }
                vt.SaveChanges();
            }
        }
    }
}
