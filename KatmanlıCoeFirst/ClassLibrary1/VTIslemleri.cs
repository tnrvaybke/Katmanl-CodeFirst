using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar;

namespace InterFaceler
{
    public interface VTIslemlerI<T>
    {
        void Ekle(T kayit);
        void sil(T kayit);
        void guncelle(T kayit);
        T TekilGetir(Func<T,bool>filtre);
        T TekilGetir(int ID);
        List<T> TamaminiGetir();
        List<T> Sorgula(Func<T, bool> filtre);
        void TopluEkle(List<T> eklenecekliste);
        void TopluSil(List<T> eklenecekliste);
    }
}
