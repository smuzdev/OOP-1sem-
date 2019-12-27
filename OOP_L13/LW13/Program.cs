using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace LW13
{
    class Program
    {
        static void Main(string[] args)
        {
            TVIDiskInfo.FreeSpace("C");
            TVIDiskInfo.DiskInfo();
            TVIFileInfo file = new TVIFileInfo(@"D:\BSTU\СТПМС\lections\1.txt");
            TVIDirInfo dir = new TVIDirInfo(@"D:\BSTU\СТПМС\OOP_L13");
            Console.WriteLine("Информация о конкретном файле");
            file.Path();
            Console.WriteLine("Информация о конкретной папке");
            dir.DirInfo();
            TVIFileManager.FileSubdir("D:\\");
            TVIFileManager.CreateA();
            TVIFileManager.CreateB();
            TVIFileManager.CreateC();
            Console.WriteLine("Поиск по слову");
            TVILog.SearchWord("файле");
            Console.WriteLine("-----------------");
            TVILog.SearchDateDay("25");
            TVILog.SearchPartTime("13:00-20:00");
            TVILog.Count();
            TVILog.Delete();
            TVILog.Close();
            Console.ReadKey();
        }
    }
}
