﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Configuration;
using Data.Entities;

namespace Data
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DBContext(DbContextOptions<DBContext> dbContext) : base(dbContext)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}

