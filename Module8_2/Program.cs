using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace Module8
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktop = @"C:\Users\mrdoo\desktop";
            string newDir = @"C:\Users\mrdoo\desktop\testFolder";

            DirAndFilesCount(desktop);

            DirCreate(newDir);
            DirAndFilesCount(desktop);

            MoveToRecycleBin(newDir);
            DirAndFilesCount(desktop);

        }
        static void DrivesInformation()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize}");
                    Console.WriteLine($"Осталось: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
        }
        static void GetCatalogs()
        {
            string dirName = @"C:\";

            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }
                Console.WriteLine();

                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
        }
        static void DirAndFilesCount(string dir)
        {
            try
            {
                if (Directory.Exists(dir))
                {
                    string[] dirs = Directory.GetDirectories(dir);
                    string[] files = Directory.GetFiles(dir);
                    Console.WriteLine($"Всего папок и файлов: {files.Length + dirs.Length}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void DirCreate(string dir)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                    Console.WriteLine("Папка testFolder создана");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void DirDelete()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:\New Folder");

                if (dirInfo.Exists)
                {
                    dirInfo.Delete();
                    Console.WriteLine("Папка удалена");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void MoveToRecycleBin(string dirDelete)
        {
            try
            {
                FileSystem.DeleteDirectory(
                    dirDelete,
                    UIOption.AllDialogs,
                    RecycleOption.SendToRecycleBin,
                    UICancelOption.ThrowException);
                Console.WriteLine("Папка testFolder удалена в корзину.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении папки в корзину: {ex.Message}");
            }
        }
    }
}