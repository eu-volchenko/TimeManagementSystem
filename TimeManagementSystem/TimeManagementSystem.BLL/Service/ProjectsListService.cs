using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.BLL.DTO;
using TimeManagementSystem.BLL.Interfaces;
using TimeManagementSystem.DAL.Entities;
using TimeManagementSystem.DAL.Interfaces;

namespace TimeManagementSystem.BLL.Service
{
    class ProjectsListService : IProjectsListService
    {
        IUnitOfWork unitOfWork;
        public ProjectsListService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ProjectDTO> ShowAllProjects()
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProjectDTO, Project>();
                cfg.CreateMap<Project, ProjectDTO>();
            }).CreateMapper();
            var ListOfProjects = mapper.Map<IEnumerable<Project>, List<ProjectDTO>>(unitOfWork.Projects.GetAll());
            return ListOfProjects;
        }

    }
}
