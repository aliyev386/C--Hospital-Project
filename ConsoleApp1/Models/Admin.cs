using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class Admin : Person
    {
        public string Fullname {  get; set; }
        public string Password {  get; set; }
        public Admin() { }
        public Admin(string name,string surname,int age,string fullname,string password)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Fullname = fullname;
            Password = password;

        }
    }
}
