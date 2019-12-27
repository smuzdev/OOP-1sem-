using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L5
{
    sealed partial class Country : Continent
    {
        public Country(string _name = "", int _area = -1, int _menPopulation = -1, int _womanPopulation = -1) : base(_name, " ", _area)
        {
            population = new Population(_menPopulation, _womanPopulation);
        }
    }
}
