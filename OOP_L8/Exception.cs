using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L8
{
    public class EmptyException : Exception
    {
        private string message;
        public EmptyException(string _message)
        {
            message = _message;
        }
        public void GetInfo()
        {
            Console.WriteLine("EmptyException: " + message +
                   "\nМетод вызвавший ошибку" + this.TargetSite);
        }
    }
}
