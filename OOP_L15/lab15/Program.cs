using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;
using static System.Console;
namespace lab15
{
    public class Numbers
    {
        private int n;
        public StreamWriter file = new StreamWriter("oddeven.txt", false);
        public Numbers(int _n)
        {
            n = _n;
        }
        ~Numbers()
        {
            try { file.Close(); }
            catch { };
        }
        public void ForTimer(object obj)
        {
            for (int i = 1; i < n; i++)
                Write('.');
            WriteLine();
        }
        public void Odd()  //нечет
        {
            if (file.BaseStream == null)
                file = new StreamWriter("oddeven.txt", true);
            for (int i = 1; i < n; i++)
            {
                Thread.Sleep(30);
                if (i % 2 != 0)
                {
                    if (file.BaseStream == null)
                        file = new StreamWriter("oddeven.txt", true);
                    file.WriteLine(i);
                    WriteLine("Odd number " + i);
                }
            }
            if (file.BaseStream != null)
                file.Close();
        }
        public void Even() //чет
        {
            lock (this)
            {
                for (int i = 1; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (file.BaseStream == null)
                            file = new StreamWriter("oddeven.txt", true);
                        file.WriteLine(i);
                        WriteLine("Even number " + i);
                    }
                    if (file.BaseStream != null)
                        file.Close();
                }
            }
        }
        public void Odd1()
        {
            Monitor.Enter(this);
            {
                if (file.BaseStream == null)
                    file = new StreamWriter("oddeven.txt", true);
                for (int i = 1; i < n; i++)
                {
                    
                    if (i % 2 != 0)
                    {
                       
                        if (file.BaseStream == null)
                            file = new StreamWriter("oddeven.txt", true);
                        file.WriteLine(i);
                        WriteLine("MonitorOdd " + i);
                        Monitor.Pulse(this);
                        Monitor.Wait(this);
                    }
                }
                if (file.BaseStream != null)
                    file.Close();
                Monitor.Exit(this);
            }
        }
        public void Even1()
        {
            Monitor.Enter(this);
            {
                if (file.BaseStream == null)
                    file = new StreamWriter("oddeven.txt", true);
                for (int i = 1; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (file.BaseStream == null)
                            file = new StreamWriter("oddeven.txt", true);
                        file.WriteLine(i);
                        WriteLine("MonitorEven "+i);
                        Monitor.Pulse(this);
                        Monitor.Wait(this);
                    }
                }
                if (file.BaseStream != null)
                    file.Close();
                Monitor.Exit(this);
            }
        }
    }
    class Program
    {
        public static void begin(object n)
        {
            WriteLine("Имя потока: " + Thread.CurrentThread.Name);
            WriteLine("Приоритет потока: " + Thread.CurrentThread.Priority.ToString());
            WriteLine("Id потока: " + Thread.CurrentThread.ManagedThreadId.ToString());
            WriteLine("Статус потока: " + Thread.CurrentThread.ThreadState.ToString());
            StreamWriter fout = new StreamWriter("easynumbers.txt");
            bool flag;
            for (int i = 1; i < (int)n + 1; i++)
            {
                Thread.Sleep(10);
                flag = true;
                for (int j = i; j > 0; j--)
                    if ((i % j == 0) && (j != 1) && (j != i))
                    {
                        flag = false;
                        break;
                    }
                if (flag == true)
                {
                    fout.WriteLine(i.ToString());
                    WriteLine("Simple number " + i.ToString());
                }
            }
            fout.Close();
        }

        static void Main(string[] args)
        {
            Process[] proc = Process.GetProcesses();
            foreach (Process x in proc)
            {
                try
                {
                    WriteLine("Id процесса: " + x.Id.ToString());
                    WriteLine("Имя процесса: " + x.ProcessName);
                    WriteLine("Приоритет: " + x.BasePriority.ToString());
                    WriteLine("Время старта: " + x.StartTime.ToString());
                    WriteLine("Время затраты процессора: " + x.TotalProcessorTime.ToString());
                    if(x.StartTime.ToString() != null)
                        WriteLine("Состояние: запущен");
                    WriteLine();
                }
                catch
                {
                    WriteLine();
                }
            }
            AppDomain domain = AppDomain.CurrentDomain;
            WriteLine($"Name: {domain.FriendlyName}");
            WriteLine($"Base Directory: {domain.BaseDirectory}");
            WriteLine($"Setup Information: {domain.SetupInformation}");
            WriteLine();
            Assembly buf = null;
            foreach (Assembly x in domain.GetAssemblies())
            {
                if (x.GetName().Name == "lab15")
                    buf = x;
                WriteLine(x.ToString());
            }
            AppDomain mydomain = AppDomain.CreateDomain("my new domain");
            Assembly buf2 = mydomain.Load(buf.GetName());
            AppDomain.Unload(mydomain);
            WriteLine(buf2.ToString());

            int n;
            bool flag;
            while (true)
            {
                WriteLine("Enter n:");
                flag = int.TryParse(ReadLine(), out n);
                if (flag == false)
                    WriteLine("Неверно введено значение. Введите снова");
                else break;
            }

            Thread mythread = new Thread(new ParameterizedThreadStart(begin));
            mythread.Name = "\"Vladislav\'s thread\"";
            mythread.Priority = ThreadPriority.Highest;
            mythread.Start(n);

            Thread thread1, thread2;
            Numbers numbers = new Numbers(n);
            thread1 = new Thread(numbers.Odd);
            thread2 = new Thread(numbers.Even);
            thread1.IsBackground = true;
            thread2.IsBackground = true;
            thread1.Priority = ThreadPriority.AboveNormal;
            thread1.Start();
            thread2.Start();

            Thread.Sleep(3000);
            Thread thread3 = new Thread(numbers.Odd1);
            Thread thread4 = new Thread(numbers.Even1);
            thread3.IsBackground = true;
            thread4.IsBackground = true;
            thread3.Priority = ThreadPriority.AboveNormal;
            thread3.Start();
            thread4.Start();
            TimerCallback a = new TimerCallback(numbers.ForTimer);
            Timer timer = new Timer(a, 1, 10000, 200);
            WriteLine("sd");
            ReadKey();
        }
    }
}
