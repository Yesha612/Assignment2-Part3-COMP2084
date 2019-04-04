using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheIcecreamParlourAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheIcecreamParlourAPI.Controllers
{
    [Route("api/[controller]")]
    public class IcecreamsController : Controller
    {
        // db connect
        DbModel db;

        public IcecreamsController(DbModel db)
        {
            this.db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Icecream> Get()
        {
            return db.icecream.OrderBy(i => i.Flavour).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var icecream = db.icecream.SingleOrDefault(i => i.FlavourID == id);

            if (icecream == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(icecream);
            }

        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Icecream icecream)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.icecream.Add(icecream);
                db.SaveChanges();
                return CreatedAtAction("Post", new { id = icecream.FlavourID }, icecream);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Icecream icecream)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(icecream).State = EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", new { id = icecream.FlavourID }, icecream);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var icecream = db.icecream.SingleOrDefault(i => i.FlavourID == id);
            if (icecream == null)
            {
                return NotFound();
            }
            else
            {
                db.icecream.Remove(icecream);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
