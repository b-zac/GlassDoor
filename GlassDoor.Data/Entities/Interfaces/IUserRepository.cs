using GlassDoor.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlassDoor.Data.Entities.Interfaces
{
    public interface IUserRepository
    {
        IUserModel GetByEmailAddress(String email);
        bool Register(IUserModel model);
        IEnumerable<FriendPhotoEntryModel> GetFriends(int userId);
        void AddFriend(FriendPhotoEntryModel model);
    }
}
