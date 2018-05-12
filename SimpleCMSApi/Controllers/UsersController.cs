using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCMSApi.Data;
using SimpleCMSApi.Models;

namespace SimpleCMSApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly SimpleCmsApiContext _context;

        public UsersController(SimpleCmsApiContext context)
        {
            _context = context;
        }

        // POST api/users/register
        [HttpPost("{register}")]
        public IActionResult Register([FromBody] User user)
        {
            var username = _context.Users.FirstOrDefault(x => x.Username == user.Username);
            if (username != null)
            {
                return Json("userExists");
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return Json("ok");
            }
        }

        // POST api/users/login
        [HttpPost("{login}")]
        public IActionResult Login([FromBody] User user)
        {
            var username = _context.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (username != null)
            {
                return Json(user.Username);
            }
            else
            {
                return Json("invalidLogin");
            }
        }
    }
}