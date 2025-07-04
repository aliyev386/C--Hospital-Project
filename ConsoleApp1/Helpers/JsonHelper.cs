using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{

    public static class JsonHelper
    {
        public static void SaveToFile<T>(string filePath, List<T> list)
        {
            string directory = Path.GetDirectoryName(filePath)!;
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string json = JsonSerializer.Serialize(list, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            File.WriteAllText(filePath, json);
        }

        public static List<T> LoadFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<T>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<T>();
        }
    }

    public static class PathConfig
    {
        public static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static readonly string RootFolder = Path.Combine(
         Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
         "logs, files and checks"
     );

        
        public static readonly string LogFilePath = Path.Combine(RootFolder, "hospital-log.txt");

        public static readonly string UsersFilePath = Path.Combine(RootFolder, "users.json");
        public static readonly string DoctorsFilePath = Path.Combine(RootFolder, "doctors.json");
        public static readonly string DepartmentsFilePath = Path.Combine(RootFolder, "departments.json");
    }


}
