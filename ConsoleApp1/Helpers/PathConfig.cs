using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    public static class PathConfig
    {
        public static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        
        public static readonly string RootFolderReservations = Path.Combine(
        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
        "Reservation-files"
        );
        public static readonly string RootFolderUsers = Path.Combine(
        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
        "User-files"
        );
        public static readonly string RootFolderAdmins = Path.Combine(
        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
        "Admin-files"
        );
        public static readonly string RootFolderDoctors = Path.Combine(
        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
        "Doctor-files"
        );
        public static readonly string RootFolderCandidates = Path.Combine(
        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
        "Candidate-files"
        );
        public static readonly string RootFolderDepartments = Path.Combine(
        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
        "Department-files"
        );
        public static readonly string RootFolderLogs = Path.Combine(
        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
        "Log-files"
        );


        public static readonly string LogFilePath = Path.Combine(RootFolderLogs, "hospital-log.txt");

        public static readonly string UsersFilePath = Path.Combine(RootFolderUsers, "users.json");
        public static readonly string ReservationFilePath = Path.Combine(RootFolderReservations, "reservations.json");
        public static readonly string DoctorsFilePath = Path.Combine(RootFolderDoctors, "doctors.json");
        public static readonly string CandidatesFilePath = Path.Combine(RootFolderCandidates, "candidates.json");
        public static readonly string DepartmentsFilePath = Path.Combine(RootFolderDepartments, "departments.json");
        public static readonly string AdminsFilePath = Path.Combine(RootFolderAdmins, "admins.json");

        public static List<User> usersFromFile = JsonHelper.LoadFromFile<User>(UsersFilePath);
        public static List<Reservation> reservationsFromFile = JsonHelper.LoadFromFile<Reservation>(ReservationFilePath);
        public static List<Doctor> doctorsFromFile = JsonHelper.LoadFromFile<Doctor>(DoctorsFilePath);
        public static List<Doctor> CandidatesFromFile = JsonHelper.LoadFromFile<Doctor>(CandidatesFilePath);
        public static List<Department> departmentsFromFile = JsonHelper.LoadFromFile<Department>(DepartmentsFilePath);
        public static List<Admin> adminsFromFile = JsonHelper.LoadFromFile<Admin>(AdminsFilePath);
    }
}
