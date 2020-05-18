using GlassDoor.Data.Entities.Interfaces;
using GlassDoor.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GlassDoor.Data.Entities
{
    public class PhotoEntryRepository : IPhotoEntryRepository
    {
        public void CreateEntry(Guid uuid, int userId, string base64, int friendId)
        {
            SQLConnector.UpdateOne(x => {
                x.CommandText = "dbo.Insert_PhotoEntry";
                x.Parameters.AddWithValue("@UserId", userId);
                x.Parameters.AddWithValue("@UUID", uuid);
                x.Parameters.AddWithValue("@Base64", base64);
                x.Parameters.AddWithValue("@FriendId", friendId == 0 ? (object)DBNull.Value : (object)friendId);
            });
        }

        public string Get(int imageId)
        {
            string base64 = string.Empty;

            SQLConnector.Retrieve(x =>
            {
                x.CommandText = "dbo.Get_Image_By_Id";
                x.Parameters.AddWithValue("@ImageId", imageId);
            },
            (DataRow dr) => {
                base64 = dr.Field<String>("Base64Image");
            });

            return base64;
        }

        public PhotoEntryModel GetDetails(int photoId)
        {
            PhotoEntryModel model = null;

            SQLConnector.Retrieve(x =>
            {
                x.CommandText = "dbo.Get_Image_Details_By_Id";
                x.Parameters.AddWithValue("@ImageId", photoId);
            },
            (DataRow dr) => {
                model = new PhotoEntryModel();
                model.PhotoId = dr.Field<int>("Id");
                model.Base64 = dr.Field<String>("Base64Image");
                model.UploadDate = dr.Field<DateTime>("UploadDateTime");
                model.VisitorName = dr.Field<String>("VisitorName");
            });

            return model;
        }

        public IEnumerable<PhotoEntryModel> GetRecent(int userId)
        {
            List<PhotoEntryModel> list = new List<PhotoEntryModel>();

            SQLConnector.RetrieveMultiple(x => {
                x.CommandText = "dbo.Select_Recent_Visitors";
                x.Parameters.AddWithValue("@UserId", userId);
            }, 
            (DataTable dt) => { 
                if(dt != null)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        var model = new PhotoEntryModel
                        {
                            UploadDate = dr.Field<DateTime>("UploadDateTime"),
                            PhotoId = dr.Field<int>("Id"),
                            VisitorName = dr.Field<String>("FriendName")
                        };

                        list.Add(model);
                    }
                }
            });

            return list;
        }
    }
}
