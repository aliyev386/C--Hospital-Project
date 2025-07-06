using ConsoleApp1.Helpers;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Controls
{
    public class DoctorControl
    {
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
        public static void DoctorTxt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
                    ██████╗░░█████╗░░█████╗░████████╗░█████╗░██████╗░
                    ██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗██╔══██╗
                    ██║░░██║██║░░██║██║░░╚═╝░░░██║░░░██║░░██║██████╔╝
                    ██║░░██║██║░░██║██║░░██╗░░░██║░░░██║░░██║██╔══██╗
                    ██████╔╝╚█████╔╝╚█████╔╝░░░██║░░░╚█████╔╝██║░░██║
                    ╚═════╝░░╚════╝░░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝");
            Console.ResetColor();
        }
        public static object GetDoctors()
        {
            var data = UserControl.allDoctors;
            return data;
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
                DoctorTxt();
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
                //SignUp(GetAllUsers());
            }
            else if (selectedIndex == 1)
            {
                //SignIn(GetAllUsers());
            }

        }
        public static void SignUp(List<Doctor> doctorsFromFile)
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
            //Doctor newUser = new Doctor(name, surname, email, finalUsername, password, age, phoneNumber);

            //doctorsFromFile.Add(newUser);
            //JsonHelper.SaveToFile(filePath, doctorsFromFile);
            //Loading();
            //Logs.LogInfo("User signed up.");
            //Console.Clear();
            //UserTxt();
            //SignIn(GetDoctors());
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
                    User index = SearchUsername(usersFromFile, Username);            //error var buralarda
                    if (index != null && index.Password == Password)
                    {
                        Logs.LogInfo("User is logged in");
                        Loading();
                        //MainMenu(index);
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
        public static void MainMenu(Doctor index)
        {

        }

    }
}
