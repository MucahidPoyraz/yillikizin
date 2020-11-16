using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YillikIzin.Models
{
    public class Izin
    {
        [Key]
        public int Id { get; set; }

        
        [ForeignKey("PersonelId")]
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }  

        [Column(TypeName = "date")]
        public DateTime BaslamaTarihi { get; set; }
        [Column(TypeName = "date")]
        public DateTime BitisTarihi { get; set; }
        [Column(TypeName = "date")]
        public DateTime Taleptarihi { get; set; }

        public string Adres { get; set; }
        public int Kullanilanizin { get; set; }

    }
}
