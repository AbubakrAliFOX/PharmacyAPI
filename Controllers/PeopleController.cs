using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using PharmacyAPI.Data.Repositories;
using PharmacyAPI.Data.Repositories.Interfaces;
using PharmacyAPI.DTOs;
using PharmacyAPI.Models;
using PharmacyAPI.Services;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly PersonService _personService;

        public PeopleController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            var persons = await _personService.GetAllPersons();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var person = await _personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonDTO personDTO)
        {
            try
            {
                var person = new Person
                {
                    FirstName = personDTO.FirstName,
                    LastName = personDTO.LastName,
                    Gender = personDTO.Gender,
                    Address = personDTO.Address,
                    PhoneNumber = personDTO.PhoneNumber,
                };
                return CreatedAtAction(nameof(GetPersonById), new { id = person.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { error = ex.Message }
                );
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(Person person)
        {
            try
            {
                _personService.UpdatePerson(person);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { error = ex.Message }
                );
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            try
            {
                _personService.DeletePerson(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { error = ex.Message }
                );
            }
        }
    }
}
