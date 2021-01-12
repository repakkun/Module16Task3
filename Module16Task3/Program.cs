using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Module16Task3
{
    class Program
    {    
        static void Main(string[] args)
        {
            
            try
            { 
                Console.WriteLine("Введите путь до папки");
                string folderName = Console.ReadLine();
                DirectoryInfo directoryInfo = new DirectoryInfo(folderName);
                Console.WriteLine($"Исходный размер папки: {DirectorySize(directoryInfo)}");
                Console.WriteLine($"Будет освобождено {DeleteData(directoryInfo)}");
                Console.WriteLine($"Текущий размер {DirectorySize(directoryInfo)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        public static long DeleteData(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] files = d.GetFiles();
            foreach (FileInfo f in files)
            {
                size += f.Length;
                f.Delete();
            }
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirectorySize(di);
                di.Delete(true);
            }
            return size;
        }

        public static long DirectorySize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] files = d.GetFiles();
            foreach (FileInfo f in files)
            {
                size += f.Length;
            }
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirectorySize(di);
            }
            return size;
        }

    }
}
