using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GlassDoor.Data.Entities.Interfaces;
using GlassDoor.WebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace GlassDoor.WebAPI.Controllers
{
    public class UploadController : Controller
    {
        protected IPhotoEntryRepository PhotoEntryRepository;

        public UploadController(IPhotoEntryRepository photoEntryRepository)
        {
            this.PhotoEntryRepository = photoEntryRepository;
        }

        public FileContentResult Get(int id)
        {
            string base64 = this.PhotoEntryRepository.Get(id);

            return File(Convert.FromBase64String(base64), "image/png", "test.png"); //"data:image/png;base64," + ;
        }

        //[HttpPost]
        public IActionResult Index(PhotoUploadModel model)
        {
            try
            {
                Guid uuid = Guid.NewGuid();
                
                this.PhotoEntryRepository.CreateEntry(uuid, model.UserId, model.ImageBase64, model.FriendId);

                return Json(true);
            }
            catch(Exception e)
            {
                return Json(new { exception = e.ToString() });
            }
        }
    }
}