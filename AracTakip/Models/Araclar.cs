using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracTakip.Models
{
    public class Araclar
    {
        public string AracID { get; set; }
        public string Plaka { get; set; }
        public string SasiNo { get; set; }
        public string Renk { get; set; }
        public string Yil { get; set; }
        public string MusteriID { get; set; }
        public string MusteriAd { get; set; }
        public string MarkaID { get; set; }
        public string MarkaAd { get; set; }
        public string ModelID { get; set; }
        public string ModelAd { get; set; }
    }
}