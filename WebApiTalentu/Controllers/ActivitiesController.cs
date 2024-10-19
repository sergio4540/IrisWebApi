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
    public class ActivitiesController : ControllerBase
    {
        private readonly AppDbContext context;
        public ActivitiesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ActivitiesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Activities.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ActivitiesController>/5
        [HttpGet("{id}", Name = "GetActivity")]
        public ActionResult Get(int id)
        {
            try
            {
                var user = context.Activities.FirstOrDefault(f => f.IdActivity == id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ActivitiesController>
        [HttpPost]
        public ActionResult Post([FromBody] Activities activity)
        {
            try
            {
                context.Activities.Add(activity);
                context.SaveChanges();
                return CreatedAtRoute("GetActivity", new { id = activity.IdActivity }, activity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ActivitiesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Activities activity)
        {
            try
            {
                if (activity.IdActivity == id)
                {
                    context.Entry(activity).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetActivity", new { id = activity.IdActivity }, activity);
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

        // DELETE api/<ActivitiesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var activity = context.Activities.FirstOrDefault(f => f.IdActivity == id);
                if (activity != null)
                {
                    context.Activities.Remove(activity);
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
