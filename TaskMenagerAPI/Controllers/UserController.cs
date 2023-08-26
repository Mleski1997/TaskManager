using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;
using System.Security.Claims;
using TaskMenagerAPI.Data;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Interfaces;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserWithPresenttion _userWithPresenttion;
        private readonly IUserRepository _userRepository;
        private readonly IUserIsLogged _userLogged;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        

        public UserController(ILogger<UserController> logger, UserWithPresenttion userWithPresenttion,  IUserRepository userRepository,IUserIsLogged userLogged, IMapper mapper, DataContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userWithPresenttion = userWithPresenttion;
            _userRepository = userRepository;
            _userLogged = userLogged;
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            
        }
        private async Task<User> GetUserLoged()
        {
            var loggedIn = User.Identity.Name;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loggedIn);
            return user;
        }



        [HttpGet]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        public async Task<IActionResult> GetUsers()
        {

        //   var userLogged = await GetUserLoged();
          //  if (!userLogged.IsActive)
           //{
           //    return BadRequest("User is disabled");
           // }

           var userDto = _mapper.Map<List<UserDTO>>(await _userRepository.GetUsers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation($"{userDto.Count} users");
            var users = await _userRepository.GetUsers();
            _userWithPresenttion.Show(users);

            return Ok(userDto);
           
        }
       


        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(UserWithTaskDTO))]
        [ProducesResponseType(400)]

        public async Task <IActionResult> GetUser(string userId)
        {
            //   var userLogged = await GetUserLoged();
            //  if (!userLogged.IsActive)
            //{
            //    return BadRequest("User is disabled");
            // }


            var user = _mapper.Map<UserWithTaskDTO>(await _userRepository.GetUser(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(user);

        }


        [HttpGet("{userId}/Todoes")]

        public async Task <IActionResult> GetTodoesFromTodo(string userId)
        {
            //   var userLogged = await GetUserLoged();
            //  if (!userLogged.IsActive)
            //{
            //    return BadRequest("User is disabled");
            // }


            var todoes = _mapper.Map<List<ToDoDTO>>(await _userRepository.GetTodoesFromTodo(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(todoes);


        }



        [HttpPut("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public async Task <IActionResult> Edit(string userId, [FromBody] UserDTO updatedUser)
        {
          
            bool isUpdated = await _userRepository.UpdateUser(userId, updatedUser);

            if (!isUpdated)
            {
                return NotFound("UserNotFound");
            }

            return Ok("Updated");

        }

        [HttpPut("{userId}/Active")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public async Task<IActionResult> EditUserStatus(string userId, [FromBody] UserActiveDTO activeUser) {

            bool isUpdated = await _userRepository.UpdateActive(userId, activeUser);

            if (!isUpdated)
            {
                return BadRequest("Update failded");
            }
            return Ok("Updated");



                }
        [HttpDelete("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public async Task <IActionResult> DeleteUser(string userId)
        {
        

            var userToDelete = await _userRepository.GetUser(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (! await _userRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wront delete category");
            }

            return NoContent();



        }

      


    }
}