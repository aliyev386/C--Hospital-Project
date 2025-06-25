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
        public Doctor(string name, string surname, DateTime workExperience)
        {
            Name = name;
            Surname = surname;
            WorkExperience = workExperience;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nWork experience: {WorkExperience}";
        }
    }
}
