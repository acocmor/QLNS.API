using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.API.Application.DTOs.User;
using QLNS.API.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetUserDTO>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetUserDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetUserDTO>> GetUserById(Guid id)
        {
            var result = await _userService.GetUserById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GetUserDTO>> Create([FromBody] CreateUserDTO request)
        {
            var newUser = await _userService.CreateUser(request);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetUserDTO>> ChangePassword(Guid id, [FromBody] UpdateUserDTO request)
        {
            var update = await _userService.UpdateUser(id, request);
            if (update == null) return NotFound();
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _userService.DeleteUser(id);
            if (deleted) return NoContent();
            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Login([FromBody] LoginUserDTO userLogin)
        {
            var user = await _userService.Authencate(userLogin);
            if(user != null)
            {
                var token = await _userService.Generate(user);
                return Ok(token);
            }

            ModelState.AddModelError(nameof(userLogin.Email), "Tài khoản hoặc mật khẩu không đúng.");
            ModelState.AddModelError(nameof(userLogin.Password), "Tài khoản hoặc mật khẩu không đúng.");
            return BadRequest(ModelState);
        }
    }
}
