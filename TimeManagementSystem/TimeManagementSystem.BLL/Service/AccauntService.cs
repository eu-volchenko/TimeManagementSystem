using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using TimeManagementSystem.BLL.DTO;
using TimeManagementSystem.BLL.Interfaces;
using TimeManagementSystem.DAL.Entities;
using TimeManagementSystem.DAL.Interfaces;

namespace TimeManagementSystem.BLL.Service
{
    class AccauntService : IAccauntService
    {
        IUnitOfWork _uoW;

        public AccauntService(IUnitOfWork _uoW)
        {
            this._uoW = _uoW;
        }
        public PersonDTO Login(LoginDTO login)
        {
            User user = null;
            Person person = null;
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Person, PersonDTO>();
            }).CreateMapper();
            using (_uoW)
            {
                user = _uoW.Users.Get(x => x.Name == login.Name && x.Password == login.Password);
                person = _uoW.Persons.Get(x => x.User == user);
            }
            return (mapper.Map<Person, PersonDTO>(person));
        }

        public PersonDTO Register(RegisterDTO register)
        {
            UserDTO user = null;
            var mapper = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<User, UserDTO>();
               cfg.CreateMap<UserDTO, User>();
               cfg.CreateMap<Person, PersonDTO>();
           }).CreateMapper();
            user = mapper.Map<User, UserDTO>(_uoW.Users.Get(x => x.Email == register.Email));
            if (user == null)
            {
                user = new UserDTO()
                {
                    Email = register.Email,
                    Name = register.Name,
                    Age = register.Age,
                    Password = register.Password,
                };
                _uoW.Users.Create(mapper.Map<UserDTO, User>(user));
            }
            else return null;
            PersonDTO person = mapper.Map<Person, PersonDTO>(_uoW.Persons.Get(x => x.Email == register.Email));
            return person;
        }
    }
}
