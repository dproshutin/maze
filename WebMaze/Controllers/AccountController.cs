using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMazeKZ.DBStuff;
using WebMazeKZ.DBStuff.Model;
using WebMazeKZ.DBStuff.Repository;
using WebMazeKZ.Models.Account;

namespace WebMazeKZ.Controllers
{
    public class AccountController : Controller
    {
        private CitizenUserRepository citizenUserRepository;
        private IMapper mapper;

        public AccountController(CitizenUserRepository citizenUserRepository, IMapper mapper)
        {
            this.citizenUserRepository = citizenUserRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            var viewModel = new LoginViewModel() 
            {
                Login = "Test",
                Password = "Test"
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Registration(LoginViewModel viewModel)
        {
            //var user = new CitizenUser()
            //{
            //    Login = viewModel.Login,
            //    Password = viewModel.Password
            //};
            var user = mapper.Map<CitizenUser>(viewModel);

            citizenUserRepository.Save(user);

            return View();
        }

        public IActionResult Profile(long id)
        {
            var citizen = citizenUserRepository.Get(id);

            //var viewModel = new ProfileViewModel()
            //{
            //    Login = dbModel.Login,
            //    AvatarUrl = dbModel.AvatarUrl
            //};
            var viewModel = mapper.Map<ProfileViewModel>(citizen);

            return View(viewModel);
        }
    }
}
