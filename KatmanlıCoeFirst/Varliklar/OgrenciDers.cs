using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varliklar
{
    [Table("OgrenciDersler")]
    public class OgrenciDers
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Ogrenci))]

        public int OgrenciID { get; set; }
        [ForeignKey(nameof(Dersler))]
        public int DersID { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
        public virtual Dersler Dersler { get; set; }

        public OgrenciDers()
        {
            
        }

        public OgrenciDers(int ID, int ogrenciID, int dersID, Ogrenci ogrenci, Dersler dersler)
        {
            ID = ID;
            OgrenciID = ogrenciID;
            DersID = dersID;
            Ogrenci = ogrenci;
            Dersler = dersler;
        }
    }
}
