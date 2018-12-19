using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication1.DbContexts;
using WebApplication1.Models;

namespace WebApplication1.Repo
{
    public class Repos :IRepo
    {
        public readonly Db _db;

        public Repos()
        {
            _db = new Db();
        }

        public async Task<IEnumerable<HotDog>> BrowseAsync(string name = null)
        {

            IEnumerable<HotDog> hotDogs;
            if (!string.IsNullOrWhiteSpace(name))
            {
                hotDogs = _db.HotDog.Where(x => x.Name.ToLower() == name.ToLower());
            }
            else
            {
                hotDogs = _db.HotDog;
            }
            return await Task.FromResult(hotDogs);
        }

        public async Task<HotDog> AddAsync(HotDog hotDog)
        {
            _db.Add(hotDog);
            await _db.SaveChangesAsync();
            return hotDog;
        }

        public async Task<HotDog> GetAsync(int id)
        {
            var customer = _db.HotDog.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return null;
            return await Task.FromResult(customer);
        }
    }
}
