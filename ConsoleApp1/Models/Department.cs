﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class Department
    {
        public string Name { get; set; }
        public int DoctorCount { get; set; }
        public List<Doctor> Doctors { get; set; }
        public Department() { }
        public Department(string name, int doctorCount, List<Doctor> doctors)
        {
            Name = name;
            DoctorCount = doctorCount;
            Doctors = doctors;
        }


    }
}
