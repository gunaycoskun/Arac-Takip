using AracTakipSistemi.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracTakip.Models
{
    public class ModelAndMotors
    {
        public string _id { get; set; }
        public string ModelAD { get; set; }
        public string KapiID { get; set; }
        public string KasaID { get; set; }
        public string VitesID { get; set; }
        public string  MotorID { get; set; }
        public List<tbl_MotorTip> motors { get; set; }
    }
}