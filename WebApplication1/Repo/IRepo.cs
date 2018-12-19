using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repo
{
    public interface IRepo
    {
        Task<HotDog> GetAsync(int id);
        Task<IEnumerable<HotDog>> BrowseAsync(string name = null);
        Task<HotDog> AddAsync(HotDog hotDog);
    }
}
