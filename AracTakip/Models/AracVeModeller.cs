using AracTakipSistemi.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracTakip.Models
{
    public class AracVeModeller
    {
        public List<tbl_Marka> markalar { get; set; }
        public List<tbl_Model> modeller { get; set; }
    }
}