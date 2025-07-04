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
        {get;set;
            //get
            //{
            //    return _email;
            //}
            //set
            //{
            //    string emailPattern = @"^[\w!#$%&'*+\-/=?\^_{|}~]+(\.[\w!#$%&'*+\-/=?\^_{|}~]+)*"
            //                        + "@"
            //                        + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
            //    if (Regex.IsMatch(Email, emailPattern))
            //    {
            //        _email = value;
            //    }
            //    else
            //    {
            //        try
            //        {
            //            throw new Exception("Error");
            //        }
            //        catch (Exception ex)
            //        {
            //            Log.Error(ex, "Wrong email");
            //        }
            //    }

            //}
        }
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
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



    }
}
