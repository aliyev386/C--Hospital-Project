using ConsoleApp1.Controls;
using ConsoleApp1.Helpers;
using ConsoleApp1.Models;
using Microsoft.VisualBasic.FileIO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
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
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace ConsoleApp1.Controls
{

    public class UserControl
    {
        public static void UserTxt()
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
            string folderPath = Path.GetDirectoryName(Aplication.filePath)!;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }



            string folderPathDp = Path.GetDirectoryName(Aplication.filePathDP)!;
            if (!Directory.Exists(folderPathDp))
            {
                Directory.CreateDirectory(folderPathDp);
            }
            if (!File.Exists(PathConfig.UsersFilePath))
            {
                JsonHelper.SaveToFile(PathConfig.UsersFilePath, Aplication.users);
            }

            if (!File.Exists(PathConfig.DesktopPath))
            {
                var departments = new List<Department>
                {
                    new Department("Pediatriya", Aplication.doctors1.Count , Aplication.doctors1),
                    new Department("Travmatologiya", Aplication.doctors2.Count, Aplication.doctors2),
                    new Department("Stamotologiya", Aplication.doctors3.Count, Aplication.doctors3),
                };
                JsonHelper.SaveToFile(PathConfig.DepartmentsFilePath, Aplication.departments);
            }

        }
        public static void SignInOrSignUp()
        {
            Console.ResetColor();
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
                SignUp(Aplication.GetAllUsers());
            }
            else if (selectedIndex == 1)
            {
                SignIn(Aplication.GetAllUsers());
            }
        }
        public static void Loading()
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
        public static User SearchUserEmail(List<User> users, string email)
        {
            return users.FirstOrDefault(u => u.Email == email)!;
        }
        public static User SearchUsername(List<User> users, string username)
        {
            return users.FirstOrDefault(u => u.UserName == username)!;
        }

        public static void SignUp(List<User> usersFromFile)
        {
            Logs.LogInfo("Sign up selected.");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
                         ░██████╗██╗░██████╗░███╗░░██╗    ██╗░░░██╗██████╗░
                         ██╔════╝██║██╔════╝░████╗░██║    ██║░░░██║██╔══██╗
                         ╚█████╗░██║██║░░██╗░██╔██╗██║    ██║░░░██║██████╔╝
                         ░╚═══██╗██║██║░░╚██╗██║╚████║    ██║░░░██║██╔═══╝░
                         ██████╔╝██║╚██████╔╝██║░╚███║    ╚██████╔╝██║░░░░░
                         ╚═════╝░╚═╝░╚═════╝░╚═╝░░╚══╝    ░╚═════╝░╚═╝░░░░░");
            Console.ResetColor();
            string name;
            string surname;
            string email;
            string phoneNumber;
            int age;
            string finalUsername;
            string password;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine();
                Console.Write("\t|Enter name: ");
                name = Console.ReadLine()!;
                if (name == "")
                {
                    try
                    {
                        throw (new Exception("It cant be null"));
                    }
                    catch (Exception ex)
                    {
                        Logs.LogException("Name is null.", ex);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\tIt cant be null!!!");
                        Console.ResetColor();
                        continue;
                    }
                }
                break;
            }
            while (true)
            {

                Console.Write("\t|Enter surname: ");
                surname = Console.ReadLine()!;
                if (surname == "")
                {
                    try
                    {
                        throw (new Exception("It cant be null"));
                    }
                    catch (Exception ex)
                    {
                        Logs.LogException("Surname is null.", ex);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\tIt cant be null!!!");
                        Console.ResetColor();
                        continue;
                    }
                }
                break;
            }
            while (true)
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\t|Enter Email address: ");
                email = Console.ReadLine()!;
                string emailPattern = @"^[\w!#$%&'*+\-/=?\^_{|}~]+(\.[\w!#$%&'*+\-/=?\^_{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
                if (!Regex.IsMatch(email, emailPattern) || email == "")
                {
                    try
                    {
                        throw new Exception("Error");
                    }
                    catch (Exception ex)
                    {
                        Logs.LogException("Wrong email", ex);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\tEmail is null or wrong\n");
                        Console.ResetColor();
                        Console.ResetColor();
                        continue;
                    }
                }
                break;
            }
            while (true)
            {
                Console.Write("\t|Enter Phone number: ");
                phoneNumber = Console.ReadLine()!;
                if (phoneNumber == "")
                {
                    try
                    {
                        throw (new Exception("It cant be null"));
                    }
                    catch (Exception ex)
                    {
                        Logs.LogException("Phone number is null.", ex);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\tIt cant be null!!!");
                        Console.ResetColor();
                        continue;
                    }
                }
                break;
            }


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\t|Enter Age: ");
                string? input = Console.ReadLine();
                Console.ResetColor();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\tAge can't be null or empty!");
                    Console.ResetColor();
                    continue;
                }
                if (!int.TryParse(input, out age))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\tAge must be a number!");
                    Console.ResetColor();
                    continue;
                }
                if (age < 0 || age > 130)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\tAge must be between 0 and 130!");
                    Console.ResetColor();
                    continue;
                }
                break;
            }

            User tempUser = new User(name, surname, email, "", "", age, phoneNumber);
            string usernameOffer = tempUser.GenerateUsername();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\t|System suggests this username: {usernameOffer}");
            Console.WriteLine("\t|Do you want to use this username?");
            Console.ResetColor();
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


            while (true)
            {

                if (selectedIndex == 0)
                {
                    finalUsername = usernameOffer;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\t|Enter your preferred username: ");
                    finalUsername = Console.ReadLine()!;
                    if (phoneNumber == "")
                    {
                        try
                        {
                            throw (new Exception("It cant be null"));
                        }
                        catch (Exception ex)
                        {
                            Logs.LogException("Phone number is null.", ex);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\tIt cant be null!!!");
                            Console.ResetColor();
                            continue;
                        }
                    }
                }
                break;
            }
            while (true)
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\t|Enter password: ");
                password = Console.ReadLine()!;
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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\tIt cant be null!!!");
                    Console.ResetColor();
                    continue;
                }
                break;
            }
            Console.ResetColor();
            User newUser = new User(name, surname, email, finalUsername, password, age, phoneNumber);

            usersFromFile.Add(newUser);
            JsonHelper.SaveToFile(Aplication.filePath, usersFromFile);
            Loading();
            Logs.LogInfo("User signed up.");
            Console.Clear();
            UserTxt();
            SignIn(Aplication.GetAllUsers());
        }
        public static void SignIn(List<User> usersFromFile)
        {
            while (true)
            {
                Logs.LogInfo("Sign in selected.");
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

                if (usersFromFile == null || usersFromFile.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("User null in system please sign up!");
                    Console.ResetColor();
                    Console.WriteLine("\n\tPress Ecs for continue....");
                    ConsoleKey ecsKey;
                    ecsKey = Console.ReadKey(true).Key;
                    if (ecsKey == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        SignInOrSignUp();
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
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
                    User index = SearchUsername(usersFromFile, Username);
                    if (index != null && index.Password == Password)
                    {
                        Logs.LogInfo("User is logged in");
                        Loading();
                        MainMenu(index);
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nUsername Or Password is Wrong!!!");
                        Console.ResetColor();
                        Console.WriteLine("\n\tPress Ecs for continue....");
                        ConsoleKey ecsKey;
                        ecsKey = Console.ReadKey(true).Key;
                        if (ecsKey == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            SignInOrSignUp();
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
        public static void MainMenu(User index)
        {
            Logs.LogInfo("crud operations.");
            Console.Clear();
            UserTxt();
            string[] crudOptions = {
                "\n\n\n\t|1.Show profile",
                "\n\t|2.Show Departments (reserve doctor)",
                "\n\t|3.Show All Doctors",
                "\n\t|4.Change Username",
                "\n\t|5.Change Password",
                "\n\t|6.Change Phone Number",
                "\n\n\t|Close",

            };
            #region ShowProfile
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
                Logs.LogInfo("Show profile selected.");
                while (true)
                {
                    var userInList = PathConfig.usersFromFile.FirstOrDefault(u => u.Email == index.Email);
                    if (userInList!.Email == index.Email)
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
                        Console.WriteLine(userInList.Name);

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\tSurname: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(userInList.Surname);

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\tEmail: ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(userInList.Email);

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\tUsername: ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(userInList.UserName);

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\tPassword: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(userInList.Password);

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\tPhone number: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(userInList.PhoneNumber);
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

            }
            #endregion
            #region Reserve Doctor
            else if (selectedCrudIndex == 1)
            {
                Logs.LogInfo("Show Departments selected.");
                while (true)
                {

                    string free = " free";
                    string reserved = " reserved";
                    int selectedIndex = 0;

                    ConsoleKey key;

                    do
                    {
                        Console.Clear();
                        UserTxt();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n\n\tSelect one of the departments...");
                        Console.ResetColor();
                        for (int i = 0; i < Aplication.departments.Count; i++)
                        {
                            if (i == selectedIndex)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\n|" + Aplication.departments[i].Name);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n|" + Aplication.departments[i].Name);
                                Console.ResetColor();
                            }
                        }

                        key = Console.ReadKey(true).Key;

                        if (key == ConsoleKey.UpArrow)
                        {
                            selectedIndex = (selectedIndex == 0) ? Aplication.departments.Count - 1 : selectedIndex - 1;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            selectedIndex = (selectedIndex + 1) % Aplication.departments.Count;
                        }

                    } while (key != ConsoleKey.Enter);

                    Console.Clear();

                    if (selectedIndex >= 0 && selectedIndex < Aplication.departments.Count)
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

                            for (int i = 0; i < Aplication.departments[selectedIndex].Doctors.Count; i++)
                            {
                                if (i == selectedIndex2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine();
                                    Console.WriteLine("\n|" + Aplication.departments[selectedIndex].Doctors[i]);
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\n|" + Aplication.departments[selectedIndex].Doctors[i]);
                                    Console.ResetColor();
                                }
                            }

                            key2 = Console.ReadKey(true).Key;

                            if (key2 == ConsoleKey.UpArrow)
                            {
                                selectedIndex2 = (selectedIndex2 == 0) ? Aplication.departments[selectedIndex].Doctors.Count - 1 : selectedIndex2 - 1;
                            }
                            else if (key2 == ConsoleKey.DownArrow)
                            {
                                selectedIndex2 = (selectedIndex2 + 1) % Aplication.departments[selectedIndex].Doctors.Count;
                            }

                        } while (key2 != ConsoleKey.Enter);
                        if (selectedIndex2 >= 0 && selectedIndex2 < Aplication.departments[selectedIndex].Doctors.Count)
                        {
                            Doctor selectedDoctor = Aplication.departments[selectedIndex].Doctors[selectedIndex2];
                            int selectedIndex3 = 0;
                            ConsoleKey key3;
                            do
                            {
                                Console.Clear();
                                UserTxt();
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("\n\n\tChoose a time that suits you...\n");
                                Console.ResetColor();

                                for (int i = 0; i < Aplication.availableSlots.Length; i++)
                                {

                                    string timeStatus = selectedDoctor.TimeSlots.Contains(Aplication.availableSlots[i]) ? reserved : free;
                                    if (i == selectedIndex3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("\n|" + Aplication.availableSlots[i] + timeStatus);
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("\n|" + Aplication.availableSlots[i] + timeStatus);
                                        Console.ResetColor();
                                    }

                                }

                                key3 = Console.ReadKey(true).Key;

                                if (key3 == ConsoleKey.UpArrow)
                                {
                                    selectedIndex3 = (selectedIndex3 == 0) ? Aplication.availableSlots.Length - 1 : selectedIndex3 - 1;
                                }
                                else if (key3 == ConsoleKey.DownArrow)
                                {
                                    selectedIndex3 = (selectedIndex3 + 1) % Aplication.availableSlots.Length;
                                }

                            } while (key3 != ConsoleKey.Enter);
                            if (selectedIndex3 >= 0 && selectedIndex3 < Aplication.availableSlots.Length)
                            {
                                string selectedTime = Aplication.availableSlots[selectedIndex3];

                                if (selectedDoctor.TimeSlots.Contains(selectedTime))
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
                                    selectedDoctor.TimeSlots.Add(selectedTime);
                                    JsonHelper.SaveToFile(PathConfig.DepartmentsFilePath, Aplication.departments);

                                    var doctorInAllDoctors = Aplication.allDoctors.FirstOrDefault(d => d.UserName == selectedDoctor.UserName);
                                    if (doctorInAllDoctors != null && !doctorInAllDoctors.TimeSlots.Contains(selectedTime))
                                    {
                                        doctorInAllDoctors.TimeSlots.Add(selectedTime);
                                    }
                                    JsonHelper.SaveToFile(PathConfig.DoctorsFilePath, Aplication.allDoctors);
                                    Aplication.AllReservations.Add(new Reservation
                                    {
                                        DoctorUserName = selectedDoctor.UserName,
                                        TimeSlot = selectedTime,
                                        ReservedByUserName = index.UserName
                                    });
                                    JsonHelper.SaveToFile(PathConfig.ReservationFilePath, Aplication.AllReservations);

                                    Console.WriteLine($"\n{index.Name} {index.Surname} siz saat {selectedTime} de {selectedDoctor.Name} hekimin qebuluna yazildiniz.");
                                    var depIndex = Aplication.departments[selectedIndex];
                                    PrintCheck($"{index.Name} {index.UserName}", index.Email, $"{selectedDoctor.Name} {selectedDoctor.Surname}", depIndex.Name, Aplication.availableSlots[selectedIndex3], selectedDoctor.WorkExperience);
                                    string rootFolder = Path.Combine(AppContext.BaseDirectory, "logs,files and checks", "checks");

                                    if (!Directory.Exists(rootFolder))
                                    {
                                        Directory.CreateDirectory(rootFolder);
                                    }
                                    string body = $"       Reservation confirmation\n" +
                                    $"======================================\n" +
                                    $"User: {index.Name} {index.Surname}\n" +
                                    $"Email: {index.Email}\n" +
                                    $"Department: {depIndex.Name}\n" +
                                    $"Doctor: {depIndex.Doctors[selectedIndex2].Name}\n" +
                                    $"Date: {DateTime.Now.Month}\n" +
                                    $"Time: {Aplication.availableSlots[selectedIndex3]}\n" +
                                    $"======================================\n" +
                                    $"Thank you! your reservation has\nbeen succesfully registered\n";
                                    GmailSender.SendEmail(index.Email, "New Reservation Created", body);

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
                        }
                    }
                }
            }
            #endregion
            else if (selectedCrudIndex == 2)
            {
                Logs.LogInfo("Show all doctors selected.");
                while (true)
                {
                    Console.Clear();
                    UserTxt();
                    Console.WriteLine();
                    Console.WriteLine();
                    int count = 0;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    foreach (var item in PathConfig.doctorsFromFile)
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
                Logs.LogInfo("Change Username selected.");
                Console.Clear();
                UserTxt();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|Enter your Username: ");
                string username = Console.ReadLine()!;
                var userInList = PathConfig.usersFromFile.FirstOrDefault(u => u.Email == index.Email);
                if (userInList != null && username == userInList.UserName)
                {
                    Console.Write("\n|Enter new Username: ");
                    string newUsername = Console.ReadLine()!;
                    Console.ResetColor();
                    userInList.UserName = newUsername;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nUsername is changed succesfully...");
                    Logs.LogInfo("Username changed.");
                    JsonHelper.SaveToFile(Aplication.filePath, PathConfig.usersFromFile);
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
                Logs.LogInfo("Change password selected.");
                Console.Clear();
                UserTxt();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|Enter Password: ");
                string password = Console.ReadLine()!;
                var userInList = PathConfig.usersFromFile.FirstOrDefault(u => u.Email == index.Email);
                if (userInList != null && password == userInList.Password)
                {
                    Console.Write("|Enter new password: ");
                    string newPassword = Console.ReadLine()!;
                    Console.ResetColor();
                    userInList.Password = newPassword;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Password changed succesfully...");
                    Logs.LogInfo("Password changed.");
                    JsonHelper.SaveToFile(Aplication.filePath, PathConfig.usersFromFile);
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
                Logs.LogInfo("Change phone number selected.");
                Console.Clear();
                UserTxt();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|Enter Phone number: ");
                string phoneNum = Console.ReadLine()!;
                var userInList = PathConfig.usersFromFile.FirstOrDefault(u => u.Email == index.Email);
                if (userInList != null && phoneNum == userInList.PhoneNumber)
                {
                    Console.Write("|Enter new phone: ");
                    string newPhone = Console.ReadLine()!;
                    Console.ResetColor();
                    userInList.PhoneNumber = newPhone;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Phone changed succesfully...");
                    Logs.LogInfo("Telefon nomresi changed.");
                    JsonHelper.SaveToFile(Aplication.filePath, PathConfig.usersFromFile);
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
                Log.Information("Proqram Ended.");
                Log.Information("#==========================================#");
                return;
            }

        }


        public static void PrintCheck(string userFullName, string userEmail, string doctorFullName, string department, string timeSlot, DateTime date)
        {
            string rootFolder = Path.Combine(
        Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName);
            string checkFolder = Path.Combine(rootFolder, "Check-files");
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
