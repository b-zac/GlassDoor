using GlassDoor.Data.Entities.Interfaces;
using GlassDoor.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GlassDoor.Data.Entities
{
    public class UserRepository : IUserRepository
    {
        public IUserModel GetByEmailAddress(string email)
        {
            UserModel model = null;

            SQLConnector.Retrieve(x => {
                x.CommandText = "dbo.Select_User_By_Email";
                x.Parameters.AddWithValue("@Email", email);
            }, 
            (DataRow dr) =>
            {

                if (dr != null) {
                    model = new UserModel
                    {
                        UserId = dr.Field<int>("Id"),
                        DisplayName = dr.Field<String>("DisplayName"),
                        Email = dr.Field<String>("Email"),
                        Password = dr.Field<String>("Password"),
                        UserName = dr.Field<String>("UserName")
                    };
                }
            });

            return model;
        }

        public void Create(string email, string password)
        {
            SQLConnector.UpdateOne(x => {
                x.CommandText = "";
                x.Parameters.AddWithValue("@Email", email);
                x.Parameters.AddWithValue("@Password", password);
            });
        }

        public bool Register(IUserModel model)
        {
            int rows = SQLConnector.UpdateOne(x => {
                x.CommandText = "dbo.Insert_New_User";
                x.Parameters.AddWithValue("@Email", model.Email);
                x.Parameters.AddWithValue("@Password", model.Password);
                x.Parameters.AddWithValue("@UserName", model.UserName);
                x.Parameters.AddWithValue("@DisplayName", model.DisplayName);
            });

            return rows > 0;
        }

        public IEnumerable<FriendPhotoEntryModel> GetFriends(int userId)
        {
            List<FriendPhotoEntryModel> list = new List<FriendPhotoEntryModel>();

            SQLConnector.RetrieveMultiple(x => {
                x.CommandText = "dbo.Select_User_Friends_By_UserId";
                x.Parameters.AddWithValue("@UserId", userId);
            },
            (DataTable dt) => {

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FriendPhotoEntryModel model = new FriendPhotoEntryModel
                        {
                            FriendId = dr.Field<int>("Id"),
                            FriendName = dr.Field<String>("FriendName"),
                            ImageBase64 = dr.Field<String>("FriendBase64Image"),
                            UserId = dr.Field<int>("UserId"),
                            ImageExtension = dr.Field<string>("Extension")
                        };

                        list.Add(model);
                    }
                }
            
            });

            return list;
        }

        public void AddFriend(FriendPhotoEntryModel model)
        {
            SQLConnector.UpdateOne(x => {
                x.CommandText = "dbo.Insert_New_Friend";
                x.Parameters.AddWithValue("@FriendName", model.FriendName);
                x.Parameters.AddWithValue("@Base64", model.ImageBase64);
                x.Parameters.AddWithValue("@UserId", model.UserId);
                x.Parameters.AddWithValue("@Extension", model.ImageExtension);
            });
        }
    }
}
