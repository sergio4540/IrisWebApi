using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTalentu.Context;
using WebApiTalentu.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTalentu.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly AppDbContext context;
        public TimesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<TimesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Times.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TimesController>/5
        [HttpGet("{id}", Name = "GetTime")]
        public ActionResult Get(int id)
        {
            try
            {
                var time = context.Times.FirstOrDefault(f => f.IdTime == id);
                return Ok(time);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TimesController>
        [HttpPost]
        public ActionResult Post([FromBody] Times time)
        {
            try
            {
                context.Times.Add(time);
                context.SaveChanges();
                return CreatedAtRoute("GetTime", new { id = time.IdTime }, time);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TimesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Times time)
        {
            try
            {
                if (time.IdTime == id)
                {
                    context.Entry(time).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetTime", new { id = time.IdTime }, time);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TimesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var time = context.Times.FirstOrDefault(f => f.IdTime == id);
                if (time != null)
                {
                    context.Times.Remove(time);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
