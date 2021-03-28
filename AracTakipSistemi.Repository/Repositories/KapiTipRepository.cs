﻿using AracTakipSistemi.DAL.Concrete;
using AracTakipSistemi.DAL.MongoContext;
using AracTakipSistemi.Repository.Interfaces;
using Eselfware.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracTakipSistemi.Repository.Repositories
{

    public class KapiTipRepository : MongoRepository<tbl_KapiTip>, IKapiTip
    {
        public KapiTipRepository(IMongoContext context) : base(context)
        {

        }
    }
}
