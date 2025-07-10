using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Reservation
    {
        public string DoctorUserName { get; set; }
        public string TimeSlot { get; set; }
        public string ReservedByUserName { get; set; }
    }
}
