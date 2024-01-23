using Module8_2;
using System;
using System.IO;
using System.Reflection;

namespace Module8
{
    class Program
    {
        public static FileInfo configFile = new FileInfo(@"D:\C#\SystemConfig.txt");
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives.Where(d => d.DriveType == DriveType.Fixed))
            {
                DirectoryInfo root = drive.RootDirectory;
                DirectoryInfo[] folders = root.GetDirectories();

                Console.WriteLine($"Сканируем диск {drive.Name}");

                using (StreamWriter sw = configFile.AppendText())
                {
                    WriteDriveInfo(drive, sw);
                    WriteFileInfo(root, sw);
                    WriteFolderInfo(folders, sw);
                }

                Console.WriteLine("Операция выполнена");
                Console.WriteLine("__________________");
            }
        }

        public static void WriteDriveInfo(DriveInfo drive, StreamWriter sw)
        {
            sw.WriteLine($"Название: {drive.Name}");
            sw.WriteLine($"Тип: {drive.DriveType}");

            if (drive.IsReady)
            {
                sw.WriteLine($"Объем: {drive.TotalSize}");
                sw.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                sw.WriteLine($"Метка: {drive.VolumeLabel}");
            }

        }
        public static void WriteFolderInfo(DirectoryInfo[] folders, StreamWriter sw)
        {
            sw.WriteLine("Папки: ");
            foreach (DirectoryInfo folder in folders)
            {
                try
                {
                    sw.WriteLine($"Имя: {folder.Name} \n\tРазмер: {DirectoryExtension.DirSize(folder)} байт");
                }
                catch (Exception ex)
                {
                    sw.WriteLine($"Имя: {folder.Name} \n\t Не удалось рассчитать размер: {ex.Message}");
                }
            }
        }
        public static void WriteFileInfo(DirectoryInfo rootFolder, StreamWriter sw)
        {
            sw.WriteLine("Файлы: ");
            foreach (FileInfo file in rootFolder.GetFiles())
            {
                try
                {
                    sw.WriteLine($"Имя: {file.Name} \n\tРазмер: {file.Length} байт");
                }
                catch (Exception ex)
                {
                    sw.WriteLine($"Имя: {file.Name} \n\t Не удалось рассчитать размер: {ex.Message}");
                }
            }
        }
    }
}