using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.BLL.DTO;
using TimeManagementSystem.DAL.Entities;

namespace TimeManagementSystem.BLL.Interfaces
{
    public interface IAccauntService
    {
        PersonDTO Login(LoginDTO login);
        PersonDTO Register(RegisterDTO register);
    }
}
