using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{

    public class DateTimeValueGenerator : ValueGenerator<DateTime>
    {
        public override bool GeneratesTemporaryValues => false;

        public override DateTime Next( EntityEntry entry)
        {
            return DateTime.Now.AddYears(-10);
        }
    }
    public class PersonContext:DbContext
    {

        public DbSet<Person> People { get; set; }

        public DbSet<Teacher>  Teachers { get; set; }

        //public DbSet<BankAccount>  BankAccounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;initial catalog=PersonDb;integrated security=true;");
 
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().ToTable("People");
            //modelBuilder.Entity<BankAccount>().ToTable("People");
            //modelBuilder.Entity<Person>().HasOne(c => c.BankAccount).WithOne(c => c.Person)
            //    .HasForeignKey<Person>(c => c.Id);
            //modelBuilder.Entity<Person>().OwnsOne(c => c.Home);
            modelBuilder.Entity<Person>().HasDiscriminator<int>("Split").HasValue<Person>(1)
                 .HasValue<Teacher>(2);
            modelBuilder.HasDbFunction(() => DbFunction.MyFunction());

            modelBuilder.Entity<Person>().Property(c => c.Year)
                .HasComputedColumnSql("DatePart(yyyy,[BirthDate])");

            modelBuilder.Entity<Person>().Property(c => c.BirthDate).HasValueGenerator<DateTimeValueGenerator>();
            //modelBuilder.Entity<Person>().Property(c => c.BirthDate).HasDefaultValueSql("getdate()");

            //modelBuilder.HasSequence<int>("TestInt", c => {

            //    c.HasMin(12);
            //    c.IncrementsBy(2);

            //});

            //modelBuilder.Entity<Person>().Property(c => c.FirstName)
            //    .IsConcurrencyToken();
            modelBuilder.Entity<Person>().Property(c => c.Token).IsRowVersion();

            //modelBuilder.Entity<BankAccount>().Property(c => c.RowVersion).IsRowVersion();

            modelBuilder.Entity<Person>().HasData(

                new Person { BirthDate=DateTime.Now,
                FirstName="1",
                LastName="2",
               
                Id=1
              
                }

                );

        }

      

        public static class DbFunction
        {

            //[DbFunction]
            public static int MyFunction()
            {


                throw new NotImplementedException();
            }

        }
    }
}
