using GlassDoor.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GlassDoor.Data.Entities.Models
{
    public class UserModel : IUserModel
    {
        public int UserId { get; set; }

        [Required, MaxLength(128, ErrorMessage = "Email must be up to 128 characters long.")]
        public String Email { get; set; }

        [Required, MinLength(5, ErrorMessage = "Password must be at least 5 characters long.")]
        public String Password { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [MaxLength(128, ErrorMessage = "User Name must be up to 128 characters long.")]
        public String UserName { get; set; }

        [MaxLength(256, ErrorMessage = "Display name must be up to 256 characters long.")]
        [Required(ErrorMessage = "Display name is required.")]
        public String DisplayName { get; set; }
    }
}
