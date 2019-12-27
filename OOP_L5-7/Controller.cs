using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L5
{
    public static class Controller
    {
        public static void FindCountry(Planet planet, string continent)
        {
            Continent continent1;
            foreach (var item in planet.getList())
            {
                if (item is Continent)
                {
                    continent1 = item as Continent;
                    if (continent1.Name == continent)
                    {
                        continent1.Show();
                        break;
                    }
                }
            }
        }

        public static void CountSea(Planet planet)
        {
            int сount = 0;
            foreach (var item in planet.getList())
            {
                if (item is Sea)
                {
                    сount++;
                }
            }
            Console.WriteLine("\n-------------------------------\n" + $"Количество морей на планете {сount}" + "\n-------------------------------");
        }
        public static void ShowIsland(Planet planet)
        {
            List<string> islands = new List<string>();
            foreach (var item in planet.getList())
            {
                if (item is Island)
                {
                    islands.Add(item.Name);
                }
            }
            islands.Sort();
            foreach (string island in islands)
            {
                Console.WriteLine(island);
            }
            Console.WriteLine("\n-------------------------------");
        }

    }
}
