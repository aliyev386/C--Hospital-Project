using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.AbstractClass;
namespace ConsoleApp1.Models
{
    public class Admin : Person
    {
        
        public Admin() { }
        public Admin(string name, string surname, string email, string username, string password, int age)
            : base(name,surname,email,username,password,age)
        {
            Name = name;
            Surname = surname;
            UserName = username;
            Password = password;
            Age = age;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nEmail: {Email}\nUsername: {UserName}\nPassword: {Password}";
        }
    }
}
