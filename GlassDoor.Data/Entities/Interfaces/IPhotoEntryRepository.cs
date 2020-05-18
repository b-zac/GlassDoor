using GlassDoor.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlassDoor.Data.Entities.Interfaces
{
    public interface IPhotoEntryRepository
    {
        void CreateEntry(Guid uuid, int userId, string base64, int friendId);
        String Get(int imageId);
        IEnumerable<PhotoEntryModel> GetRecent(int userId);
        PhotoEntryModel GetDetails(int photoId);
        
    }
}
