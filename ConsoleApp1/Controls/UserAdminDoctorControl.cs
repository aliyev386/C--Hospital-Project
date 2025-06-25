using ConsoleApp1.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace ConsoleApp1.Controls
{

    class UserAdminDoctorControl
    {

        public static List<Doctor> doctors1 = new List<Doctor> {
                new Doctor("Umid", "Aslanov", DateTime.Parse("01-01-2015")),
                new Doctor("Huseyin", "Memmedzade", DateTime.Parse("05-08-2010")),
                new Doctor("Ali", "Agayev", DateTime.Parse("04-03-2020")),
            };
        public static List<Doctor> doctors2 = new List<Doctor> {
                new Doctor("Huseyin", "Memmedzade", DateTime.Parse("05-08-2010")),
                new Doctor("Heyder", "Omerzade", DateTime.Parse("04-03-2020")),
            };
        public static List<Doctor> doctors3 = new List<Doctor> {
                new Doctor("Resad", "Memmedov", DateTime.Parse("05-08-2010")),
                new Doctor("Emin", "Abbasov", DateTime.Parse("04-03-2020")),
                new Doctor("Ibrahim", "Nebiyev", DateTime.Parse("05-08-2010")),
                new Doctor("Ali", "Nebili", DateTime.Parse("04-03-2020")),
            };

        List<Department> departments = new List<Department>
            {
                new Department("Pediatriya", doctors1.Count , doctors1),
                new Department("Travmatologiya", doctors2.Count, doctors2),
                new Department("Stamotologiya", doctors3.Count, doctors3),
            };


        private List<User> users = new List<User> {
            new User("Omer","Aliyev","aliyev@gmail.com","Aliye_oa18","omer123","777319060")
        };
        public void UserTxt()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
                     ██╗░░░██╗░██████╗███████╗██████╗░
                     ██║░░░██║██╔════╝██╔════╝██╔══██╗
                     ██║░░░██║╚█████╗░█████╗░░██████╔╝
                     ██║░░░██║░╚═══██╗██╔══╝░░██╔══██╗
                     ╚██████╔╝██████╔╝███████╗██║░░██║
                     ░╚═════╝░╚═════╝░╚══════╝╚═╝░░╚═╝");
            Console.ResetColor();
        }
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

                SignUp();
            }
            else if (selectedIndex == 1)
            {
                SignIn();


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

                Thread.Sleep(400);
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
        public User SearchUsername(string username)
        {
            foreach (var user in users)
            {
                if (user.UserName == username)
                {
                    return user;
                }
            }
            return null!;
        }
        public void SignUp()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
             ░██████╗██╗░██████╗░███╗░░██╗  ██╗░░░██╗██████╗░
             ██╔════╝██║██╔════╝░████╗░██║  ██║░░░██║██╔══██╗
             ╚█████╗░██║██║░░██╗░██╔██╗██║  ██║░░░██║██████╔╝
             ░╚═══██╗██║██║░░╚██╗██║╚████║  ██║░░░██║██╔═══╝░
             ██████╔╝██║╚██████╔╝██║░╚███║  ╚██████╔╝██║░░░░░
             ╚═════╝░╚═╝░╚═════╝░╚═╝░░╚══╝  ░╚═════╝░╚═╝░░░░░");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine();
            Console.Write("\t|Enter name: ");
            string name = Console.ReadLine()!;
            Console.Write("\t|Enter surname: ");
            string surname = Console.ReadLine()!;

            while (true)
            {
                Console.Write("\t|Enter Email address: ");
                string email = Console.ReadLine()!;
                string emailPattern = @"^[\w!#$%&'*+\-/=?\^_{|}~]+(\.[\w!#$%&'*+\-/=?\^_{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

                if (!Regex.IsMatch(email, emailPattern))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\t|Invalid Email! Try again...");
                    Console.ResetColor();
                    continue;
                }

                Console.Write("\t|Enter Phone number: ");
                string phoneNumber = Console.ReadLine()!;

                // Username təklifi
                User tempUser = new User(name, surname, email, "", "", phoneNumber);
                string usernameOffer = tempUser.GenerateUsername();

                Console.WriteLine();
                Console.WriteLine($"\t|System suggests this username: {usernameOffer}");
                Console.WriteLine("\t|Do you want to use this username?");

                string[] options = { "\t|yes", "\t|no" };
                int selectedIndex = 0;
                ConsoleKey key;
                int menuStartLine = Console.CursorTop;

                do
                {
                    Console.SetCursorPosition(0, menuStartLine);

                    for (int i = 0; i < options.Length; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(" >" + options[i]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("  " + options[i]);
                            Console.ResetColor();
                        }
                    }

                    key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.UpArrow)
                        selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                    else if (key == ConsoleKey.DownArrow)
                        selectedIndex = (selectedIndex + 1) % options.Length;

                } while (key != ConsoleKey.Enter);

                string finalUsername;
                if (selectedIndex == 0)
                {
                    finalUsername = usernameOffer;
                }
                else
                {
                    Console.Write("\t|Enter your preferred username: ");
                    finalUsername = Console.ReadLine()!;
                }

                Console.Write("\t|Enter password: ");
                string password = Console.ReadLine()!;
                User newUser = new User(name, surname, email, finalUsername, password, phoneNumber);
                users.Add(newUser);

                Loading();
                Console.Clear();
                UserTxt();
                SignIn();
                break;
            }
        }

        public void SignIn()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
                     ░██████╗██╗░██████╗░███╗░░██╗  ██╗███╗░░██╗
                     ██╔════╝██║██╔════╝░████╗░██║  ██║████╗░██║
                     ╚█████╗░██║██║░░██╗░██╔██╗██║  ██║██╔██╗██║
                     ░╚═══██╗██║██║░░╚██╗██║╚████║  ██║██║╚████║
                     ██████╔╝██║╚██████╔╝██║░╚███║  ██║██║░╚███║
                     ╚═════╝░╚═╝░╚═════╝░╚═╝░░╚══╝  ╚═╝╚═╝░░╚══╝");
            Console.ResetColor();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Username: ");
            string Username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string Password = Console.ReadLine();
            User index = SearchUsername(Username!);
            if (index != null && index.Password == Password)
            {
                Loading();
                MainMenu(index);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nUsername Or Password is Wrong!!!");
                Console.ResetColor();
            }
            Console.ResetColor();




        }

        public void MainMenu(User index)
        {
            Console.Clear();
            UserTxt();
            string[] crudOptions = {
                "\n\n\n\t|Your profile",
                "\n\t|g",
                "\n\t|g",
                "\n\t|g",
            };
            int selectedCrudIndex = 0;
            ConsoleKey crudKey;
            int menuStartLine = Console.CursorTop;
            do
            {
                Console.SetCursorPosition(0, menuStartLine);


                for (int i = 0; i < crudOptions.Length; i++)
                {
                    if (i == selectedCrudIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("   " + crudOptions[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("   " + crudOptions[i]);
                        Console.ResetColor();
                    }
                }

                crudKey = Console.ReadKey(true).Key;

                if (crudKey == ConsoleKey.UpArrow)
                {
                    selectedCrudIndex = (selectedCrudIndex == 0) ? crudOptions.Length - 1 : selectedCrudIndex - 1;
                }
                else if (crudKey == ConsoleKey.DownArrow)
                {
                    selectedCrudIndex = (selectedCrudIndex + 1) % crudOptions.Length;
                }

            } while (crudKey != ConsoleKey.Enter);
            if (selectedCrudIndex == 0)
            {
                index.ToString();
            }

            string free = " free";
            string reserved = " reserved";

            string[] options2_ =
                {
                "09:00-11:00",
                "12:00-14:00",
                "15:00-17:00"
            };
            #region Kursor
            string[] options = departments.Select(d => d.Name).ToArray();


            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("sobeden birini sec...\n");

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
                    Console.WriteLine("sobede olan hekimlerden birini secin...\n");

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
                            MainMenu(index);
                        }
                        else
                        {
                            selectedDoctor.ReservedTimes.Add(selectedTime);
                            Console.WriteLine($"{index.Name} {index.Surname} siz saat {selectedTime} de {selectedDoctor.Name} hekimin qebuluna yazildiniz.");
                            Console.WriteLine("\nPress enter for continue...");
                            Console.ReadLine();
                            Console.Clear();
                            /////////////////////////////////////////////////////////////Yeniden baslamalidir///////////////////////////////////////////////////////////
                        }
                    }

                }


            }

        }
    }
}