using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataStoreApp.BusinessLogic.Domain
{
    class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
