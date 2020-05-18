using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GlassDoor.Data.Entities.Interfaces;
using GlassDoor.Data.Entities.Models;
using GlassDoor.Util;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GlassDoor.WebApp.Controllers
{
    public class AccountController : Controller
    {
        protected IUserRepository UserRepository;

        public AccountController(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }

        [HttpGet]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync();
            Response.Redirect("/Account/Login");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserModel());
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = PasswordHandler.Hash(model.Password);

                if (this.UserRepository.Register(model))
                {
                    Response.Redirect("/Account/Login");
                    //return null;
                }
                else
                {
                    // Failed
                    ModelState.AddModelError("FailedToRegister", "Something went wrong.");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = this.UserRepository.GetByEmailAddress(email);

            if(user != null)
            {
                if(PasswordHandler.Verify(password, user.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, user.UserId.ToString())
                    };

                    await HttpContext.ReAuthenticate(claims);
                    Response.Redirect("/Bell");
                }
                else
                {
                    ModelState.AddModelError("UserInvalidPassword", "Invalid Password.");
                }
            }
            else
            {
                //  No user found
                ModelState.AddModelError("UserNotFound", "User Not Found.");
            }

            return View();
        }

    }
}