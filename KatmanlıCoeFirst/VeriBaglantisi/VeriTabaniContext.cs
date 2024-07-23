using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar;

namespace VeriBaglantisi
{
    public class VeriTabaniContext:DbContext
    {
        DbSet<Ogrenci> ogrenciler {  get; set; }
        DbSet<Dersler> dersler { get; set; }
        DbSet<OgrenciDers> OgrenciDers { get; set; }
    }
}
