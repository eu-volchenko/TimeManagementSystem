using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.BLL.DTO;
using TimeManagementSystem.BLL.Infrastructure;
using TimeManagementSystem.BLL.Interfaces;
using TimeManagementSystem.DAL.Entities;
using TimeManagementSystem.DAL.Interfaces;
using TimeManagementSystem.DAL.Repositories;

namespace TimeManagementSystem.BLL.Service
{
    class ProjectService : IProjectService
    {
        IUnitOfWork Database;

        public ProjectService(IUnitOfWork UoW)
        {
            Database = UoW;
        }

        public void Edit(ProjectDTO project)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Project, ProjectDTO>();
                    cfg.CreateMap<ProjectDTO, Project>();
                }).CreateMapper();
                var ListOfProjects = mapper.Map<IEnumerable<Project>, List<ProjectDTO>>(Database.Projects.GetAll());
                foreach (var item in ListOfProjects)
                {
                    if (item.Name == project.Name) throw new ValidationException("Name must be unique", "Error");
                    if (item.Abbreviation == project.Abbreviation) throw new ValidationException("Abbreviation must be unique", "Error");
                }
                Database.Projects.Update(mapper.Map<ProjectDTO, Project>(project));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddUsers(PersonDTO person, ProjectDTO project)
        {
            TeammateDTO teammateDTO = new TeammateDTO()
            {
                IdPerson = person.Id,
                IdProject = project.Id
            };
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeammateDTO, Teammate>();
            }).CreateMapper();
            Database.Teammates.Create(mapper.Map<TeammateDTO, Teammate>(teammateDTO));
        }

        public void AddProject(ProjectDTO project)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, ProjectDTO>();
                cfg.CreateMap<ProjectDTO, Project>();
            }).CreateMapper();
                var ListOfProjects = mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(Database.Projects.GetAll());
                foreach (var item in ListOfProjects)
                {
                    if (item.Name == project.Name) throw new ValidationException("Name must be unique", "Error");
                    if (item.Abbreviation == project.Abbreviation) throw new ValidationException("Abbreviation must be unique", "Error");
                }
                Database.Projects.Create(mapper.Map<ProjectDTO, Project>(project));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
