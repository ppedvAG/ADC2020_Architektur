using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.ADC2020.Logic;
using ppedv.ADC2020.Model;

namespace ppedv.ADC2020.UI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoAPIController : ControllerBase
    {
        Core core = new Core();
        // GET: api/AutoAPI
        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            return core.Repository.Query<Auto>().ToList();
        }

        // GET: api/AutoAPI/5
        [HttpGet("{id}", Name = "Get")]
        public Auto Get(int id)
        {
            return core.Repository.GetById<Auto>(id);
        }

        // POST: api/AutoAPI
        [HttpPost]
        public void Post([FromBody] Auto auto)
        {
            core.Repository.Add(auto);
            core.Repository.Save();
        }

        // PUT: api/AutoAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Auto auto)
        {
            core.Repository.Update(auto);
            core.Repository.Save();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var loaded = core.Repository.GetById<Auto>(id);
            if (loaded != null)
            {
                core.Repository.Delete(loaded);
                core.Repository.Save();
            }
        }
    }
}
