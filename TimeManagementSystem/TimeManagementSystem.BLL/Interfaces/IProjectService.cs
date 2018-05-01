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
        IEnumerable<ProjectDTO> ShowAllProjects();
        void AddUsers(PersonDTO person, ProjectDTO project);
        void Edit(ProjectDTO project);
        ProjectDTO Find(int id);
    }
}
