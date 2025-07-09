using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    public class CvHelper
    {
        public string Body { get; set; }
        public CvHelper() { }
        public CvHelper(string body)
        {
            Body = body; 
        }
        public void SaveToFile(string filePath)
        {
            string folder = Path.GetDirectoryName(filePath)!;
            if (!Directory.Exists(folder))
            { 
                Directory.CreateDirectory(folder);
            }
            File.AppendAllText(filePath, Body + Environment.NewLine + Environment.NewLine);
        }
    }
}
