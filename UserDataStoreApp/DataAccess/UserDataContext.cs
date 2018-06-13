using System.Data.Entity;
using UserDataStoreApp.BusinessLogic.Domain;

namespace UserDataStoreApp.DataAccess
{
    class UserDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
