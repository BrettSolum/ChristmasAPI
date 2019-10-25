using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChristmasAPI.Contexts;
using ChristmasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
#pragma warning disable 1591

namespace ChristmasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly PiContext _context;

        public UsersController(PiContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Get a list of all users
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users);
        }

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var userToReturn = _context.Users.FirstOrDefault(u => u.Id == id);

            if (userToReturn == null)
            {
                return NotFound();
            }

            return Ok(userToReturn);
        }
        
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="familyId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("{familyId}/user")]
        public IActionResult CreateUser(int familyId, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var family = _context.Families.FirstOrDefault(f => f.Id == familyId);

            if (family == null)
            {
                return NotFound("The family specified doesn't exist");
            }

            var finalUser = new User()
            {
                First = user.First,
                Last = user.Last,
                SpouseId = user.SpouseId,
                Family = family.Id
            };

            _context.Users.Add(finalUser);
            _context.SaveChanges();

            return Created("api/[Controller]/{familyId}/user", finalUser);
        }

        /// <summary>
        /// Update user spouse
        /// </summary>
        /// <param name="id"></param>
        /// <param name="spouseId"></param>
        /// <returns></returns>
        [HttpPut("{id}/spouse/{spouseId}")]
        public IActionResult UpdateUserSpouse(int id, int spouseId)
        {
            var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);

            if (userToUpdate == null)
            {
                return NotFound("User does not exist");
            }

            var spouse = _context.Users.FirstOrDefault(s => s.Id == spouseId);

            if (spouse == null)
            {
                return NotFound("Spouse does not exist");
            }

            userToUpdate.SpouseId = spouse.Id;
            _context.SaveChanges();

            return NoContent();
        }
        
        /// <summary>
        /// Update user exchange
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exchangeId"></param>
        /// <returns></returns>
        [HttpPut("{id}/exchange/{exchangeId}")]
        public IActionResult UpdateUserExchange(int id, int exchangeId)
        {
            var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);

            if (userToUpdate == null)
            {
                return NotFound("User does not exist");
            }

            var exchange = _context.Users.FirstOrDefault(s => s.Id == exchangeId);

            if (exchange == null)
            {
                return NotFound("Exchange user does not exist");
            }

            userToUpdate.Exchange = exchange.Id;
            _context.SaveChanges();

            return NoContent();
        }
    }
}