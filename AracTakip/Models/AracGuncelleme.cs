using AracTakipSistemi.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracTakip.Models
{
    public class AracGuncelleme
    {
        public string _id { get; set; }
        public string Plaka { get; set; }
        public string SasiNo { get; set; }
        public string Renk { get; set; }
        public string MarkaID { get; set; }
        public string ModelID { get; set; }
        public string MusteriID { get; set; }
        public string Yil { get; set; }
        public List<tbl_Marka> markalar { get; set; }
        public List<tbl_Model> modeller { get; set; }
        public List<tbl_Musteri> musteriler { get; set; }
    }
}