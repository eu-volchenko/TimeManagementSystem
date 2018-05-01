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
    public class LoginController : Controller
    {
        IAccauntService accauntSevice;
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LoginViewModel, LoginDTO>();
                cfg.CreateMap<PersonDTO, PersonViewModel>();
            }).CreateMapper();
            PersonViewModel user = mapper.Map<PersonDTO,PersonViewModel>(accauntSevice.Login(mapper.Map<LoginViewModel, LoginDTO>(model)));
            return RedirectToAction("Index","Home");
        }
    }
}