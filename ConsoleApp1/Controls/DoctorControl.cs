using ConsoleApp1.Helpers;
using ConsoleApp1.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1.Controls
{
    public class DoctorControl
    {



        public DoctorControl() { }
        static DoctorControl()
        {
            string folderPathD = Path.GetDirectoryName(Aplication.filePathDoctor)!;
            if (!Directory.Exists(folderPathD))
            {
                Directory.CreateDirectory(folderPathD);
            }
            if (!File.Exists(PathConfig.DoctorsFilePath))
            {
                Aplication.allDoctors.AddRange(Aplication.doctors1);
                Aplication.allDoctors.AddRange(Aplication.doctors2);
                Aplication.allDoctors.AddRange(Aplication.doctors3);
                JsonHelper.SaveToFile(PathConfig.DoctorsFilePath, Aplication.allDoctors);
            }

            string folderPathC = Path.GetDirectoryName(Aplication.filePathC)!;
            if (!Directory.Exists(folderPathC))
            {
                Directory.CreateDirectory(folderPathC);
            }
            if (!File.Exists(PathConfig.CandidatesFilePath))
            {
                JsonHelper.SaveToFile(PathConfig.CandidatesFilePath, Aplication.allCandidates);
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
        public static void DoctorTxt()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
                    ██████╗░░█████╗░░█████╗░████████╗░█████╗░██████╗░
                    ██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗██╔══██╗
                    ██║░░██║██║░░██║██║░░╚═╝░░░██║░░░██║░░██║██████╔╝
                    ██║░░██║██║░░██║██║░░██╗░░░██║░░░██║░░██║██╔══██╗
                    ██████╔╝╚█████╔╝╚█████╔╝░░░██║░░░╚█████╔╝██║░░██║
                    ╚═════╝░░╚════╝░░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝");
            Console.ResetColor();
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
                SignUp(Aplication.GetAllCandidates());
            }
            else if (selectedIndex == 1)
            {
                SignIn(Aplication.GetAllDoctors());
            }
        }

        public static string filePath = Path.Combine(
        Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
        "logs, files and checks",
        $"candidates.json"
        );
        public static void SignUp(List<Candidate> candidatesFromFile)
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
            string adminEmail = AdminControl.admins.FirstOrDefault()!.Email;
            string name, surname, email, username, password, motivationText;
            int age;
            DateTime now = DateTime.Now;
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
                        Logs.LogException("Name is null", ex);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\tIt cant be null");
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
                Console.Write("\t|Enter motivation text: ");
                motivationText = Console.ReadLine()!;
                if (motivationText == "")
                {
                    try
                    {
                        throw (new Exception("It cant be null"));
                    }
                    catch (Exception ex)
                    {
                        Logs.LogException("MotivationText is null.", ex);
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
                if (age < 0 || age > 60)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\tAge must be between 0 and 60!");
                    Console.ResetColor();
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\t|Enter username: ");
                username = Console.ReadLine()!;
                if (username == "")
                {
                    try
                    {
                        throw (new Exception("It cant be null"));
                    }
                    catch (Exception ex)
                    {
                        Logs.LogException("username is null.", ex);
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
            Department selectedDepartment;
            while (true)
            {

                Aplication aplication = new Aplication();

                if (aplication.Departments == null || aplication.Departments.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\tError: No department found.");
                    Console.ResetColor();
                    return;
                }
                string[] optionsDep = aplication.Departments.Select(d => d.Name).ToArray();
                int selectedIndex = 0;
                selectedDepartment = aplication.Departments[selectedIndex];
                ConsoleKey key;
                do
                {
                    Console.Clear();
                    DoctorTxt();
                    Console.WriteLine("\n");
                    Console.WriteLine("\n\tPlease select a department:\n");

                    for (int i = 0; i < optionsDep.Length; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;

                        }

                        Console.WriteLine($"\t{optionsDep[i]}");
                    }

                    Console.ResetColor();
                    key = Console.ReadKey(true).Key;


                    if (key == ConsoleKey.UpArrow)
                    {
                        selectedIndex = (selectedIndex == 0) ? optionsDep.Length - 1 : selectedIndex - 1;
                    }

                    if (key == ConsoleKey.DownArrow)
                    {

                        selectedIndex = (selectedIndex + 1) % optionsDep.Length;
                    }


                } while (key != ConsoleKey.Enter);
                break;
            }
            Candidate candidate = new Candidate(name, surname, email, username, password, age, now, new List<string>(), selectedDepartment.Name, motivationText);
            string body = $"          New Candidate Applivation\n" +
                                    $"======================================\n" +
                                    $"User: {name} {surname}\n" +
                                    $"Email: {email}\n" +
                                    $"Username: {username}\n" +
                                    $"Password: {password}\n" +
                                    $"Send time: {now}\n" +
                                    $"Motivation text: \n{motivationText}\n" +
                                    $"======================================\n" +
                                    $"Please review this application \nand approe it from Admin Panel\n" +
                                    $"======================================\n";
            GmailSender.SendEmail(adminEmail, "Candidate send cv", body);
            candidatesFromFile.Add(candidate);
            JsonHelper.SaveToFile(filePath, candidatesFromFile);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your request has been accepted, please wait for the admin's approval.");
            Console.ResetColor();
            Logs.LogInfo("Cv sended");
        }
        public static Doctor SearchUsername(List<Doctor> doctors, string username)
        {
            return doctors.FirstOrDefault(d => d.UserName == username)!;
        }
        public static void SignIn(List<Doctor> doctorsFromFile)
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

                if (doctorsFromFile == null || doctorsFromFile.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Doctor null in system please sign up!");
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
                    Doctor index = SearchUsername(doctorsFromFile, Username);
                    if (index != null && index.Password == Password)
                    {
                        Logs.LogInfo("Doctor is logged in");
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

        public static void MainMenu(Doctor index)
        {


            while (true)
            {
                var doctorInList = PathConfig.doctorsFromFile.FirstOrDefault(u => u.UserName == index.UserName);
                if (doctorInList!.Email == index.Email)
                {
                    Console.Clear();
                    DoctorTxt();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n--- Doctor PROFILE ---\n");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tName: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(doctorInList.Name);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tSurname: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(doctorInList.Surname);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tEmail: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(doctorInList.Email);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tUsername: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(doctorInList.UserName);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tPassword: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(doctorInList.Password);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tReservations:\n");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    var doctorReservations = Aplication.AllReservations
                        .Where(r => r.DoctorUserName == doctorInList.UserName)
                        .ToList();

                    if (doctorReservations.Count == 0)
                    {
                        Console.WriteLine("\tNo reservations.");
                    }
                    else
                    {
                        foreach (var res in doctorReservations)
                        {
                            Console.WriteLine($"\t{res.TimeSlot} - reserved by {res.ReservedByUserName}");
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    Console.WriteLine("\n\tPress Ecs for continue....");
                    ConsoleKey ecsKey;
                    ecsKey = Console.ReadKey(true).Key;
                    if (ecsKey == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Aplication.Start();
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

