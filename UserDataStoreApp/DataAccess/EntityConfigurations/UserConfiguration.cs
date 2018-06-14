using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;

namespace UserDataStoreApp.DataAccess.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            // Table overrides

            // Keys

            // Properties

            Property(p => p.NickName)
            .HasColumnOrder(1);

            Property(p => p.UserId)
            .HasColumnName("UserId");

            Property(p => p.UserName)
            .IsRequired()
            .HasMaxLength(50);

            Property(p => p.NickName)
            .IsRequired()
            .HasMaxLength(30);

            Property(p => p.IsAdmin)
            .IsRequired();

            // Relationships
        }
    }
}
