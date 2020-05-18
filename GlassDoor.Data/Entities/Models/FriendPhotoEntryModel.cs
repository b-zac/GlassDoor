using System;
using System.Collections.Generic;
using System.Text;

namespace GlassDoor.Data.Entities.Models
{
    public class FriendPhotoEntryModel
    {
        public int FriendId { get; set; }
        public String FriendName { get; set; }
        public String ImageBase64 { get; set; }
        public int UserId { get; set; }
        public string ImageExtension { get; set; }
    }
}
