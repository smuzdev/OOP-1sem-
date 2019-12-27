using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW13
{
    internal class TVIFileInfo
    {
        private FileInfo file; //класс для работы с файлами
        public TVIFileInfo(string name = null)
        {
            TVILog.WriteMessage("Вызов конструктора класса: " + GetType().Name);
            if (name != null)
            {
                file = new FileInfo(name);
            }
        }

        public void Path()
        {
            TVILog.WriteMessage("Вывод инфомации о файле: " + file.Name + ". В классе :" + GetType().Name);
            if (file.Exists)
            {
                Console.WriteLine("\nПолный путь файла: " + file.FullName);
                Console.WriteLine("Размер файла: " + file.Length + "байт");
                Console.WriteLine("Расширение файла: " + file.Extension);
                Console.WriteLine("Имя файла: " + file.Name);
                Console.WriteLine("Дата создания файла: " + file.CreationTimeUtc);
                Console.WriteLine("Дата создания файла: " + file.CreationTime);
            }
        }
    }
}

