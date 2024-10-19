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
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext context;
        public CategoriesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Categories.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult Get(int id)
        {
            try
            {
                var user = context.Categories.FirstOrDefault(f => f.IdCategory == id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
