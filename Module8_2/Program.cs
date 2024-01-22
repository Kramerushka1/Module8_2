using Module8_2;
using System;
using System.IO;
using System.Reflection;

namespace Module8
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives.Where(d => d.DriveType == DriveType.Fixed))
            {
                WriteDriveInfo(drive);
                DirectoryInfo root = drive.RootDirectory;
                DirectoryInfo[] folders = root.GetDirectories();

                WriteFileInfo(root);
                WriteFolderInfo(folders);

                Console.WriteLine();
            }
        }

        public static void WriteDriveInfo(DriveInfo drive)
        {
            Console.WriteLine($"Название: {drive.Name}");
            Console.WriteLine($"Тип: {drive.DriveType}");
            
            if(drive.IsReady)
            {
                Console.WriteLine($"Объем: {drive.TotalSize}");
                Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                Console.WriteLine($"Метка: {drive.VolumeLabel}");
            }

        }
        public static void WriteFolderInfo(DirectoryInfo[] folders)
        {
            Console.WriteLine("Папки: ");
            foreach (DirectoryInfo folder in folders)
            {
                try
                {
                    Console.WriteLine($"Имя: {folder.Name} \n\tРазмер: {DirectoryExtension.DirSize(folder)} байт");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Имя: {folder.Name} \n\t Не удалось рассчитать размер: {ex.Message}");
                }
            }
        }
        public static void WriteFileInfo(DirectoryInfo rootFolder)
        {
            Console.WriteLine("Файлы: ");
            foreach (FileInfo file in rootFolder.GetFiles())
            {
                try
                {
                    Console.WriteLine($"Имя: {file.Name} \n\tРазмер: {file.Length} байт");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Имя: {file.Name} \n\t Не удалось рассчитать размер: {ex.Message}");
                }
            }
        }
    }
}