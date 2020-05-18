using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.WebAPI.Models
{
    public class PhotoUploadModel
    {
        public int UserId { get; set; }
        public String ImageBase64 { get; set; }
        public int FriendId { get; set; }
    }
}
