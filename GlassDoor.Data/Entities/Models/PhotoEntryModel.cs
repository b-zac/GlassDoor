using System;
using System.Collections.Generic;
using System.Text;

namespace GlassDoor.Data.Entities.Models
{
    public class PhotoEntryModel
    {
        public int PhotoId { get; set; }
        public Guid UUID { get; set; }
        public DateTime UploadDate { get; set; }
        public int UserId { get; set; }
        public String Base64 { get; set; }
        public String VisitorName { get; set; }
    }
}
