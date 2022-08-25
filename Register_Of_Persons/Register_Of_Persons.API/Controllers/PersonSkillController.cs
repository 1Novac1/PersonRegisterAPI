using Microsoft.AspNetCore.Mvc;
using Register_Of_Persons.BLL.Interfaces;
using Register_Of_Persons.BLL.Models;
using System;
using System.Linq;

namespace Register_Of_Persons.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonSkillController : ControllerBase
    {
        private readonly IModelService<PersonSkillModel> service;

        public PersonSkillController(IModelService<PersonSkillModel> service)
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
                var personSkill = service.GetById(id);

                if (personSkill == null)
                    return NotFound();

                return Ok(personSkill);
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
                var personSkills = service.GetAll();

                if (personSkills == null || personSkills.Count() == 0)
                    return NotFound();

                return Ok(personSkills);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}