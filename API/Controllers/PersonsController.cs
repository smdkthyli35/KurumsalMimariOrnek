using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var addedPerson = await _personService.AddAsync(person);
            return Ok(addedPerson);
        }
    }
}
