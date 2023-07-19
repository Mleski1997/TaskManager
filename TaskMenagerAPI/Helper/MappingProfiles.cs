﻿using AutoMapper;
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
        }
    }
}