using ConsoleApp1.Controls;
using ConsoleApp1.Helpers;
using ConsoleApp1.Models;
using Microsoft.VisualBasic.FileIO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Transactions;



namespace ConsoleApp1.Controls
{

    class UserControl
    {

        public static List<Doctor> doctors1 = new List<Doctor> {
            new Doctor("Umid", "Aslanov", "aslanov063@gmail.com", "Aslanov_UA86", "umid123", DateTime.Parse("01-01-2015")),
            new Doctor("Huseyin", "Memmedzade", "huseyin.m@gmail.com", "Memmedzade_HM10", "huseyin456", DateTime.Parse("05-08-2010")),
            new Doctor("Ali", "Agayev", "ali.agayev20@gmail.com", "Agayev_AA20", "ali789", DateTime.Parse("04-03-2020")),};

        public static List<Doctor> doctors2 = new List<Doctor> {
            new Doctor("Huseyin", "Memmedzade", "huseyin.m@gmail.com", "Memmedzade_HM10", "huseyin456", DateTime.Parse("05-08-2010")),
            new Doctor("Heyder", "Omerzade", "heyder.o@gmail.com", "Omerzade_HO20", "heyder321", DateTime.Parse("04-03-2020")),};

        public static List<Doctor> doctors3 = new List<Doctor> {
            new Doctor("Resad", "Memmedov", "resad.m@gmail.com", "Memmedov_RM10", "resad654", DateTime.Parse("05-08-2010")),
            new Doctor("Emin", "Abbasov", "emin.a@gmail.com", "Abbasov_EA20", "emin987", DateTime.Parse("04-03-2020")),
            new Doctor("Ibrahim", "Nebiyev", "ibrahim.n@gmail.com", "Nebiyev_IN10", "ibrahim159", DateTime.Parse("05-08-2010")),
            new Doctor("Ali", "Nebili", "ali.nebili@gmail.com", "Nebili_AN20", "ali753", DateTime.Parse("04-03-2020")),};

        public static List<Doctor> allDoctors = new List<Doctor>();


        List<Department> departments = new List<Department>
            {
                new Department("Pediatriya", doctors1.Count , doctors1),
                new Department("Travmatologiya", doctors2.Count, doctors2),
                new Department("Stamotologiya", doctors3.Count, doctors3),
            };

        public List<Department> GetDepartments() => departments;

        public static List<User> users = new List<User> {
            new User("Omer","Aliyev","aliyev@gmail.com","Aliye_oa18","omer123",15,"777319060")
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
        public UserControl() { }

        static UserControl()
        {
            allDoctors.AddRange(doctors1);
            allDoctors.AddRange(doctors2);
            allDoctors.AddRange(doctors3);
            JsonHelper.SaveToFile(PathConfig.DoctorsFilePath, allDoctors);


            var departments = new List<Department>
    {
        new Department("Pediatriya", doctors1.Count , doctors1),
        new Department("Travmatologiya", doctors2.Count, doctors2),
        new Department("Stamotologiya", doctors3.Count, doctors3),
    };

            JsonHelper.SaveToFile(PathConfig.DepartmentsFilePath, departments);
        }

        public void SignInOrSignUp()
        {
            Logs.LogInfo("Sign in or Sign up.");
            string[][] options = new string[][]
{
        new string[]
        {
            "       █▀▀ ░▀░ █▀▀▀ █▀▀▄    █░░█ █▀▀█",
            "       ▀▀█ ▀█▀ █░▀█ █░░█    █░░█ █░░█",
            "       ▀▀▀ ▀▀▀ ▀▀▀▀ ▀░░▀    ░▀▀▀ █▀▀▀"
        },
        new string[]
        {
            "       █▀▀ ░▀░ █▀▀▀ █▀▀▄    ░▀░ █▀▀▄",
            "       ▀▀█ ▀█▀ █░▀█ █░░█    ▀█▀ █░░█",
            "       ▀▀▀ ▀▀▀ ▀▀▀▀ ▀░░▀    ▀▀▀ ▀░░▀"
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
            Logs.LogInfo("Loading...");
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
            Logs.LogInfo("Sign up secildi.");
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
            try
            {
                if (name == "")
                {
                    throw (new Exception("It cant be null"));
                }
            }
            catch (Exception ex)
            {
                Logs.LogException("Name is null.", ex);
            }

            Console.Write("\t|Enter surname: ");
            string surname = Console.ReadLine()!;
            try
            {
                if (surname == "")
                {
                    throw (new Exception("It cant be null"));
                }
            }
            catch (Exception ex)
            {
                Logs.LogException("Surname is null.", ex);
            }
            while (true)
            {
                Console.Write("\t|Enter Email address: ");
                string email = Console.ReadLine()!;
                try
                {
                    if (email == "")
                    {
                        throw (new Exception("It cant be null"));
                    }
                }
                catch (Exception ex)
                {
                    Logs.LogException("Email is null.", ex);
                }
                User indexEmail = SearchUserEmail(email);
                if (indexEmail != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\t|This email already exists!!!");
                    Console.ResetColor();
                    break;
                }


                Console.Write("\t|Enter Phone number: ");
                string phoneNumber = Console.ReadLine()!;
                try
                {
                    if (phoneNumber == "")
                    {
                        throw (new Exception("It cant be null"));
                    }
                }
                catch (Exception ex)
                {
                    Logs.LogException("Phone number is null.", ex);
                }

                Console.Write("\t|Enter Age: ");
                int age = int.Parse(Console.ReadLine()!);
                try
                {
                    if (age == null)
                    {
                        throw (new Exception("It cant be null"));
                    }
                }
                catch (Exception ex)
                {
                    Logs.LogException("Age is null.", ex);
                }

                User tempUser = new User(name, surname, email, "", "", age, phoneNumber);
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
                    try
                    {
                        if (phoneNumber == "")
                        {
                            throw (new Exception("It cant be null"));
                        }
                    }
                    catch (Exception ex)
                    {
                        Logs.LogException("Phone number is null.", ex);
                    }
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\t|Enter password: ");
                string password = Console.ReadLine()!;
                try
                {
                    if (password == "")
                    {
                        throw (new Exception("It cant be null"));
                    }
                }
                catch (Exception ex)
                {
                    Logs.LogException("Password is null.", ex);
                }
                Console.ResetColor();
                User newUser = new User(name, surname, email, finalUsername, password, age, phoneNumber);
                users.Add(newUser);
                JsonHelper.SaveToFile(PathConfig.UsersFilePath, users);
                Loading();
                Logs.LogInfo("User qeytiyatdan kecdi.");
                Console.Clear();
                UserTxt();
                SignIn();
                break;
            }
        }
        public void SignIn()
        {
            Logs.LogInfo("Sign in secildi.");
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


            string filePath = Path.Combine(AppContext.BaseDirectory, "logs,files and checks", "users.json");
            List<User> usersFromFile = JsonHelper.LoadFromFile<User>(filePath);

            Console.Write("Enter Username: ");
            string Username = Console.ReadLine()!;
            try
            {
                if (Username == "")
                {
                    throw (new Exception("It cant be null"));
                }
            }
            catch (Exception ex)
            {
                Logs.LogException("Username number is null.", ex);
            }
            Console.Write("Enter Password: ");
            string Password = Console.ReadLine()!;
            try
            {
                if (Password == "")
                {
                    throw (new Exception("It cant be null"));
                }
            }
            catch (Exception ex)
            {
                Logs.LogException("Password number is null.", ex);
            }
            User index = SearchUsername(Username);
            if (index != null && index.Password == Password)
            {
                Logs.LogInfo("user daxil oldu");
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
            Logs.LogInfo("crud emelliyatlar.");
            Console.Clear();
            UserTxt();
            string[] crudOptions = {
                "\n\n\n\t|1.Show profile",
                "\n\t|2.Show Departments",
                "\n\t|3.Show All Doctors",
                "\n\t|4.Change Username",
                "\n\t|5.Change Password",
                "\n\t|6.Change Phone Number",
                "\n\n\t|Close",

            };
            int selectedCrudIndex = 0;
            ConsoleKey crudKey;

            do
            {
                Console.Clear();
                UserTxt();
                for (int i = 0; i < crudOptions.Length; i++)
                {
                    if (i == selectedCrudIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
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
                Logs.LogInfo("Show profile secildi.");
                while (true)
                {

                    Console.Clear();
                    UserTxt();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n--- USER PROFILE ---\n");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tName: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(index.Name);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tSurname: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(index.Surname);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tEmail: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(index.Email);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tUsername: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(index.UserName);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tPassword: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(index.Password);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tPhone number: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(index.PhoneNumber);
                    Console.ResetColor();

                    Console.WriteLine("\tPress Ecs for continue....");
                    ConsoleKey ecsKey;
                    ecsKey = Console.ReadKey(true).Key;
                    if (ecsKey == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        MainMenu(index);
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }

            }
            else if (selectedCrudIndex == 1)
            {
                Logs.LogInfo("Show Departments secildi.");
                while (true)
                {

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
                        UserTxt();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n\n\tSelect one of the departments...");
                        Console.ResetColor();
                        for (int i = 0; i < options.Length; i++)
                        {
                            if (i == selectedIndex)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\n|" + options[i]);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n|" + options[i]);
                                Console.ResetColor();
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
                            UserTxt();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\n\n\t|Choose one of the doctors on the department...\n");
                            Console.ResetColor();

                            for (int i = 0; i < departments[selectedIndex].DoctorCount; i++)
                            {
                                if (i == selectedIndex2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine();
                                    Console.WriteLine("\n|" + departments[selectedIndex].Doctors[i]);
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\n|" + departments[selectedIndex].Doctors[i]);
                                    Console.ResetColor();
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
                                UserTxt();
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("\n\n\tChoose a time that suits you...\n");
                                Console.ResetColor();

                                for (int i = 0; i < options2_.Length; i++)
                                {

                                    string timeStatus = selectedDoctor.ReservedTimes.Contains(options2_[i]) ? reserved : free;
                                    if (i == selectedIndex3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("\n|" + options2_[i] + timeStatus);
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n|" + options2_[i] + timeStatus);
                                        Console.ResetColor();
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
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("This time is already reserved for this doctor. If you don't mind, please choose another time.");
                                    Console.WriteLine("\nPress Enter for continue...");
                                    Console.ReadLine();
                                    Console.ResetColor();
                                    continue;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    selectedDoctor.ReservedTimes.Add(selectedTime);
                                    Console.WriteLine($"\n{index.Name} {index.Surname} siz saat {selectedTime} de {selectedDoctor.Name} hekimin qebuluna yazildiniz.");
                                    PrintCheck($"{index.Name} {index.UserName}", index.Email, $"{selectedDoctor.Name} {selectedDoctor.Surname}", options[selectedIndex], options2_[selectedIndex3], selectedDoctor.WorkExperience);
                                    string rootFolder = Path.Combine(AppContext.BaseDirectory, "logs,files and checks", "checks");

                                    if (!Directory.Exists(rootFolder))
                                        Directory.CreateDirectory(rootFolder);

                                    string safeUser = index.UserName.Replace(" ", "_");
                                    string fileName = $"check_{safeUser}_{DateTime.Now.Ticks}.txt";
                                    string fullPath = Path.Combine(rootFolder, fileName);

                                    GmailSender.SendEmailWithAttachment(
                                        $"{index.Email}",
                                        "Xestexana qebiziniz",
                                        $"Hormetli{index.Name}. Reservasiya ugurla tamamlandi. Zehmet olmasa elave olunan qebzi yoxlayin.",
                                        fullPath
                                    );

                                    Console.WriteLine("\nPress enter for continue...");
                                    Console.ReadLine();
                                    Console.ResetColor();
                                    MainMenu(index);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else if (selectedCrudIndex == 2)
            {
                Logs.LogInfo("Show All Doctors.");
                while (true)
                {
                    Console.Clear();
                    UserTxt();
                    Console.WriteLine();
                    Console.WriteLine();
                    int count = 0;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    foreach (var item in allDoctors)
                    {
                        count++;
                        Console.WriteLine($"----------{count}---------");
                        Console.WriteLine(item.ToString());
                    }
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\tPress Ecs for continue....");
                    Console.ResetColor();
                    ConsoleKey ecsKey;
                    ecsKey = Console.ReadKey(true).Key;
                    if (ecsKey == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        MainMenu(index);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }


            }
            else if (selectedCrudIndex == 3)
            {
                Logs.LogInfo("Change Username secildi.");
                Console.Clear();
                UserTxt();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|Enter your Username: ");
                string username = Console.ReadLine()!;
                index = SearchUsername(username!);
                if (index != null)
                {
                    Console.Write("\n|Enter new Username: ");
                    string newUsername = Console.ReadLine()!;
                    Console.ResetColor();
                    username = newUsername!;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nUsername is changed succesfully...");
                    Logs.LogInfo("Username deyisdirildi.");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n\n\tPress Ecs for continue....");
                    Console.ResetColor();
                    while (true)
                    {
                        ConsoleKey ecsKey;
                        ecsKey = Console.ReadKey(true).Key;
                        if (ecsKey == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            MainMenu(index);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong username!!!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n\n\tPress any key for continue....");
                    Console.ResetColor();
                    ConsoleKey ecsKey;
                    ecsKey = Console.ReadKey(true).Key;
                    if (ecsKey == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        MainMenu(index);
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        MainMenu(index);
                        return;
                    }
                }


            }
            else if (selectedCrudIndex == 4)
            {
                Logs.LogInfo("Change password secildi.");
                Console.Clear();
                UserTxt();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|Enter Password: ");
                string password = Console.ReadLine()!;
                if (index.Password == password)
                {
                    Console.Write("|Enter new password: ");
                    string newPassword = Console.ReadLine()!;
                    Console.ResetColor();
                    password = newPassword;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Password changed succesfully...");
                    Logs.LogInfo("Password deyisdirildi.");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n\n\tPress Ecs for continue....");
                    Console.ResetColor();
                    while (true)
                    {
                        ConsoleKey ecsKey;
                        ecsKey = Console.ReadKey(true).Key;
                        if (ecsKey == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            MainMenu(index);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong Password!!!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n\n\tPress ecs key for continue....");
                    Console.ResetColor();
                    ConsoleKey ecsKey;
                    ecsKey = Console.ReadKey(true).Key;
                    if (ecsKey == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        MainMenu(index);
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        MainMenu(index);
                        return;
                    }
                }
            }
            else if (selectedCrudIndex == 5)
            {
                Logs.LogInfo("Change Phone number secildi.");
                Console.Clear();
                UserTxt();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|Enter Phone number: ");
                string phoneNum = Console.ReadLine()!;
                if (index.PhoneNumber == phoneNum)
                {
                    Console.Write("|Enter new phone: ");
                    string newPhone = Console.ReadLine()!;
                    Console.ResetColor();
                    phoneNum = newPhone;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Phone changed succesfully...");
                    Logs.LogInfo("Telefon nomresi deyisdirildi.");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n\n\tPress Ecs for continue....");
                    Console.ResetColor();
                    while (true)
                    {
                        ConsoleKey ecsKey;
                        ecsKey = Console.ReadKey(true).Key;
                        if (ecsKey == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            MainMenu(index);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong Phone number!!!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n\n\tPress enc key for continue....");
                    Console.ResetColor();
                    ConsoleKey ecsKey;
                    ecsKey = Console.ReadKey(true).Key;
                    if (ecsKey == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        MainMenu(index);
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        MainMenu(index);
                        return;
                    }
                }
            }
            else if (selectedCrudIndex == 6)
            {
                Log.Information("Proqram Bitdi.");
                Log.Information("#==========================================#");
                return;
            }

        }


        public static void PrintCheck(string userFullName, string userEmail, string doctorFullName, string department, string timeSlot, DateTime date)
        {
            string rootFolder = Path.Combine(AppContext.BaseDirectory, "logs,files and checks");
            string checkFolder = Path.Combine(rootFolder, "checks");
            if (!Directory.Exists(checkFolder))
            {
                Directory.CreateDirectory(checkFolder);
            }
            string safeUser = userFullName.Replace(" ", "_");
            string fileName = $"check_{safeUser}_{DateTime.Now.Ticks}.txt";
            string fullPath = Path.Combine(checkFolder, fileName);
            string content = $"       Reservation confirmation\n" +
                             $"======================================\n" +
                             $"User: {userFullName}\n" +
                             $"Email: {userEmail}\n" +
                             $"Department: {department}\n" +
                             $"Doctor: {doctorFullName}\n" +
                             $"Date: {date.ToShortDateString()}\n" +
                             $"Time: {timeSlot}\n" +
                             $"======================================\n" +
                             $"Thank you! your reservation has\nbeen succesfully registered\n";
            File.WriteAllText(fullPath, content);
            Console.WriteLine("Check created successfully.\n");

        }
        
    }
}
