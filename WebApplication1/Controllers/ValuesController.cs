using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using WebApplication1.Models4Mapper;

namespace WebApplication1.Controllers
{
    
    [Route("api/Values")]
    public class ValuesController : Controller
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IMapper _mapper;
        public ValuesController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.Warn("Jakiś log ");
            HotDog hotDog = new HotDog() { Id = 5, Name = "Zwykly", Phone = 6666 };
            HotDogDTO HotDogDto = _mapper.Map<HotDogDTO>(hotDog);

            return Ok(HotDogDto);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new SystemException("Something is no yes ");
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}