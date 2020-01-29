using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class BlogContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post>  Posts { get; set; }

        //public DbSet<Writer> Writers  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;initial catalog=Blog;integrated security=true;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (Database.IsSqlServer())
            {



            }
            
            modelBuilder.ApplyConfiguration(new BlogConfig());
            modelBuilder.ApplyConfiguration(new BLogWriterConfig());
            modelBuilder.Ignore<Person>();
            base.OnModelCreating(modelBuilder); 
        }

    }
}
