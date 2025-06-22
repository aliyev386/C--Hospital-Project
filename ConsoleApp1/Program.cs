using ConsoleApp1.Controls;
using ConsoleApp1.Models;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1;
class Program
{
    private List<Department> departments = new List<Department>();
    
    static void HospitalTxt()
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine(@"
     ░░░░░░░      ██╗░░██╗░█████╗░░██████╗██████╗░██╗████████╗░█████╗░██╗░░░░░      ░░░░░░░
     ░░██╗░░      ██║░░██║██╔══██╗██╔════╝██╔══██╗██║╚══██╔══╝██╔══██╗██║░░░░░      ░░██╗░░
     ██████╗      ███████║██║░░██║╚█████╗░██████╔╝██║░░░██║░░░███████║██║░░░░░      ██████╗
     ╚═██╔═╝      ██╔══██║██║░░██║░╚═══██╗██╔═══╝░██║░░░██║░░░██╔══██║██║░░░░░      ╚═██╔═╝
     ░░╚═╝░░      ██║░░██║╚█████╔╝██████╔╝██║░░░░░██║░░░██║░░░██║░░██║███████╗      ░░╚═╝░░
     ░░░░░░░      ╚═╝░░╚═╝░╚════╝░╚═════╝░╚═╝░░░░░╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝      ░░░░░░░");
        
    Console.ResetColor();
}


    static void Main(string[] args)
    {
        

        User user = new User();
        Doctor doctor = new Doctor();
        Admin admin = new Admin();

        UserAdminDoctorControl userControl = new UserAdminDoctorControl();
        
        string[] panelOptions = { @"
█▀▀█╗ █▀▀▄╗ █▀▄▀█╗ █╗ █▀▀▄╗ 
█▄▄█║ █  █╝ █ ▀ █║ █║ █  █║ 
▀  ▀╝ ▀▀▀   ▀   ▀╝ ▀╝ ▀  ▀╝ ",
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
        if(selectedIndex == 0)
        {

        }
        else if(selectedIndex == 1)
        {
            Console.Clear();
            

            userControl.SignInOrSignUp();
        }

    }
}



