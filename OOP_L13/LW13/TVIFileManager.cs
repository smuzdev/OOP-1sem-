using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LW13
{
    internal static class TVIFileManager
    {
        private static ZipArchive zip;
        public static void FileSubdir(string name = null)
        {
            TVILog.WriteMessage("Вывод инфомации о вложенных папках и файлах диска: " + name);
            if (name != null)
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(name); //получает список папок
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(name); //получает список файлов
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }
        public static void CreateA()
        {
            TVILog.WriteMessage("Создание папки,файла,заполнение,копирование,удаления");
            string path = @"D:\\BSTU\\СТПМС\\";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("TVIInspect"); //создает каталог по указанному пути path
            if (!directory.Exists) // проверяет, существует ли каталог
            {
                directory.Create();
            }

            Console.WriteLine(directory.FullName);
            FileInfo file = new FileInfo(directory.FullName + "TVIInspect\\tvidirinfo.txt");
            using (FileStream fs = new FileStream(file.FullName, FileMode.OpenOrCreate))
            {
                string text = "Hello World";
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fs.Write(array, 0, array.Length);
                fs.Close();
            }
            File.Copy(file.FullName, file.DirectoryName + "\\test.txt", true);
            file.CopyTo("newfile.txt", true);
            file.Delete();
        }
        public static void CreateB()
        {
            TVILog.WriteMessage("Создание папки,перемещение файлов с заданым расширение из одной папки в другую");
            string path = @"D:\\BSTU\\СТПМС\\";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("TVIFiles");
            if (!directory.Exists)
            {
                directory.Create();
            }

            Console.WriteLine(directory.FullName);
            DirectoryInfo source = new DirectoryInfo(@"D:\\BSTU\\СТПМС\\lections");
            DirectoryInfo destin = new DirectoryInfo(@"D:\\BSTU\\СТПМС\\TVIFiles\\");
            DirectoryInfo destin1 = new DirectoryInfo(@"D:\\BSTU\\СТПМС\\TVIInspect\\TVIFiles");
            foreach (FileInfo item in source.GetFiles().Where(x => x.Extension == ".txt").ToList())
            {
                item.CopyTo(destin + item.Name, true); //копирование в новое место
            }
            if (!destin1.Exists)
            {
                destin.MoveTo(destin1.FullName); //
            }
        }
        
        public static void CreateC()
        {
            TVILog.WriteMessage("Архивирование папки");
            DirectoryInfo bufdirectory = new DirectoryInfo(@"D:\\BSTU\\СТПМС\\TVIInspect\\TVIFiles");
            if (!File.Exists(@"D:\\BSTU\\СТПМС\\TVIInspect\\TVIFiles.zip"))
            {
                ZipFile.CreateFromDirectory(bufdirectory.FullName, bufdirectory.FullName + ".zip");
            }
            using (ZipArchive zip = new ZipArchive(File.Open(bufdirectory.FullName + ".zip", FileMode.Open)))
            {
                DirectoryInfo bufdirectory1 = new DirectoryInfo(@"D:\\BSTU\\СТПМС\\TVIInspect");
                foreach (ZipArchiveEntry x in zip.Entries)
                    x.ExtractToFile(bufdirectory1.FullName + '\\' + x.Name, true);
            }
        }
    }
}
