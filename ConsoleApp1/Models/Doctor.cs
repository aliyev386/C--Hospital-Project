using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class Doctor : Person
    {
        public DateTime WorkExperience { get; set; }
        public List<string> ReservedTimes { get; set; } = new List<string>();
        public Doctor() { }
        public Doctor(string name, string surname,string email,string username,string password, DateTime workExperience)
        {
            Name = name;
            Surname = surname;
            Email = email;
            UserName = username;
            Password = password;
            WorkExperience = workExperience;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nEmail: {Email}\nUsername: {UserName}\nPassword: {Password}\nWork experience: {WorkExperience}";
        }
    }
}
