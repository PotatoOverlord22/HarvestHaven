﻿using Microsoft.AspNetCore.Mvc;
using Server.API.Models;
using Server.API.Services;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        // Get all users
        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await userService.GetUsersAsync();
                return users;
            }
            catch (Exception e)
                {
                    return BadRequest();
                }
        }

        // Get the poker leaderboard
        // GET: api/users/poker-leaderboard
        [HttpGet("poker-leaderboard")]
        public async Task<ActionResult<IEnumerable<User>>> GetPokerLeaderboard()
        {
            try
            {
                var leaderboard = await userService.GetPokerLeaderboardAsync();
                return leaderboard;
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // Get user by id
        // api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // UPDATE a user
        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User user)
        {
            try
            {
                await userService.UpdateUserAsync(id, user);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Update user chips
        // PUT: api/users/5/chips
        [HttpPut("{id}/chips")]
        public async Task<IActionResult> UpdateUserChips(Guid id, [FromBody] int chips)
        {
            try
            {
                await userService.UpdateUserChipsAsync(id, chips);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Add user
        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                await userService.AddUser(user);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await userService.DeleteUserAsync(id);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}