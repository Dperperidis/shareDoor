using Microsoft.AspNet.Identity.EntityFramework;
using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace shareDoor.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<House> Houses { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<HousePhoto> HousePhotos { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }

        


        public ApplicationDbContext()
            : base("DataContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                 .HasMany(a => a.UserPhotos)
                 .WithOptional(a => a.User)
                 .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicationUser>()
                 .HasMany(a => a.Houses)
                 .WithOptional(a => a.User)
                 .WillCascadeOnDelete(true);

            modelBuilder.Entity<House>()
                .HasMany(a => a.HousePhotos)
                .WithOptional(a => a.House)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<House>()
                .HasRequired(a => a.State)
                .WithMany(a => a.Houses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<House>()
                .HasRequired(a => a.Area)
                .WithMany(a => a.Houses)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}