using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YillikIzin.Models
{
    public class Departman
    {
        public Departman()
        {
            List<Personel> Personeller = new List<Personel>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<Personel> Personeller { get; set; }
    }
}
