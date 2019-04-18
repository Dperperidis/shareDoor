﻿using Microsoft.AspNet.Identity.EntityFramework;
using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shareDoor.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<House> Houses { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Area> Areas { get; set; }

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