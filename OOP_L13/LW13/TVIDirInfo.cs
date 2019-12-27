using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW13
{
    internal class TVIDirInfo
    {
        private DirectoryInfo dir; // класс для операций с каталогами
        public TVIDirInfo(string _dir = null)
        {
            TVILog.WriteMessage("Вызов конструктора класса: " + GetType().Name);
            dir = new DirectoryInfo(_dir);
        }
        public void DirInfo()
        {
            TVILog.WriteMessage("Вывод инфомации о папке: " + dir.Name + ". В классе :" + GetType().Name);
            if (dir.Exists)
            {
                Console.WriteLine("\nИмя каталога: " + dir.Name);
                Console.WriteLine("Количество файлов: " + dir.GetFiles().Count()); //получает список файлов и подсчитывает их
                Console.WriteLine("Время создание каталога: " + dir.GetFiles().Count());
                Console.WriteLine("Количество подкаталогов: " + dir.GetDirectories().Count());
                Console.WriteLine("Список родительских катологов подкаталогов: ");
                ParentList();
            }
        }
        private void ParentList() 
        {
            TVILog.WriteMessage("Вывод списка родительских папок , папки: " + dir.Name + ". В классе :" + GetType().Name);
            DirectoryInfo temp = new DirectoryInfo(dir.FullName);
            while (temp != null)
            {
                Console.WriteLine(temp = temp.Parent); //получение родительского каталога
            }
        }
    }
}

