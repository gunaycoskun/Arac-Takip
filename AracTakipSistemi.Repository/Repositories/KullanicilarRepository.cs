using AracTakipSistemi.DAL.Concrete;
using AracTakipSistemi.DAL.MongoContext;
using Eselfware.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracTakipSistemi.Repository.Repositories
{
    public class KullanicilarRepository : MongoRepository<tbl_Kullanicilar>, IKullanicilar
    {
        public KullanicilarRepository(IMongoContext context) : base(context)
        {

        }
    }
}
