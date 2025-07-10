using ConsoleApp1.Helpers;
using ConsoleApp1.Models;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1.Controls
{
    public class AdminControl
    {
        public static List<Candidate> candidates = JsonHelper.LoadFromFile<Candidate>(PathConfig.CandidatesFilePath);

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
        public object GetDoctors()
        {
            var data = Aplication.allDoctors;

            return data;

        }

        public static List<Admin> admins = new List<Admin>
        {
            new Admin("Omer","Aliyev","aliyevomer386@gmail.com","admin","admin123",15)
        };



        public AdminControl() { }
        static AdminControl()
        {
            string folderPath = Path.GetDirectoryName(Aplication.filePathAdmin)!;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!File.Exists(PathConfig.AdminsFilePath))
            {
                JsonHelper.SaveToFile(PathConfig.AdminsFilePath, admins);
            }
        }
        public static void AdminTxt()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
                            ░█████╗░██████╗░███╗░░░███╗██╗███╗░░██╗
                            ██╔══██╗██╔══██╗████╗░████║██║████╗░██║
                            ███████║██║░░██║██╔████╔██║██║██╔██╗██║
                            ██╔══██║██║░░██║██║╚██╔╝██║██║██║╚████║
                            ██║░░██║██████╔╝██║░╚═╝░██║██║██║░╚███║
                            ╚═╝░░╚═╝╚═════╝░╚═╝░░░░░╚═╝╚═╝╚═╝░░╚══╝");
            Console.ResetColor();
        }
        public static Admin SearchUsername(List<Admin> admins, string username)
        {
            return admins.FirstOrDefault(u => u.UserName == username)!;
        }

        public static void LogIn(List<Admin> adminFromFile)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(@"
                            ██╗░░░░░░█████╗░░██████╗░    ██╗███╗░░██╗
                            ██║░░░░░██╔══██╗██╔════╝░    ██║████╗░██║
                            ██║░░░░░██║░░██║██║░░██╗░    ██║██╔██╗██║
                            ██║░░░░░██║░░██║██║░░╚██╗    ██║██║╚████║
                            ███████╗╚█████╔╝╚██████╔╝    ██║██║░╚███║
                            ╚══════╝░╚════╝░░╚═════╝░    ╚═╝╚═╝░░╚══╝");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (adminFromFile == null && adminFromFile!.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Admin null in system please sign up!");
                    Console.ResetColor();
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
                    Admin index = SearchUsername(adminFromFile, Username);
                    if (index != null && index.Password == Password)
                    {
                        Logs.LogInfo("user daxil oldu");
                        Loading();
                        Crud(Aplication.GetAllUsers(), Aplication.GetAllDepartments());
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
        public static int NavigateMenu(List<string> options, string title, bool showBack = false)
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(title);
                Console.ResetColor();
                Console.WriteLine();

                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"> {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"  {options[i]}");
                        Console.ResetColor();
                    }
                }

                if (showBack)
                {
                    if (selectedIndex == options.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("> Back");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("  Back");
                        Console.ResetColor();
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    if (showBack)
                    {
                        selectedIndex = (selectedIndex == 0) ? options.Count : selectedIndex - 1;
                    }
                    else
                    {
                        selectedIndex = (selectedIndex == 0) ? options.Count - 1 : selectedIndex - 1;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (showBack)
                    {
                        selectedIndex = (selectedIndex + 1) % (options.Count + 1);
                    }
                    else
                    {
                        selectedIndex = (selectedIndex + 1) % options.Count;
                    }
                }

            } while (key != ConsoleKey.Enter);

            if (showBack && selectedIndex == options.Count)
            {
                Crud(Aplication.GetAllUsers(), Aplication.GetAllDepartments());
                return -1;
            }

            return selectedIndex;
        }

        public static void Crud(List<User> usersFromFile, List<Department> departmentsFromFile)
        {
            string[] crudOption =
            {
                "Show All Candidates",
                "Show All Users",
                "Show All Departments",
                "Add New Department",
                "Delete Tepartment Department",

            };
            int selectedIndex = 0;
            ConsoleKey key;
            do
            {
                Console.Clear();
                AdminTxt();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n\n\tSelect one...");
                Console.ResetColor();
                for (int i = 0; i < crudOption.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n|" + crudOption[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n|" + crudOption[i]);
                        Console.ResetColor();
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? crudOption.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % crudOption.Length;
                }

            } while (key != ConsoleKey.Enter);
            try
            {
                if (selectedIndex == 0)
                {

                    if (candidates.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There are no candidates.");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }

                    int selectedIndexCv = NavigateMenu(
                        candidates.Select(d => $"{d.Name} {d.Surname}").ToList(),
                        @"
                    
                ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
                █ ▄▄▄ ██▀▄ ██▄ ▀█▄ ▄█▄ ▄▄▀█▄ ▄█▄ ▄▄▀██▀▄ ██ ▄ ▄ █▄ ▄▄ █ ▄▄▄▄█
                █ ███▀██ ▀ ███ █▄▀ ███ ██ ██ ███ ██ ██ ▀ ████ ████ ▄█▀█▄▄▄▄ █
                ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▀▀▄▄▀▄▄▄▄▀▀▄▄▄▀▄▄▄▄▀▀▄▄▀▄▄▀▀▄▄▄▀▀▄▄▄▄▄▀▄▄▄▄▄▀",
                        true);

                    if (selectedIndexCv == -1) return;

                    var candidate = candidates[selectedIndexCv];

                    List<string> actions = new List<string> { "Accept", "Reject" };
                    int actionIndex = NavigateMenu(actions, $@"
                        Name: {candidate.Name}
                        Surname: {candidate.Surname}
                        Email: {candidate.Email}
                        Username: {candidate.UserName}
                        Password: {candidate.Password}
                        Experience Year: {candidate.WorkExperience}
                        Reserved Time Slots: {candidate.ReservedTimeSlots}
                        Age: {candidate.Age}
                        Department: {candidate.Department}
                        Motivation: {candidate.MotivationText}
                        ", true);

                    if (actionIndex == 0)
                    {
                        var doctors = JsonHelper.LoadFromFile<Doctor>(PathConfig.DoctorsFilePath);

                        Doctor newDoctor = new Doctor
                        {
                            Name = candidate.Name,
                            Surname = candidate.Surname,
                            Email = candidate.Email,
                            UserName = candidate.UserName,
                            Password = candidate.Password,
                            WorkExperience = candidate.WorkExperience,
                            ReservedTimeSlots = candidate.ReservedTimeSlots,
                            Age = candidate.Age,
                            Department = candidate.Department,
                            MotivationText = candidate.MotivationText,
                        };
                        int depCount;
                        int index = 0;

                        foreach (var item in Aplication.departments)
                        {
                            if (candidate.Department == item.Name)
                            {
                                break;
                            }
                            index++;
                        }
                        if (index == -1)
                        {
                            Console.WriteLine("Department not found.");
                            return;
                        }
                        if (Aplication.departments[index].Doctors == null)
                        {
                            Aplication.departments[index].Doctors = new List<Doctor>();
                        }
                        doctors.Add(newDoctor);
                        JsonHelper.SaveToFile(PathConfig.DoctorsFilePath, doctors);
                        Aplication.departments[index].Doctors.Add(newDoctor);
                        JsonHelper.SaveToFile(PathConfig.DepartmentsFilePath, Aplication.departments);
                        candidates.Remove(candidate);
                        JsonHelper.SaveToFile(PathConfig.CandidatesFilePath, candidates);

                        string subject = "Application Accepted – Hope Medical Center";
                        string body = $@"
                            Dear Dr. {candidate.Name} {candidate.Surname},
                            
                            Your application has been accepted. Welcome to Hope Medical Center.
                            
                            Warm regards,
                            Hope Medical Center Team";

                        GmailSender.SendEmail(candidate.Email, subject, body);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Candidate has been successfully accepted.");
                        GmailSender.SendEmail(candidate.Email, "Request has been received.", $"Dear {candidate.Name} {candidate.Surname} your request has been received.");
                        Console.ResetColor();
                        Log.Information($"Doctor accepted: {candidate.Name} {candidate.Surname}");
                        Console.ReadKey();
                        Aplication.Start();
                    }
                    else if (actionIndex == 1)
                    {

                        candidates.Remove(candidate);
                        JsonHelper.SaveToFile(PathConfig.CandidatesFilePath, candidates);

                        string subject = "Application Rejected – Hope Medical Center";
                        string body = $@"
                            Dear {candidate.Name},
                            
                            We regret to inform you that your application was rejected.
                            
                            Hope Medical Center Team";

                        GmailSender.SendEmail(candidate.Email, subject, body);

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Candidate has been rejected.");
                        Console.ResetColor();
                        Log.Information("Doctor rejected: {0} {1}", candidate.Name, candidate.Surname);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("\tPress Ecs for continue....");
                        Console.ResetColor();
                        ConsoleKey ecsKey;
                        ecsKey = Console.ReadKey(true).Key;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There is no candidate yet.");
                Console.ResetColor();
                Logs.LogException("There is no candidate yet.", ex);
            }
            try
            {
                if (selectedIndex == 1)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(@"
                ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
                █▄ ██ ▄█ ▄▄▄▄█▄ ▄▄ █▄ ▄▄▀█ ▄▄▄▄█
                ██ ██ ██▄▄▄▄ ██ ▄█▀██ ▄ ▄█▄▄▄▄ █
                ▀▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀");
                        Console.ResetColor();
                        int userCount = 0;
                        foreach (var item in usersFromFile)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"======== User {userCount++}=========");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(item);
                            Console.ResetColor();
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("\tPress Ecs for continue....");
                        Console.ResetColor();
                        ConsoleKey ecsKey;
                        ecsKey = Console.ReadKey(true).Key;
                        if (ecsKey == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            Crud(Aplication.GetAllUsers(), Aplication.GetAllDepartments());
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There is no user yet.");
                Console.ResetColor();
                Logs.LogException("There is no user yet.", ex);
            }
            try
            {
                if (selectedIndex == 2)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(@"
                ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
                █▄ ▄▄▀█▄ ▄▄ █▄ ▄▄ ██▀▄ ██▄ ▄▄▀█ ▄ ▄ █▄ ▀█▀ ▄█▄ ▄▄ █▄ ▀█▄ ▄█ ▄ ▄ █ ▄▄▄▄█
                ██ ██ ██ ▄█▀██ ▄▄▄██ ▀ ███ ▄ ▄███ ████ █▄█ ███ ▄█▀██ █▄▀ ████ ███▄▄▄▄ █
                ▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▄▀▀▀▄▄▀▄▄▀▄▄▀▄▄▀▀▄▄▄▀▀▄▄▄▀▄▄▄▀▄▄▄▄▄▀▄▄▄▀▀▄▄▀▀▄▄▄▀▀▄▄▄▄▄▀

");
                        Console.ResetColor();
                        int depCount = 0;
                        foreach (var item in departmentsFromFile)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"======== Department {depCount++}=========");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(item.Name);
                            Console.ResetColor();
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("\tPress Ecs for continue....");
                        Console.ResetColor();
                        ConsoleKey ecsKey;
                        ecsKey = Console.ReadKey(true).Key;
                        if (ecsKey == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            Crud(Aplication.GetAllUsers(), Aplication.GetAllDepartments());
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There is no department yet.");
                Console.ResetColor();
                Logs.LogException("There is no department yet.", ex);
            }
            try
            {
                if (selectedIndex == 3)
                {
                    while (true)
                    {

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(@"
                ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
                ██▀▄ ██▄ ▄▄▀█▄ ▄▄▀████▄ ▄▄▀█▄ ▄▄ █▄ ▄▄ ██▀▄ ██▄ ▄▄▀█ ▄ ▄ █▄ ▀█▀ ▄█▄ ▄▄ █▄ ▀█▄ ▄█ ▄ ▄ █
                ██ ▀ ███ ██ ██ ██ █████ ██ ██ ▄█▀██ ▄▄▄██ ▀ ███ ▄ ▄███ ████ █▄█ ███ ▄█▀██ █▄▀ ████ ██
                ▀▄▄▀▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▀▀▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▄▀▀▀▄▄▀▄▄▀▄▄▀▄▄▀▀▄▄▄▀▀▄▄▄▀▄▄▄▀▄▄▄▄▄▀▄▄▄▀▀▄▄▀▀▄▄▄▀");
                        Console.ResetColor();
                        Console.WriteLine("\n");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Enter department name: ");
                        string depName = Console.ReadLine()!;
                        Console.ResetColor();
                        bool istrue = true;
                        foreach (var item in departmentsFromFile)
                        {
                            if (depName == item.Name)
                            {
                                istrue = false;
                            }
                        }
                        if (istrue)
                        {
                            Department newDep = new Department(depName, 0, null);
                            departmentsFromFile.Add(newDep);
                            JsonHelper.SaveToFile(Aplication.filePathDP, departmentsFromFile);
                            Logs.LogInfo("Department successfully added");
                        }
                        else
                        {
                            throw new Exception("Department already exists");
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("\tPress Ecs for continue....");
                        Console.ResetColor();
                        ConsoleKey ecsKey;
                        ecsKey = Console.ReadKey(true).Key;
                        if (ecsKey == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            Crud(Aplication.GetAllUsers(), Aplication.GetAllDepartments());
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Department already exists.");
                Console.ResetColor();
                Logs.LogException("Department already exists.", ex);
            }
            try
            {
                if (selectedIndex == 4)
                {
                    while (true)
                    {

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(@"
                ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
                █▄ ▄▄▀█▄ ▄▄ █▄ ▄███▄ ▄▄ █ ▄ ▄ █▄ ▄▄ █████▄ ▄▄▀█▄ ▄▄ █▄ ▄▄ ██▀▄ ██▄ ▄▄▀█ ▄ ▄ █▄ ▀█▀ ▄█▄ ▄▄ █▄ ▀█▄ ▄█ ▄ ▄ █
                ██ ██ ██ ▄█▀██ ██▀██ ▄█▀███ ████ ▄█▀██████ ██ ██ ▄█▀██ ▄▄▄██ ▀ ███ ▄ ▄███ ████ █▄█ ███ ▄█▀██ █▄▀ ████ ██
                ▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▀▄▄▄▀▀▄▄▄▄▄▀▀▀▀▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▄▀▀▀▄▄▀▄▄▀▄▄▀▄▄▀▀▄▄▄▀▀▄▄▄▀▄▄▄▀▄▄▄▄▄▀▄▄▄▀▀▄▄▀▀▄▄▄▀");
                        Console.ResetColor();
                        Console.WriteLine("\n");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Enter department name: ");
                        string depName = Console.ReadLine()!;
                        Console.ResetColor();
                        bool istrue = true;
                        foreach (var item in departmentsFromFile)
                        {
                            if (depName == item.Name)
                            {
                                istrue = false;
                                departmentsFromFile.Remove(item);
                                JsonHelper.SaveToFile(Aplication.filePathDP, departmentsFromFile);
                                Logs.LogInfo("Department successfully deleted");
                                break;
                            }
                        }
                        if (istrue)
                        {
                            throw new Exception("Department is not found");
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("\tPress Ecs for continue....");
                        Console.ResetColor();
                        ConsoleKey ecsKey;
                        ecsKey = Console.ReadKey(true).Key;
                        if (ecsKey == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            Crud(Aplication.GetAllUsers(), Aplication.GetAllDepartments());
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Department is not found.");
                Console.ResetColor();
                Logs.LogException("Department is not found.", ex);
            }

        }

        public static void MainMenu()
        {
            LogIn(Aplication.GetAllAdmins());


        }
    }
}
