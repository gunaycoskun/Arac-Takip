﻿using AracTakip.Models;
using AracTakipSistemi.DAL.Concrete;
using Eselfware.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracTakip.Controllers
{
    public class MarkaController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Marka
        [Route("get-all-marka")]
        public ActionResult Marka()
        {
            var allMarka = (from marka in unitOfWork.Marka.ToList()
                            join model in unitOfWork.Model.ToList() on marka.ModelID equals model._id
                            select new MarkaAndModels
                            {
                                ModelAD = model.ModelAD,
                                id = marka._id,
                                MarkaAD = marka.MarkaAD
                            }).ToList();
            return View(allMarka);
        }
        [HttpGet]
        [Route("create-marka")]
        public ActionResult CreateMarka()
        {
            var models = unitOfWork.Model.ToList();
            return View(models);
        }
        [HttpPost]
        [Route("save-marka")]
        public ActionResult SaveMarka(string MarkaAD, string ModelID)
        {
            tbl_Marka marka = new tbl_Marka
            {
                MarkaAD = MarkaAD,
                ModelID = ModelID
            };
            unitOfWork.Marka.Add(marka);
            unitOfWork.Save();
            return View();
        }
    }
}