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
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserDTOExtensive userDTO)
        {
            try
            {
                _userService.AddUser(userDTO);
                return CreatedAtAction(nameof(GetUserById), new { id = userDTO.Id }, userDTO);
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
        public IActionResult UpdateUser([FromBody] UserBasic userDTO)
        {
            return Ok(userDTO);
            // try
            // {
            //     _userService.UpdateUser(userDTO);
            //     return NoContent();
            // }
            // catch (Exception ex)
            // {
            //     return StatusCode(
            //         StatusCodes.Status500InternalServerError,
            //         new { error = ex.Message }
            //     );
            // }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
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
