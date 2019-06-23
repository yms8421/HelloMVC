using System;

namespace BilgeAdam.HelloWeb.Models
{
    public class Person
    {
        private static int id;
        public Person(string firstName, string lastName)
        {
            Id = ++id;
            FirstName = firstName;
            LastName = lastName;
        }
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; set; }
    }
}
