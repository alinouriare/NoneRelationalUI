using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Person
    {
        //public BankAccount  BankAccount { get; set; }
        public int Id { get; set; }
        //[ConcurrencyCheck]
        public string FirstName { get; set; }

      [NotMapped]
        public string FullName => FirstName + LastName;


        public DateTime BirthDate { get; set; }

        public int Year { get;private set; }


        public string LastName { get; set; }

        //public Address  Home { get; set; }
        //[Timestamp]
        public byte[] Token { get; set; }
    }


}
