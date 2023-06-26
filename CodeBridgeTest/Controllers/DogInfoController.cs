using CodeBridgeTest.Data.Repository.Interfaces;
using CodeBridgeTest.Model;
using CodeBridgeTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeBridgeTest.Controllers
{
    [ApiController]
    public class DogInfoController : ControllerBase
    {
        private readonly IDogRepository _dog;
        private readonly IDogsServices _services;

        public DogInfoController(IDogRepository dog, IDogsServices services)
        {
            _dog = dog;
            _services = services;
        }

        [HttpGet]
        [Route("/ping")]
        public IActionResult Ping()
        {
            return Ok("Dogs house service. Version 1.0.1");
        }

        [HttpGet]
        [Route("/dogs")]
        public IActionResult Dogs([FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string? attribute, [FromQuery] string? order)
        {
            return Ok(_services.GetDogs(page, pageSize, attribute, order));
        }

        [HttpPost]
        [Route("/dog")]
        public IActionResult NewDog(Dog dog)
        {
            try
            {
                _dog.Save(dog);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("This name already in database. " + ex.Message);
            }
        }
    }
}