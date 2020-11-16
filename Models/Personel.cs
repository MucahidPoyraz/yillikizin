using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YillikIzin.Models
{
    public class Personel
    {
        

        public int Id { get; set; }
        public string AdSoyad { get; set; }
        [Column(TypeName ="date")]
        public DateTime Giristarih { get; set; }
        public string Telefon { get; set; }
        public bool Cinsiyet { get; set; }
        public string Email { get; set; }
        public int DepartmanId { get; set; }
        [ForeignKey("DepartmanId")]
        public Departman Departman { get; set; }

    }
}
