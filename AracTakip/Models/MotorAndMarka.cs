﻿using AracTakipSistemi.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracTakip.Models
{
    public class MotorAndMarka
    {
        public List<tbl_MotorTip> motors { get; set; }
        public List<tbl_Marka> markas { get; set; }
    }
}