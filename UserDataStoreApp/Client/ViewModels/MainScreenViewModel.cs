using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.BusinessLogic.ServiceLogic.Services;

namespace UserDataStoreApp.Client.ViewModels
{
    public class MainScreenViewModel
    {
        SecurityServices securityServices = new SecurityServices();
        UserServices userServices = new UserServices();
        private string currentUserName;
        private User currentUser;

#region Properties
        public bool IsAdmin{
            get{
                return securityServices.IsAdminUser(currentUserName);
            }
        }

        public string CurrentUserName{
            get{
                return this.currentUserName;
            }
        }

        public User CurrentUser {
            get {
                return this.currentUser;
            }
        }
        #endregion

#region User Methods

        public void AssignUserName(string userName){
            this.currentUserName = userName;
            if(!string.IsNullOrWhiteSpace(currentUserName)){
                AssignCurrentUser();
            }
        }

        private void AssignCurrentUser(){
            currentUser = userServices.GetUser(this.currentUserName);
            if(currentUser == null){
                throw new ArgumentNullException("Sorry, could not find user in database");
            }
        }

#endregion
    }
}
