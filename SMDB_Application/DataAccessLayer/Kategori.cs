﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Kategori
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public bool Durum { get; set; }
        public string DurumStr { get; set; }
    }
}
