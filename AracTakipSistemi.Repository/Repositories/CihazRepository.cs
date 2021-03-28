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

    public class CihazRepository : MongoRepository<tbl_Cihaz>, ICihaz
    {
        public CihazRepository(IMongoContext context) : base(context)
        {

        }
    }
}
