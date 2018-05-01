using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TimeManagementSystem.BLL.DTO;
using TimeManagementSystem.BLL.Interfaces;
using TimeManagementSystem.Models;

namespace TimeManagementSystem.Controllers
{
    public class RegistrationController : Controller
    {
        IAccauntService accauntService;
        public RegistrationController(IAccauntService accauntService)
        {
            this.accauntService = accauntService;
        }
        // GET: Default
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModelView model)
        {

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterModelView, RegisterDTO>();
                cfg.CreateMap<PersonDTO, PersonViewModel>();
            }).CreateMapper();
            if (ModelState.IsValid)
            {

                var register = accauntService.Register(mapper.Map<RegisterModelView, RegisterDTO>(model));
                PersonViewModel person = mapper.Map<PersonDTO,PersonViewModel>(register);
                if (person!=null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                    return View();
                }
            }
            return View();
        }
    }
}