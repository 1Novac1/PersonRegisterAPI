using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register_Of_Persons.BLL.Service;
using System;

namespace Register_Of_Persons.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvFileController : ControllerBase
    {
        private readonly CSVFileService service;

        public CsvFileController(CSVFileService service)
        {
            this.service = service;
        }

        [HttpGet]
        public void Void() { }

        [HttpPost("single")]
        public IActionResult UploadFile([FromForm(Name = "csvfile")] IFormFile formFile)
        {
            try
            {
                if (formFile == null)
                    return BadRequest($"{nameof(formFile)} is Null");

                var stream = formFile.OpenReadStream();

                if (service.UploadInDatabase(stream))
                {
                    return Ok("Data uploaded into the database.");
                }

                return StatusCode(500, "There was an error while processing the file.");
            }
            catch(ArgumentNullException e)
            {
                return StatusCode(500, e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}