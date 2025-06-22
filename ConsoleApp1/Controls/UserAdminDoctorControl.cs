using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp1.Controls
{

    class UserAdminDoctorControl
    {
        private List<Department> departments = new List<Department>();
        public static void ObjectsAndList()
        {
            Doctor doctor1 = new Doctor("Umid", "Aslanov", DateTime.Parse("01-01-2015"), "00:00-00:00");
            Doctor doctor2 = new Doctor("Huseyin", "Memmedzade", DateTime.Parse("05-08-2010"), "00:00-00:00");
            Doctor doctor3 = new Doctor("Ali", "Agayev", DateTime.Parse("04-03-2020"), "00:00-00:00");
            Doctor doctor4 = new Doctor("Huseyin", "Memmedzade", DateTime.Parse("05-08-2010"), "00:00-00:00");
            Doctor doctor5 = new Doctor("Heyder", "Omerzade", DateTime.Parse("04-03-2020"), "00:00-00:00");
            Doctor doctor6 = new Doctor("Resad", "Memmedov", DateTime.Parse("05-08-2010"), "00:00-00:00");
            Doctor doctor7 = new Doctor("Emin", "Abbasov", DateTime.Parse("04-03-2020"), "00:00-00:00");
            Doctor doctor8 = new Doctor("Ibrahim", "Nebiyev", DateTime.Parse("05-08-2010"), "00:00-00:00");
            Doctor doctor9 = new Doctor("Ali", "Nebili", DateTime.Parse("04-03-2020"), "00:00-00:00");

            List<Doctor> doctors1 = new List<Doctor> { doctor1, doctor2, doctor3 };
            List<Doctor> doctors2 = new List<Doctor> { doctor4, doctor5 };
            List<Doctor> doctors3 = new List<Doctor> { doctor6, doctor7, doctor8, doctor9 };

            List<Department> departments = new List<Department>
            {
                new Department("Pediatriya", doctors1.Count, doctors1),
                new Department("Travmatologiya", doctors2.Count, doctors2),
                new Department("Stamotologiya", doctors3.Count, doctors3),
            };
            User user1 = new User("Omer","Aliyev","omeraliyev@gmail.com","777319060");

            
        }
        public void UserTxt()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
     ░░░░░░░      ██╗░░░██╗░██████╗███████╗██████╗░      ░░░░░░░
     ░░██╗░░      ██║░░░██║██╔════╝██╔════╝██╔══██╗      ░░██╗░░
     ██████╗      ██║░░░██║╚█████╗░█████╗░░██████╔╝      ██████╗
     ╚═██╔═╝      ██║░░░██║░╚═══██╗██╔══╝░░██╔══██╗      ╚═██╔═╝
     ░░╚═╝░░      ╚██████╔╝██████╔╝███████╗██║░░██║      ░░╚═╝░░
     ░░░░░░░      ░╚═════╝░╚═════╝░╚══════╝╚═╝░░╚═╝      ░░░░░░░");
            Console.ResetColor();
        }
        public void Start()
        {

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine();

            
            MainMenu(name, surname);
        }


        private User _user;
        private Doctor _doctor;
        private Admin _admin;
        private List<Department> _departments;
        List<User> users = new List<User>();

        public UserAdminDoctorControl() { }



        public void SignInOrSignUp()
        {
            string[][] options = new string[][]
{
        new string[]
        {
            "       █▀▀ ░▀░ █▀▀▀ █▀▀▄ 　 █░░█ █▀▀█",
            "       ▀▀█ ▀█▀ █░▀█ █░░█ 　 █░░█ █░░█",
            "       ▀▀▀ ▀▀▀ ▀▀▀▀ ▀░░▀ 　 ░▀▀▀ █▀▀▀"
        },
        new string[]
        {
            "       █▀▀ ░▀░ █▀▀▀ █▀▀▄ 　 ░▀░ █▀▀▄",
            "       ▀▀█ ▀█▀ █░▀█ █░░█ 　 ▀█▀ █░░█",
            "       ▀▀▀ ▀▀▀ ▀▀▀▀ ▀░░▀ 　 ▀▀▀ ▀░░▀"
        }
};

            int selectedIndex = 0;
            ConsoleKey key;
            do
            {
                Console.Clear();
                UserTxt();
                int offset = 6;
                for (int i = 0; i < offset; i++)
                    Console.WriteLine();


                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < options.Length; col++)
                    {
                        if (col == selectedIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(options[col][row] + "\t");
                            Console.ResetColor();
                        }
                        else
                        {

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(options[col][row] + "\t");
                            Console.ResetColor();
                        }
                    }
                    Console.WriteLine();
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.LeftArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    selectedIndex = (selectedIndex + 1) % options.Length;
                }

            } while (key != ConsoleKey.Enter);
            if (selectedIndex == 0)
            {
                Console.Clear();
                UserTxt();
                SignUp();
            }
            else if(selectedIndex == 1)
            {
                Console.Clear();
                UserTxt();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter surname: ");
                string surname = Console.ReadLine();

                
            
            }

        }

        public void Loading()
        {
            string[] dots = { "", ".", "..", "..." };

            for (int i = 0; i < dots.Length; i++)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\t\t#-----------------------------#");
                Console.WriteLine("\t\t\t|                             |");
                Console.WriteLine($"\t\t\t|          Loading{dots[i],-3}         |");
                Console.WriteLine("\t\t\t|                             |");
                Console.WriteLine("\t\t\t#-----------------------------#");

                Thread.Sleep(800);
            }

            Console.Clear();
        }
        public User SearchUserEmail(string email)
        {
            
            foreach (var user in users)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null!;
        }
        public User SearchUser(string email, string name,string surname,string phoneNumber)
        {
            foreach (var user in users)
            {
                if (user.Email == email&&user.Name == name &&user.Surname == surname&&user.PhoneNumber == phoneNumber)
                {
                    return user;
                }
            }
            return null!;
        }
        
        public void SignUp()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();
            while (true)
            {
                Console.Write("Enter Email adress: ");
                string email = Console.ReadLine();
                if (email.EndsWith("@gmail.com"))
                {
                    Console.Write("Enter Phone number: ");
                    string phoneNumber = Console.ReadLine();
                    User newUser = new User(name, surname, email, phoneNumber);
                    Loading();
                    users.Add(newUser);
                    Console.Clear();
                    UserTxt();
                    SignIn(email,name,surname);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Email!!!\nTry Again...");

                }
            }
            Console.ResetColor();
        }
        public void SignIn(string email, string name, string surname)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter email: ");
            string Email = Console.ReadLine();
            string Surname = Console.ReadLine();
            User index = SearchUserEmail(Email);
            if (index != null)
            {
                Loading();
                MainMenu(name,surname);
            }
            Console.ResetColor();




        }
        public void MainMenu(string name, string surname)
        {
            Console.Clear();
            UserTxt();
            string free = " free";
            string reserved = " reserved";

            string[] options2_ =
                {
                "09:00-11:00",
                "12:00-14:00",
                "15:00-17:00"
            };
            #region Kursor
            string[] options = {
            "Pediatriya",
            "Travmatologiya",
            "Stamotologiya",
        };

            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("3 sobeden birini sec...\n");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("-> " + options[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("   " + options[i]);
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % options.Length;
                }

            } while (key != ConsoleKey.Enter);

            Console.Clear();

            #endregion
            if (selectedIndex >= 0 && selectedIndex < options.Length)
            {
                int selectedIndex2 = 0;
                ConsoleKey key2;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Pediatr sobesinde olan hekimlerden birini secin...\n");

                    for (int i = 0; i < departments[selectedIndex].DoctorCount; i++)
                    {
                        if (i == selectedIndex2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine();
                            Console.WriteLine("-> " + departments[selectedIndex].Doctors[i]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" " + departments[selectedIndex].Doctors[i]);
                        }
                    }

                    key2 = Console.ReadKey(true).Key;

                    if (key2 == ConsoleKey.UpArrow)
                    {
                        selectedIndex2 = (selectedIndex2 == 0) ? departments[selectedIndex].Doctors.Count - 1 : selectedIndex2 - 1;
                    }
                    else if (key2 == ConsoleKey.DownArrow)
                    {
                        selectedIndex2 = (selectedIndex2 + 1) % departments[selectedIndex].Doctors.Count;
                    }

                } while (key2 != ConsoleKey.Enter);
                if (selectedIndex2 >= 0 && selectedIndex2 < departments[selectedIndex].Doctors.Count)

                {
                    Doctor selectedDoctor = departments[selectedIndex].Doctors[selectedIndex2];
                    int selectedIndex3 = 0;
                    ConsoleKey key3;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("size uygun olan vaxtlardan birini secin...\n");

                        for (int i = 0; i < options2_.Length; i++)
                        {

                            string timeStatus = selectedDoctor.ReservedTimes.Contains(options2_[i]) ? reserved : free;
                            if (i == selectedIndex3)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("-> " + options2_[i] + timeStatus);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("   " + options2_[i] + timeStatus);
                            }

                        }

                        key3 = Console.ReadKey(true).Key;

                        if (key3 == ConsoleKey.UpArrow)
                        {
                            selectedIndex3 = (selectedIndex3 == 0) ? options2_.Length - 1 : selectedIndex3 - 1;
                        }
                        else if (key3 == ConsoleKey.DownArrow)
                        {
                            selectedIndex3 = (selectedIndex3 + 1) % options2_.Length;
                        }

                    } while (key3 != ConsoleKey.Enter);
                    if (selectedIndex3 >= 0 && selectedIndex3 < options2_.Length)
                    {

                        string selectedTime = options2_[selectedIndex3];

                        if (selectedDoctor.ReservedTimes.Contains(selectedTime))
                        {
                            Console.WriteLine("Hemin vaxt artiq bu hekim ucun rezerv olunub. Zehmet olmasa basqa bir vaxt secin.");
                            Console.WriteLine("\nPress enter for continue...");
                            Console.ReadLine();
                            MainMenu(name, surname);
                        }
                        else
                        {
                            selectedDoctor.ReservedTimes.Add(selectedTime);
                            Console.WriteLine($"{name} {surname} siz saat {selectedTime} de {selectedDoctor.Name} hekimin qebuluna yazildiniz.");
                            Console.WriteLine("\nPress enter for continue...");
                            Console.ReadLine();
                            Console.Clear();
                            Start();
                        }
                    }

                }


            }

        }
    }
}


