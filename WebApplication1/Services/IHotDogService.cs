using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.ModelsForTestsOnly;

namespace WebApplication1.Services
{
    public interface IHotDogService
    {
        Task<DTOHotDog4Test> GetAsync(int id);
        Task<IEnumerable<DTOHotDog4Test>> BrowseAsync(string name = null);
        Task<int> CreateAsync(string name, int phone, int sauceid);
    }
}
