using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Sanatci
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public bool GrupMu { get; set; }
        public bool Durum { get; set; }

    }
}
