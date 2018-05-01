using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeManagementSystem.BLL.DTO;
using TimeManagementSystem.BLL.Interfaces;
using TimeManagementSystem.Models;

namespace TimeManagementSystem.Controllers
{
    public class ProjectController : Controller
    {
        IProjectService _projectService;
        public ProjectController(IProjectService _projectService)
        {
            this._projectService = _projectService;
        }
        // GET: Project
        [HttpGet]
        public ActionResult AddProject()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult AddProject(ProjectViewModel project)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectViewModel, ProjectDTO>()).CreateMapper();
            var t = mapper.Map<ProjectViewModel, ProjectDTO>(project);
            _projectService.AddProject(t);
            return View("Home");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectDTO, ProjectViewModel>();
            }).CreateMapper();
            ProjectViewModel projectViewModel = mapper.Map<ProjectDTO, ProjectViewModel>(_projectService.Find(id.Value));
            if (projectViewModel == null) return HttpNotFound();
            return View(projectViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProjectViewModel project)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectViewModel, ProjectDTO>()).CreateMapper();
            var t = mapper.Map<ProjectViewModel, ProjectDTO>(project);
            _projectService.Edit(t);
            return View("Home");
        }

        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult ShowProjectsList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDTO, ProjectViewModel>()).CreateMapper();
            List<ProjectViewModel> projectsList = mapper.Map<IEnumerable<ProjectDTO>, List<ProjectViewModel>>(_projectService.ShowAllProjects());

            return View("Index",projectsList);
        }

    }
}