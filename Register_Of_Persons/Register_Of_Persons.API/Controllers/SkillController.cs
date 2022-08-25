using Microsoft.AspNetCore.Mvc;
using Register_Of_Persons.BLL.Interfaces;
using System;
using System.Linq;

namespace Register_Of_Persons.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService service;

        public SkillController(ISkillService service)
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
                var skill = service.GetById(id);

                if (skill == null)
                    return NotFound();

                return Ok(skill);
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
                var skills = service.GetAllByName(name);

                if (skills == null || skills.Count() == 0)
                    return NotFound();

                return Ok(skills);
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
                var skills = service.GetAll();

                if (skills == null || skills.Count() == 0)
                    return NotFound();

                return Ok(skills);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}