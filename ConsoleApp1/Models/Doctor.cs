using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.AbstractClass;

namespace ConsoleApp1.Models
{
    public class TimeSlot
    {
        public string Interval { get; set; }
        public bool IsReserved { get; set; }
        public TimeSlot(string interval)
        {
            Interval = interval;
            IsReserved = false;
        }
    }
    public class Doctor : Person
    {
        public DateTime WorkExperience { get; set; }
        public List<string> ReservedTimeSlots { get; set; } = new();
        public string Department { get; set; }
        public List<string> TimeSlots { get; set; } = new List<string>();
        public string MotivationText { get; set; }
        public Doctor() { }
        public Doctor(string name, string surname, string email, string username, string password, int age, DateTime workExperience, List<string> reservedSlots = null, string department = null, string motivationText = "") 
            : base(name,surname,email,username,password,age)
        {
            Name = name;
            Surname = surname;
            Email = email;
            UserName = username;
            Password = password;
            WorkExperience = workExperience;
            ReservedTimeSlots = reservedSlots ?? new List<string>();  //burda elemeyimin meksedi oduki eyer reservedSlots null olsa list yaranir. Eyer null deyilse ozunu isdedir
            Department = department;
            MotivationText = motivationText;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nEmail: {Email}\nUsername: {UserName}\nPassword: {Password}\nWork experience: {WorkExperience}\nMotivation text: {MotivationText}";
        }
    }
}
