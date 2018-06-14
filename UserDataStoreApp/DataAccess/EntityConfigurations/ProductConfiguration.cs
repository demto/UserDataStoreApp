using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;

namespace UserDataStoreApp.DataAccess.EntityConfigurations
{
    class ProductConfiguration : EntityTypeConfiguration<Product>
    {

        public ProductConfiguration()
        {
            // Table override

            // Keys

            // Properties

            Property(p => p.IsSalesProduct)
            .IsRequired();

            Property(p => p.ProductName)
            .IsRequired()
            .HasMaxLength(50);

            Property(p => p.ProductPrice)
            .IsRequired();

            Property(p => p.OwnerId)
            .HasColumnName("OwnerUserId");

            // Relationship

            HasRequired(p => p.Owner)
            .WithMany()
            .HasForeignKey(p => p.OwnerId)
            .WillCascadeOnDelete(false);
        }
    }
}
