using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OOP_L5
{
    class Program
    {
        static void Main(string[] args)
        {
            Planet planet1 = new Planet("Земля");

            Console.WriteLine(planet1.ToString() + "\n-------------------------------");

            Sea sea1 = new Sea("Черное море", 26, 300);
            Console.WriteLine(sea1.ToString());
            Sea sea2 = new Sea("Балтийское море", 26, 300);
            Console.WriteLine(sea2.ToString() + "\n-------------------------------");

            Continent continent1 = new Continent("Европа", "Чернозем", 10);
            Console.WriteLine(continent1.ToString());
            Continent continent2 = new Continent("Азия", "", 45);
            Console.WriteLine(continent2.ToString() + "\n-------------------------------");

            Country counrty1 = new Country("France", 400, 15, 15);
            Country counrty2 = new Country("UK", 400, 15, 15);
            Country counrty3 = new Country("China", 1400, 15, 15);
            Country counrty4 = new Country("Japan", 200, 15, 15);
            continent1.Add(counrty1);
            continent1.Add(counrty2);
            continent2.Add(counrty3);
            continent2.Add(counrty4);
            Island island1 = new Island("Мадагаскар", "Песок", 587000, 1, 30);
            Island island2 = new Island("Гренландия", "Снег", 2130000, 1, -45);
            Island island3 = new Island("Бали", "Песок", 5780, 1, 35);
            island1.Disasters();
            Console.WriteLine(island1.ToString() + "\n-------------------------------");

            Printer p = new Printer();
            Planet[] pln = new Planet[4];
            pln[0] = sea1;
            pln[1] = counrty1;
            pln[2] = continent1;
            pln[3] = island1;
            for (int i = 0; i < 4; i++)
            {
                p.iAmPrinting(pln[i]);
            }
            Console.WriteLine("\n-------------------------------");
            Planet planet = new Planet("Земля");
            planet.Add(continent1);
            planet.Add(continent2);
            planet.Add(sea1);
            planet.Add(sea2);
            planet.Add(island1);
            planet.Add(island2);
            planet.Add(island3);
            planet.Show();
            Controller.FindCountry(planet, "Европа");
            Controller.CountSea(planet);
            Controller.ShowIsland(planet);

            ((IWater)sea1).Method();
            ((IMethod)sea1).Method();

            Console.WriteLine("-------------------------------");
            try
            {
                Island island5 = new Island("Гренландия", "Снег", 2130000, -1, -45);
            }
            catch (ConstructorException exception)
            {
                exception.GetInfo();
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка");
            }
            try
            {
                Planet planet2 = new Planet();
            }
            catch (EmptyException exception)
            {
                exception.GetInfo();
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка");
            }
            try
            {
                int x = 5;
                int y = 0;
                x = y != 0 ? x / y : throw new NullException("На ноль делить нельзя");
            }
            catch (NullException exception)
            {
                exception.GetInfo();
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка");
            }
            finally
            {
                Console.WriteLine("Этот блок выполнится обязательно");
            }
            //int[] Array = null;
            //Debug.Assert(Array != null, "Ошибка");
        }
    }
}