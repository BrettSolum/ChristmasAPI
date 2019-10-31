using System;
using System.Linq;
using System.Security.Permissions;
using ChristmasAPI.Contexts;
using ChristmasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Xml;
#pragma warning disable 1591

namespace ChristmasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliesController : Controller
    {
        private readonly PiContext _context;

        public FamiliesController(PiContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Get a list of all families
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult GetFamilies()
        {
            return Ok(_context.Families);
        }

        /// <summary>
        /// Get a family by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetFamily(int id)
        {
            var familyToReturn = _context.Families.FirstOrDefault(f => f.Id == id);

            if (familyToReturn == null)
            {
                return NotFound();
            }

            return Ok(familyToReturn);
        }

        /// <summary>
        /// Get a list of users by family
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Users")]
        public IActionResult GetFamilyUsers(int id)
        {
            var usersToReturn = _context.Users
                .AsNoTracking()
                .Where(u => u.FamilyId == id)
                .Include(u => u.Spouse)
                .Include(u => u.ExchangeUser);


            if (usersToReturn.Any())
            {
                return NotFound();
            }

            return Ok(usersToReturn);
        }

        /// <summary>
        /// Create a new family
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost("{name}")]
        public IActionResult CreateFamily(string name)
        {
            var familyExists = _context.Families.FirstOrDefault(f => f.Name == name);

            if (familyExists != null)
            {
                return BadRequest("This family name already exists");
            }

            var newFamily = new Family() {Name = name};

            _context.Families.Add(newFamily);
            _context.SaveChanges();

            return Created("api/[controller]/{name}", newFamily);
        }
        
        /// <summary>
        /// Delete a Family
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteFamily(int id)
        {
            var familyToRemove = _context.Families.FirstOrDefault(f => f.Id == id);

            if (familyToRemove == null)
            {
                return NotFound();
            }

            _context.Families.Remove(familyToRemove);
            _context.SaveChanges();
            
            return NoContent();
        }

    }
}