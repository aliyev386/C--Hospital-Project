using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email
        {get;set;
            //get
            //{
            //    return Email;
            //}
            //set
            //{
            //    string emailPattern = @"^[\w!#$%&'*+\-/=?\^_{|}~]+(\.[\w!#$%&'*+\-/=?\^_{|}~]+)*"
            //                        + "@"
            //                        + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
            //    if (Regex.IsMatch(Email, emailPattern))
            //    {
            //        Email = value;
            //    }

            //}
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age
        {
            get => Age;
            set
            {
                if (Age < 0) Age = 0;
            }
        }




    }
}
