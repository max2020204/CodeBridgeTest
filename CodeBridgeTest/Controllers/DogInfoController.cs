using CodeBridgeTest.Data;
using CodeBridgeTest.Data.Repository.Interfaces;
using CodeBridgeTest.Model;
using CodeBridgeTest.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeBridgeTest.Controllers
{
    [ApiController]
    public class DogInfoController : ControllerBase
    {
        private IDogRepository Dog { get; set; }
        IDogsServices Services { get; set; }
        public DogInfoController(IDogRepository _dog, IDogsServices services)
        {
            Dog = _dog;
            Services = services;

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
            return Ok(Services.GetDogs(page, pageSize, attribute, order));
        }
        [HttpPost]
        [Route("/dog")]
        public IActionResult NewDog(Dog dog)
        {
            try
            {
                Dog.Save(dog);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("This name already in database. " + ex.Message);
            }
        }
    }
}
