using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Database;
using UserService.Database.Entities;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DatabaseContext _dbContext;
        public UserController()
        {
            _dbContext = new DatabaseContext();
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dbContext.Users.ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _dbContext.Users.Find(id);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            try
            {
                _dbContext.Users.Add(model);
                _dbContext.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                throw;
            }
        }
    }
}
