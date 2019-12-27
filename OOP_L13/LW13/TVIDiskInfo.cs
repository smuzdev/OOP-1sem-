using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW13
{
    internal class TVIDiskInfo
    {
        private static readonly DriveInfo[] AllDisk = DriveInfo.GetDrives(); //возвращает имена всех логических 
                                                                             //дисков компьютера

        public static void FreeSpace(string name)
        {
            TVILog.WriteMessage("Метод для вывода информации о свободном месте на диске: " + name);
            Console.WriteLine(name);
            name = name + ":\\";
            Console.WriteLine(name);
            foreach (DriveInfo disk in AllDisk)
            {
                if (disk.Name == name)
                {
                    Console.WriteLine($"Name disk:{disk.Name}");
                    if (disk.IsReady) // готов ли диск
                    {
                        Console.WriteLine($"Free space: {disk.TotalFreeSpace / 1024 / 1024 / 1024} ГБ\n");
                                                // получает общий объем свободного места на диске в байтах
                    }
                }
            }
        }
        public static void DiskInfo()
        {
            TVILog.WriteMessage("Метод для вывода информации о дисках компьютера: ");
            foreach (DriveInfo disk in AllDisk)
            {
                Console.WriteLine($"Name disk:{disk.Name}");
                if (disk.IsReady)
                {
                    Console.WriteLine($"Total size: {disk.TotalSize / 1024 / 1024 / 1024} ГБ"); //общий размер диска в байтах
                    Console.WriteLine($"Free space: {disk.TotalFreeSpace / 1024 / 1024 / 1024} ГБ");
                    Console.WriteLine($"FileSystem:{disk.RootDirectory}"); // корневой каталог
                    Console.WriteLine($"VolumeLabel:{disk.VolumeLabel}");  // метка тома
                    Console.WriteLine($"DriveType:{disk.DriveType}\n");    // тип диска
                }
            }
        }
    }
}

