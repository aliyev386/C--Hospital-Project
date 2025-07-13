using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.AbstractClass;
namespace ConsoleApp1.Models
{
    public class Candidate : Person
    {
        public DateTime WorkExperience { get; set; }
        public List<string> ReservedTimeSlots { get; set; } = new();
        public string Department { get; set; }
        public List<string> TimeSlots { get; set; } = new List<string>();
        public string MotivationText { get; set; }
        public Candidate() { }
        public Candidate(string name, string surname, string email, string username, string password, int age, DateTime workExperience, List<string> reservedSlots = null, string department = null, string motivationText = "")
            : base(name, surname, email, username, password, age)
        {
            Name = name;
            Surname = surname;
            Email = email;
            UserName = username;
            Password = password;
            WorkExperience = workExperience;
            ReservedTimeSlots = reservedSlots ?? new List<string>();
            Department = department;
            MotivationText = motivationText;
        }
        public override string GenerateUsername()
        {
            Random rand = new Random();
            int number = rand.Next(10, 99);
            string initials = $"{Name[0]}{Surname[0]}".ToLower();
            string username = $"{Surname}_{initials}{number}";
            return username;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nEmail: {Email}\nUsername: {UserName}\nPassword: {Password}\nWork experience: {WorkExperience}\nMotivation text: {MotivationText}";
        }

    }
}
