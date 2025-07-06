using ConsoleApp1.Helpers;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Controls
{
    public class AdminControl
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
        public object GetDoctors()
        {
            var data = UserControl.allDoctors;

            return data;

        }

        public static List<Admin> admins = new List<Admin>
        {
            new Admin("Omer","Aliyev","aliyevomer386@gmail.com","admin","admin123",15)
        };

        public static string filePathAdmin = Path.Combine(
        Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
        "logs, files and checks",
        "admins.json"
        );

        public static List<Admin> GetAllAdmins()
        {
            return JsonHelper.LoadFromFile<Admin>(filePathAdmin);
        }

        public AdminControl() { }
        static AdminControl()
        {
            string folderPath = Path.GetDirectoryName(filePathAdmin)!;
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
                if (adminFromFile == null && adminFromFile.Count == 0)
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
                        MainMenu();
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
        public static void MainMenu()
        {
            AdminTxt();












        }


    }


}
