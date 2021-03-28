using AracTakipSistemi.DAL.Concrete;
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

    public class KasaTipRepository : MongoRepository<tbl_KasaTip>, IKasaTip
    {
        public KasaTipRepository(IMongoContext context) : base(context)
        {

        }
    }
}
