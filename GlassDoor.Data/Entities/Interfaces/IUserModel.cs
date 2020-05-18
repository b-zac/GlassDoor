using System;
using System.Collections.Generic;
using System.Text;

namespace GlassDoor.Data.Entities.Interfaces
{
    public interface IUserModel
    {
        int UserId { get; set; }

        String Email { get; set; }

        String Password { get; set; }

        String UserName { get; set; }

        String DisplayName { get; set; }
    }
}
