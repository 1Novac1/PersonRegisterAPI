using Microsoft.AspNetCore.Mvc;
using Register_Of_Persons.BLL.Interfaces;
using System;
using System.Linq;

namespace Register_Of_Persons.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService service;

        public PersonController(IPersonService service)
        {
            this.service = service;
        }

        [HttpGet]
        public void Void() { }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var person = service.GetById(id);

                if (person == null)
                    return NoContent();

                return Ok(person);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                var persons = service.GetAllByName(name);

                if (persons == null || persons.Count() == 0)
                    return NotFound();

                return Ok(persons);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("email/{email}")]
        public IActionResult GetByEmail(string email)
        {
            try
            {
                var persons = service.GetAllByEmail(email);

                if (persons == null || persons.Count() == 0)
                    return NotFound();

                return Ok(persons);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            try
            {
                var persons = service.GetAll();

                if (persons == null || persons.Count() == 0)
                    return NotFound();

                return Ok(persons);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}