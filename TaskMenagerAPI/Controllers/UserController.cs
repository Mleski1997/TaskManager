using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            
        }


        [HttpGet(Name = "GetUsers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers() 
        {
            var users = _mapper.Map<List<UserDTO>>(_userRepository.GetUsers());
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);

        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]

        public IActionResult GetUser(int userId) {

           
            
            var user = _mapper.Map<UserDTO>(_userRepository.GetUser(userId));

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


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateUser([FromBody] UserDTO userCreate)
        {
            if (userCreate == null)
                return BadRequest(ModelState);

            var user = _userRepository.GetUsers()
                .Where(c => c.LastName.Trim().ToUpper() == userCreate.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);

            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult UpdateUser(int userId, [FromBody] UserDTO updatedUser)
        {
            if (updatedUser == null)
                return BadRequest(ModelState);
            if (userId != updatedUser.Id)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(updatedUser);
            if (!_userRepository.UpdateUser(userMap))
            {
                ModelState.AddModelError("", "Something wen wrong updating category");
                return StatusCode(500, ModelState);
            }
            return NoContent();


        }
        [HttpDelete("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public IActionResult DeleteUser(int userId) {

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
