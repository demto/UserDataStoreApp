﻿using System.Data.Entity;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.DataAccess.EntityConfigurations;

namespace UserDataStoreApp.DataAccess
{
    class UserDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
