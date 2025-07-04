using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class User : Person
    {
        public string PhoneNumber { get; set; }
        public User() { }
        public User(string name, string surname, string email, string username, string password, int age, string phoneNumber)
            :base (name, surname, email, username, password,age) 
        {
            Name = name;
            Surname = surname;
            Email = email;
            UserName = username;
            Password = password;
            Age = age;
            PhoneNumber = phoneNumber;
        }
        public string GenerateUsername()
        {
            Random rand = new Random();
            int number = rand.Next(10, 99);
            string initials = $"{Name[0]}{Surname[0]}".ToLower();
            string username = $"{Surname}_{initials}{number}";
            return username;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nEmail: {Email}\nUsername: {UserName}\nPassword: {Password}\nPhone number: {PhoneNumber}";
        }

    }
}
