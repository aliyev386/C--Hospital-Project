using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interfaces;
namespace ConsoleApp1.AbstractClass
{
    public abstract class Person : IGenerateUsername
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private string _email;
        public string Email
        {
            get; set;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        protected Person() { }
        protected Person(string name, string surname, string email, string username, string password, int age)
        {
            Name = name;
            Surname = surname;
            Email = email;
            UserName = username;
            Password = password;
            Age = age;
        }

        public string GenerateUsername(string name, string surname)
        {
            Random rand = new Random();
            int number = rand.Next(10, 99);
            string initials = $"{name[0]}{surname[0]}".ToLower();
            string username = $"{surname}_{initials}{number}";
            return username;
        }


    }
}
