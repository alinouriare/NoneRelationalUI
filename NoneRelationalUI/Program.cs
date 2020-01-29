using DAL;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace NoneRelationalUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Blog();
            PersonContext context = new PersonContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();


            //context.People.Add(new Entities.Person
            //{
            //    BirthDate = DateTime.Now,
            //    FirstName = "ali",
            //    LastName = "nouri",
            //    //   Home = new Address { AddressLine = "a", PhoneNumber = "3" }
            //    //,
            //    //BankAccount = new BankAccount { AccNumber = "888800" }
            //}); ;


            //context.Teachers.Add(new Entities.Teacher
            //{
            //    //BirthDate = DateTime.Now,
            //    FirstName = "reza",
            //    LastName = "akbari",
            //    //BankAccount = new BankAccount { AccNumber = "3333" },
            //    //Home = new Address { AddressLine = "at", PhoneNumber = "dd" },
            //    Cod = "11",
            //});

            var a = context.People.Find(3);
            a.FirstName = "ddddddddddd";
            context.Update(a);
            context.SaveChanges();

            var ppa= context.People.ToList().Select(c=>c.FullName);
            //var t = context.BankAccounts.ToList();
            //var ww = context.People.Include(c => c.BankAccount).ToList();
            var oo = context.Teachers.ToList();

            Console.WriteLine("");

        }

        ////private static void Blog()
        ////{
        ////    BlogContext context = new BlogContext();
        ////    //context.Database.EnsureDeleted();
        ////    //context.Database.EnsureCreated();
        ////    //SHadoProperty
        ////    var blog = context.Blogs.Where(c => EF.Property<int>(c, "InsertBy") == 1).FirstOrDefault();
        ////    var a = context.Entry(blog).Property("InsertBy").CurrentValue;
        ////    context.Entry(blog).Property("InsertBy").CurrentValue = 1;


        ////    Console.WriteLine("Hello World!");
        ////}
    }
}
