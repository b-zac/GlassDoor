using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlassDoor.Data.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlassDoor.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        protected IUserRepository UserRepository;

        public HomeController(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetFriends(int id)
        {
            return Json(this.UserRepository.GetFriends(id));
        }

        public IActionResult Index(string email)
        {
            return Json(this.UserRepository.GetByEmailAddress(email));
        }
    }
}