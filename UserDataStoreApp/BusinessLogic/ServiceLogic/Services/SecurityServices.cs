using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.DataAccess;

namespace UserDataStoreApp.BusinessLogic.ServiceLogic.Services
{
    public class SecurityServices
    {
        private UserServices userSercices = new UserServices();

        public bool IsAdminUser(string userName){
            var currentUser = userSercices.GetUser(userName);

            if (currentUser != null)
            {
                return currentUser.IsAdmin;
            }
            return false;
        }
    }
}
