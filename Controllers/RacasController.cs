using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pets_2.Domains;
using Pets_2.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pets_2.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RacasController : ControllerBase {

        RacasRepository repo = new RacasRepository();
        // GET: api/<RacasController>
        [HttpGet]
        public List<Racas> Get() {
            return repo.ReadAll();
        }

        // GET api/<RacasController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return id.ToString();
        }

        // POST api/<RacasController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<RacasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<RacasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
