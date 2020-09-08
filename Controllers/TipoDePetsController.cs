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
    public class TipoDePetsController : ControllerBase {
        TipoDePetsRepository repo = new TipoDePetsRepository();

        // GET: api/<TipoDePetsController>
        [HttpGet]
        public List<TipoDePets> Get() {
            return repo.ReadAll();
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public TipoDePets Get(int id) {
            return repo.SearchById(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public TipoDePets Post([FromBody] TipoDePets a) {
            return repo.Register(a);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public TipoDePets Put(int id, [FromBody] TipoDePets a) {
            return repo.Update(id, a);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            repo.Delete(id);
        }
    }
}