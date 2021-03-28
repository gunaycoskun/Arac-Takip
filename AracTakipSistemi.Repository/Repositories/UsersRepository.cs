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
    public class UsersRepository : MongoRepository<tbl_Users>, IUsers
    {
        public UsersRepository(IMongoContext context) : base(context)
        {

        }
    }
}
