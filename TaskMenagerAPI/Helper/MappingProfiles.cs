using AutoMapper;
using TaskMenagerAPI.DTO;
using TaskMenagerAPI.Models;

namespace TaskMenagerAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<ToDo, ToDoDTO>();
            CreateMap<ToDoDTO, ToDo>();
            CreateMap<User, RegisterUserDto>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, UserWithTaskDTO>();
            CreateMap<UserWithTaskDTO, User>();

            CreateMap<UserActiveDTO, User>();
            CreateMap<User, UserActiveDTO>();

          
            
        }
    }
}
