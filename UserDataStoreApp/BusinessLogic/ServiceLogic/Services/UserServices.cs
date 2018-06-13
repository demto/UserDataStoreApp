using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.DataAccess;

namespace UserDataStoreApp.BusinessLogic.ServiceLogic.Services
{
    public class UserServices
    {

        private bool DoesUserExist (int? userId, UserDataContext context){
            if(userId == null){
                return false;
            }

            if(context.Users.Find(userId) == null){
                return false;
            }

            return true;
        }

        public bool SaveUser(User user){
            using (var context = new UserDataContext()){
                if(DoesUserExist(user.UserId, context)){
                    return false;
                }

                context.Users.Add(user);
                context.SaveChanges();
            }
            return true;
        }

        public bool DeleteUser(int userId){
            using(var context = new UserDataContext()){
                if (!DoesUserExist(userId, context)){
                    return false;
                }

                var user = context.Users.SingleOrDefault(u => u.UserId == userId);
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return true;
        }

        public bool UpdateUserName (int userId, string newName){
            using(var context = new UserDataContext()){
                if(!DoesUserExist(userId, context)){
                    return false;
                }

                var user = context.Users.SingleOrDefault(u => u.UserId == userId);
                // TODO most likelt would need a security class with a checking mechanism to strip not allowed chars from user entry
                user.UserName = newName;
                context.SaveChanges();
            }
            return true;
        }

        public List<User> GetAllUsersFromDb(){
            using(var context = new UserDataContext()){
                return context.Users.ToList();
            }
        }

        public User GetUser(string name){
            using(var context = new UserDataContext()){
                return context.Users.SingleOrDefault(u => u.UserName == name);
            }
        }
    }
}
