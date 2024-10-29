using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Muzik
    {
        public int ID { get; set; }
        public int Album_ID { get; set; }
        public  string AlbumIsim { get; set; }
        public string Isim { get; set; }
        public int OylanmaSayisi { get; set; }
        public int OrtPuan { get; set; }
        public bool Durum { get; set; }
        public int  Puanlama {  get; set; }
        public int Sanatci_ID { get; set; }
        public string SanatciIsim { get; set; }
        public  string SanatciSoyisim { get; set; }
        public  string SanatciFullIsim { get; set; }



    }
}
