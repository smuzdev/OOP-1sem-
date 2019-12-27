using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L8
{
    interface ICollectionType <T> where T : new()
    {
        void Add(T element);
        T Remove();
        void Show();
    }
}
