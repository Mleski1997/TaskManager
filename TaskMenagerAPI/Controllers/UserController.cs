using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics.Metrics;
using TaskMenagerAPI.Data;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Interfaces;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly UserManager<IdentityUser> _user;

        public UserController(IUserRepository userRepository, IMapper mapper, DataContext context, UserManager<IdentityUser> user)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
            _user = user;
        }


        [HttpGet(Name = "GetUsers")]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        public IActionResult GetUsers() 

        {

            var userDto = _mapper.Map<List<UserDTO>>(_userRepository.GetUsers()); ;
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(userDto);

        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(UserWithTaskDTO))]
        [ProducesResponseType(400)]

        public IActionResult GetUser(string userId)
        {

              
            var user = _mapper.Map<UserWithTaskDTO>(_userRepository.GetUser(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(user);   
        
        }


        [HttpGet("{userId}/Todoes")]
    
        public IActionResult GetTodoesFromTodo(int userId)
        {

            var todoes = _mapper.Map<List<ToDoDTO>>(_userRepository.GetTodoesFromTodo(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(todoes);


        }



        [HttpPut("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult Edit(string userId, [FromBody] UserDTO updatedUser)
        {
            bool isUpdated = _userRepository.UpdateUser(userId, updatedUser);

            if (!isUpdated)
            {
                return NotFound("UserNotFound");
            }

            return Ok("Updated");

        }
        [HttpDelete("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult DeleteUser(string userId) {

            var userToDelete = _userRepository.GetUser(userId);

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            if(!_userRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wront delete category");
            }

            return NoContent();



        }
        

    }
}
