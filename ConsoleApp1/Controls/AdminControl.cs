﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Controls
{
    public class AdminControl
    {
        public object GetDoctors()
        {
            var data = UserControl.allDoctors;
            
            return data;
                        
        }
        
        
        


    }
}
