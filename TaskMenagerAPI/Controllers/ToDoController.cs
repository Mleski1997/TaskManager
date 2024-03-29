﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Collections.Generic;
using System.Linq;
using TaskMenagerAPI.Data;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Interfaces;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
  
    

    public class ToDoController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToDoRepository _toDoRepository;
        private readonly IUserRepository _userRepository;

        public ToDoController(DataContext context, IMapper mapper,IToDoRepository toDoRepository, IUserRepository userRepository )
        {
            _context = context;
            _mapper = mapper;
            _toDoRepository = toDoRepository;
            _userRepository = userRepository;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ToDo>))]


        public async Task <IActionResult> GetAllTodoes() {
          


            var todoes = _mapper.Map<List<ToDoDTO>>(await _toDoRepository.GetAllToDo());

            return Ok(todoes);
        
        }

       


    [HttpGet("Sort/Date")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ToDo>))]
        public async Task <IActionResult> GetAllTodoesByDate()
        {
         
            var todoes = _mapper.Map<List<ToDoDTO>>(await _toDoRepository.GetAllToDoByDate());
            return Ok(todoes);
        }

        [HttpGet("Sort/Status")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ToDo>))]
        public async Task <IActionResult> GetAllTodoesByStatus()
        {
         
            var todoes = _mapper.Map<List<ToDoDTO>>(await _toDoRepository.GetAllToDoByStatus());
            return Ok(todoes);
        }

        [HttpGet("Filter/Title")]
        public async Task <IActionResult> GetAllFilterByTitle(string title)
        {
            
            var todoes = _mapper.Map<List<ToDoDTO>>(await _toDoRepository.GetAllFilterByTitle(title));
            return Ok(todoes);

        }
        [HttpGet("Filter/Status")]
        public async Task <IActionResult> GetAllFilterByStatus([FromQuery] Status status)
        {
           
            var todoes = _mapper.Map<List<ToDoDTO>>(await _toDoRepository.GetAllFilterByStatus(status));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (todoes.Count == 0)
            {
                return BadRequest("Task with this status doesnt exists");
            }
            return Ok(todoes);

        }

        [HttpGet("{todoId}")]
        [ProducesResponseType(200, Type = typeof(ToDo))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetToDo(int todoId)
        {

          

            var todo = _mapper.Map<ToDoDTO>(await _toDoRepository.GetTodo(todoId));

            
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok(todo);
        }

        [HttpGet("{userId}/tasks")]
        [ProducesResponseType(200, Type = typeof(ToDo))]
        [ProducesResponseType(400)]

        public async Task <IActionResult> GetAllToDoFromUser(string  userId)
        {
          
            var todo = _mapper.Map<List<ToDoDTO>>(await _toDoRepository.GetAllToDoFromUser(userId));
            return Ok(todo);

        }







        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task <IActionResult> CreateTodo([FromBody] ToDoDTO todoCreate)
        {
           
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = _mapper.Map<ToDo>(todoCreate);
            foreach (var userId in todoCreate.UserIds)
            {
                var userToDo = new UserToDo { UserId = userId, ToDo = todo };
                _context.UserToDoes.Add(userToDo);
            }


            _context.ToDoes.Add(todo);
            await _context.SaveChangesAsync();

            return Ok("Seccefully created");

        }
        [HttpPut("{todoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task <IActionResult> UpdateToDo(int todoId, [FromBody] ToDoEditDTO updatedToDo)
        {
          
            bool toDoUpdated = await _toDoRepository.UpdateToDo(todoId, updatedToDo);

           if(!toDoUpdated)
            {
                return NotFound("Something went wrong");
            }

            return Ok("Updated");

            

            
        }
        [HttpDelete("{todoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public async Task <IActionResult> DeleteUser(int todoId)
        {
          

            var todoToDelete = await _toDoRepository.GetTodo(todoId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _toDoRepository.DeleteToDo(todoToDelete))
            {
                ModelState.AddModelError("", "Something went wront delete category");
            }

            return NoContent();


        }

        private async Task<User> GetUserLoged()
        {
            var loggedIn = User.Identity.Name;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loggedIn);
            return user;
        }
    }
    
}
