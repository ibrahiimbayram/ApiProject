using DataAcces.Interfaces;
using Entity.Tables;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserServices
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserDal _userDal;
        public UserServices(IMemoryCache memoryCache, IUserDal userDal)
        {
            _memoryCache = memoryCache;
            _userDal = userDal;
        }

        List<Users> userlist = new List<Users>();
        public async Task<List<Users>> GetUsers()
        {




            if (_memoryCache.Get<List<Users>>("users") != null)
            {
                userlist = _memoryCache.Get<List<Users>>("users");
            }
            else
            {
                userlist = await _userDal.GetAllAsync();


                var options = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1),
                    Priority = CacheItemPriority.High,
                };
                _memoryCache.Set<List<Users>>("products", userlist, options);
            }
            return userlist;

        }

        public async Task<Users> Add(Users users)
        {

            await _userDal.AddAsync(users);
            _memoryCache.Remove("users");


            return null;
        }

    }
}
