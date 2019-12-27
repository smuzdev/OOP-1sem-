using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L5
{
    class Printer
    {
        public virtual void iAmPrinting(Planet obj)
        {
            if (obj is Continent)
            {
                if (obj as Country != null)
                {
                    Console.WriteLine("Страна");
                }
                else if(obj as Island != null)
                {
                    Console.WriteLine("Остров");
                }
                else
                {
                    Console.WriteLine("Континент");
                }
            }
            Console.WriteLine(obj.ToString());
        }
    }
}
    
    


