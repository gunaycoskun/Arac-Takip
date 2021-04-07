using AracTakipSistemi.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracTakip.Models
{
    public class MarkaModel
    {
        public string _id { get; set; }
        public string MarkaAD { get; set; }
        public string ModelID { get; set; }
        public List<tbl_Model> models { get; set; }
    }
}