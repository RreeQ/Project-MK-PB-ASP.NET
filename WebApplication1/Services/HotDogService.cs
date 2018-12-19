using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Repo;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ModelsForTestsOnly;

namespace WebApplication1.Services
{
    public class HotDogService : IHotDogService
    {
        public readonly IRepo _repo;
        public HotDogService(IRepo repository)
        {
            _repo = repository;
        }

        public async Task<IEnumerable<DTOHotDog4Test>> BrowseAsync(string name = null)
        {
            var hotDog = await _repo.BrowseAsync(name);
            var hotDogsDto = hotDog.Select(x => new DTOHotDog4Test() { Id = x.Id, FullOrder = x.Name + " " + x.Phone });
            return hotDogsDto;

        }

        public async Task<int> CreateAsync(string name, int phone, int sauceid)
        {
            var hotDog = new HotDog() { Name = name, Phone = phone, SauceId = sauceid };
            await _repo.AddAsync(hotDog);
            return hotDog.Id;
        }

        public async Task<DTOHotDog4Test> GetAsync(int id)
        {
            var hotDog = await _repo.GetAsync(id);
            if (hotDog == null)
                return null;
            return new DTOHotDog4Test() { Id = hotDog.Id, FullOrder = hotDog.Name + " " + hotDog.Phone };
        }
    }
}
