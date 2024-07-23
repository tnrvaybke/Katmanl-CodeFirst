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
    public class OgrenciDersDAL : VTIslemlerI<OgrenciDers>
    {
        public void Ekle(OgrenciDers kayit)
        {
            using (VeriTabaniContext vt=new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Added;
                vt.SaveChanges();
            }
        }

        public void guncelle(OgrenciDers kayit)
        {
           using(VeriTabaniContext vt= new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Modified;
                vt.SaveChanges();
            }
        }

       

        public void sil(OgrenciDers kayit)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Deleted;
                vt.SaveChanges();
            }
        }

        public List<OgrenciDers> Sorgula(Func<OgrenciDers, bool> filtre)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
               return filtre== null ? vt.Set<OgrenciDers>().ToList():
                    vt.Set<OgrenciDers>().Where(filtre).ToList();
            }
        }

        public List<OgrenciDers> TamaminiGetir()
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<OgrenciDers>().Include(o=>o.Ogrenci).Include(o=>o.Dersler).ToList();
            }
        }

        public OgrenciDers TekilGetir(Func<OgrenciDers, bool> filtre)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<OgrenciDers>().SingleOrDefault(filtre);
            }
        }

        public OgrenciDers TekilGetir(int ID)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<OgrenciDers>().SingleOrDefault(o=>o.ID==ID);
            }
        }

        public void TopluEkle(List<OgrenciDers> eklenecekliste)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                foreach (OgrenciDers eleman in eklenecekliste)
                {
                    vt.Entry(eleman).State = EntityState.Added;
                }
                vt.SaveChanges();
            }
        }

        public void TopluSil(List<OgrenciDers> silinecekListe)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                foreach (OgrenciDers eleman in silinecekListe)
                {
                    vt.Entry(eleman).State = EntityState.Deleted;
                }
                vt.SaveChanges();
            }
        }
    }
}
