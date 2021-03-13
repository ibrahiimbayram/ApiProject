using DataAcces.Context;
using DataAcces.Interfaces;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Concrete
{
    public class EfUserRepository : EfGenericRepository<Users> , IUserDal
    {

        private readonly DataContext _context;

        public EfUserRepository(DataContext context):base(context)
        {
            _context = context;
        }


    }
}
