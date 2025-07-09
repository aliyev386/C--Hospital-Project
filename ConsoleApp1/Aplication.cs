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
        public List<Department> Departments { get; set; }
        public Aplication() 
        { 
            Departments = Aplication.departments;
        }

        public static string[] availableSlots = { "09:00-11:00", "12:00-14:00", "15:00-17:00" };
        public static List<string> emptySlots = new List<string>();

        public static List<Doctor> doctors1 = new List<Doctor> { };

        public static List<Doctor> doctors2 = new List<Doctor> { };

        public static List<Doctor> doctors3 = new List<Doctor> { };

        public static List<Doctor> allDoctors = JsonHelper.LoadFromFile<Doctor>(PathConfig.DoctorsFilePath);
        public static List<Department> departments = new List<Department>{};
        

        

        static Aplication()
        {
            emptySlots = new List<string>();

            doctors1 = new List<Doctor>();
            doctors2 = new List<Doctor>();
            doctors3 = new List<Doctor>();

            departments = new List<Department>
    {
        new Department("Pediatriya", 0, doctors1),
        new Department("Travmatologiya", 0, doctors2),
        new Department("Stomatologiya", 0, doctors3),
    };

            doctors1.AddRange(new List<Doctor> {
        new Doctor("Umid", "Aslanov", "aslanov063@gmail.com", "Aslanov_UA86", "umid123", 23, DateTime.Parse("01-01-2015"), new List<string>(emptySlots), departments[0].Name, "İnsanlara kömək etmək istəyirəm."),
        new Doctor("Huseyin", "Memmedzade", "huseyin.m@gmail.com", "Memmedzade_HM10", "huseyin456", 32, DateTime.Parse("05-08-2010"), new List<string>(emptySlots), departments[0].Name, "Həyat xilas etmək mənim məqsədimdir"),
        new Doctor("Ali", "Agayev", "ali.agayev20@gmail.com", "Agayev_AA20", "ali789", 26, DateTime.Parse("04-03-2020"), new List<string>(emptySlots), departments[0].Name, "Məsuliyyətli və vicdanlıyam"),
    });

            doctors2.AddRange(new List<Doctor> {
        new Doctor("Huseyin", "Memmedzade", "huseyin.m@gmail.com", "Memmedzade_HM10", "huseyin456", 32, DateTime.Parse("05-08-2010"), new List<string>(emptySlots), departments[1].Name, "Həmişə həkim olmaq istəmişəm"),
        new Doctor("Heyder", "Omerzade", "heyder.o@gmail.com", "Omerzade_HO20", "heyder321", 35, DateTime.Parse("04-03-2020"), new List<string>(emptySlots), departments[1].Name, "Tibb mənim həvəsimdir"),
    });

            doctors3.AddRange(new List<Doctor> {
        new Doctor("Resad", "Memmedov", "resad.m@gmail.com", "Memmedov_RM10", "resad654", 30, DateTime.Parse("05-08-2010"), new List<string>(emptySlots), departments[2].Name, "Cəmiyyətə faydalı olmaq istəyirəm"),
        new Doctor("Emin", "Abbasov", "emin.a@gmail.com", "Abbasov_EA20", "emin987", 37, DateTime.Parse("04-03-2020"), new List<string>(emptySlots), departments[2].Name, "Təcrübəmi bölüşmək üçün burdayam"),
        new Doctor("Ibrahim", "Nebiyev", "ibrahim.n@gmail.com", "Nebiyev_IN10", "ibrahim159", 33, DateTime.Parse("05-08-2010"), new List<string>(emptySlots), departments[2].Name, "Peşəmə sadiqəm"),
        new Doctor("Ali", "Nebili", "ali.nebili@gmail.com", "Nebili_AN20", "ali753", 45, DateTime.Parse("04-03-2020"), new List<string>(emptySlots), departments[2].Name, "Yardım etmək üçün hekim olmag isdeyirem"),
    });

            departments[0].DoctorCount = doctors1.Count;
            departments[1].DoctorCount = doctors2.Count;
            departments[2].DoctorCount = doctors3.Count;

            allDoctors = JsonHelper.LoadFromFile<Doctor>(PathConfig.DoctorsFilePath);
        }



        public static List<User> users = new List<User>
        {
            new User("Ayan","Aliyeva","aliyeva@gmail.com","ayan_12","ayan123",16,"45345634635")
        };


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
