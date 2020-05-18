using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlassDoor.Data.Entities.Interfaces;
using GlassDoor.Data.Entities.Models;
using GlassDoor.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlassDoor.WebApp.Controllers
{
    [Authorize]
    public class BellController : Controller
    {
        protected IPhotoEntryRepository PhotoEntryRepository;
        protected IUserRepository UserRepository;

        public BellController(IPhotoEntryRepository photoEntryRepository, IUserRepository userRepository)
        {
            this.PhotoEntryRepository = photoEntryRepository;
            this.UserRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            int userId = User.Identity.GetUserId();

            return View(this.PhotoEntryRepository.GetRecent(userId));
        }

        [HttpGet]
        public IActionResult FriendsList()
        {
            int userId = User.Identity.GetUserId();

            return View(this.UserRepository.GetFriends(userId));
        }

        [HttpGet]
        public IActionResult AddFriend()
        {
            //var model = new FriendPhotoEntryModel();
            //model.UserId = User.Identity.GetUserId();
            return View(/*model*/);
        }

        [HttpPost]
        public IActionResult AddFriend(FriendPhotoEntryModel model)
        {
            if (ModelState.IsValid)
            {
                this.UserRepository.AddFriend(model);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult VisitorDetail(int id)
        {
            return View(this.PhotoEntryRepository.GetDetails(id));
        }

    }
}
