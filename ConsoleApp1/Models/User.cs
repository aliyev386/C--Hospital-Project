using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.AbstractClass;
using ConsoleApp1.Interfaces;
namespace ConsoleApp1.Models
{
    public class User : Person , IGenerateUsername
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
        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nEmail: {Email}\nUsername: {UserName}\nPassword: {Password}\nPhone number: {PhoneNumber}";
        }

    }
}
