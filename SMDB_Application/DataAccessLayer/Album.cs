using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Album
    {
        public int ID { get; set; }
        public int Sanatci_ID { get; set; }
        public string SanatciIsim { get; set; }
        public string SanatciSoyisim { get; set; }
        public DateTime CikisYili { get; set; }
        public int AlbumTopPuan { get; set; }
        public string KapakFoto { get; set; }
        public byte MuzikSayisi { get; set; }
        public bool Durum { get; set; }
        public string Isim { get; set; }
        public int Sirket_ID { get; set; }
        public string SirketIsim { get; set; }

        

    }
}
