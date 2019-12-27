using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L5
{
    sealed partial class Country : Continent
    {
        struct Population
        {
            public int menPopulation;
            public int womanPopulation;
            public Population(int _menPopulation, int _womanPopulation)
            {
                menPopulation = _menPopulation;
                womanPopulation = _womanPopulation;
            }
        }
        Population population;
       
        public override string ToString()
        {
            return "Государство:\n" +
                   "\tНазвание: " + Name.ToString() +
                   "\n\tПлощадь: " + Area.ToString() + " тыс.кв.км" +
                   "\n\tЧисленность населения м: " + population.menPopulation.ToString() + " млн" +
                   "\n\tЧисленность населения ж: " + population.womanPopulation.ToString() + " млн";
        }
    }
}
