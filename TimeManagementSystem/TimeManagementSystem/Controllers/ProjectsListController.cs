using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeManagementSystem.BLL.DTO;
using TimeManagementSystem.BLL.Interfaces;
using TimeManagementSystem.Models;

namespace TimeManagementSystem.Controllers
{
    public class ProjectsListController : Controller
    {
        IProjectsListService projectsListService;

        public ProjectsListController(IProjectsListService projectsListService)
        {
            this.projectsListService = projectsListService;
        }
        // GET: ProjectsList
        public ActionResult ShowProjectsList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDTO, ProjectViewModel>()).CreateMapper();
            List<ProjectViewModel> projectsList = mapper.Map<IEnumerable<ProjectDTO>,List<ProjectViewModel>>(projectsListService.ShowAllProjects());
            
            return View(projectsList);
        }
    }
}