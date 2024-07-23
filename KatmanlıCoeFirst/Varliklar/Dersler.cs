using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varliklar
{
    [Table("Dersler")]
    public class Dersler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(20)]
        [Required]
        public string dersKodu { get; set; }
        [MaxLength(100)]
        [Required]
        public string dersAdi { get; set; }
        public short akts { get; set; }
        public Dersler()
        {
            
        }

        public Dersler(int ID, string dersKodu, string dersAdi, short akts)
        {
            ID = ID;
            this.dersKodu = dersKodu;
            this.dersAdi = dersAdi;
            this.akts = akts;
        }
    }
}
