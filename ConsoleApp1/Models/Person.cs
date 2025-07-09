using ConsoleApp1.Helpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private string _email;
        public string Email
        {
            get;set;
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
        public virtual string GenerateUsername()
        {
            Random rand = new Random();
            int number = rand.Next(10, 99);
            string initials = $"{Name[0]}{Surname[0]}".ToLower();
            string username = $"{Surname}_{initials}{number}";
            return username;
        }



    }
}
