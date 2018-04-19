using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.BLL.DTO;

namespace TimeManagementSystem.BLL.Interfaces
{
    public interface IProjectService
    {
        void AddProject(ProjectDTO project);
    }
}
