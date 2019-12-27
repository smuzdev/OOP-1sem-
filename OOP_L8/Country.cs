using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L8
{
    public class Country
    {
        private string name;
        public Country(string _name = null)
        {
            if (_name != null)
            {
                name = _name;
            }
            else
            {
                throw new EmptyException("Не задано название страны.");
            }
        }
    }
}
    