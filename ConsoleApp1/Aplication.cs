using ConsoleApp1.Controls;
using ConsoleApp1.Helpers;
using ConsoleApp1.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Aplication
    {
        public Aplication() { }

        

        static void HospitalTxt()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
                            ██╗░░██╗░█████╗░░██████╗██████╗░██╗████████╗░█████╗░██╗░░░░░
                            ██║░░██║██╔══██╗██╔════╝██╔══██╗██║╚══██╔══╝██╔══██╗██║░░░░░
                            ███████║██║░░██║╚█████╗░██████╔╝██║░░░██║░░░███████║██║░░░░░
                            ██╔══██║██║░░██║░╚═══██╗██╔═══╝░██║░░░██║░░░██╔══██║██║░░░░░
                            ██║░░██║╚█████╔╝██████╔╝██║░░░░░██║░░░██║░░░██║░░██║███████╗
                            ╚═╝░░╚═╝░╚════╝░╚═════╝░╚═╝░░░░░╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝");

            Console.ResetColor();
        }


        public static void Start()
        {
            

            Logs.ConfigureLogger();
            Log.Information("=============Hospital=============");
            Log.Information("Program started.");

            

            UserControl userControl = new UserControl();
            Doctor doctorControl = new Doctor();
            Admin adminControl = new Admin();

            string[] panelOptions = { @"



 ▄▀▄  █▀▀▄╗ █▀▄▀█╗ █╗ █▀▀▄╗ 
 █▀█  █  █╝ █ ▀ █║ █║ █  █║ 
█   █ ▀▀▀   ▀   ▀╝ ▀╝ ▀  ▀╝",
@"                 
█  █╗ █▀▀  █▀▀ █▀▀█╗ 
█  █║ ▀▀█╗ █▀▀ █▄▄▀╝ 
 ▀▀▀╝ ▀▀▀╝ ▀▀▀ ▀ ▀▀ ",
@"
█▀▀▄╗ █▀▀█╗ █▀▀ ▀▀█▀▀  █▀▀█╗ █▀▀█╗ 
█  █╝ █  █║ █╗    █║   █  █║ █▀█▀╝ 
▀▀▀   ▀▀▀▀╝ ▀▀▀   ▀╝   ▀▀▀▀╝ ▀  ▀" };
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();

                HospitalTxt();

                for (int i = 0; i < panelOptions.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("" + panelOptions[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("" + panelOptions[i]);
                        Console.ResetColor();
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? panelOptions.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % panelOptions.Length;
                }

            } while (key != ConsoleKey.Enter);
            if (selectedIndex == 0)
            {
                Console.Clear();
                Logs.LogInfo("Admin selected");
                AdminControl.LogIn(AdminControl.GetAllAdmins());

            }
            else if (selectedIndex == 1)
            {
                Console.Clear();
                Logs.LogInfo("User selected");
                UserControl.SignInOrSignUp();

            }
            else if (selectedIndex == 2)
            {
                Console.Clear();
                Logs.LogInfo("Doctor selected");
                DoctorControl.SignInOrSignUp();

            }

        }
    }
}
