using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L5
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
    public class NullException : Exception
    { 
        private string message;
        public NullException(string _message)
        {
            message = _message;
        }
        public void GetInfo()
        {
            Console.WriteLine(
               "NullException: " + message +
               "\nМетод вызвавший ошибку" + this.TargetSite
               );
        }
    }
    public class ConstructorException : Exception
    {
        private string message;
        public ConstructorException(string _message)
        {
            message = _message;
        }
        public ConstructorException()
        {
            message = "Ошибка в конструкторе";
        }
        public void GetInfo()
        {
            Console.WriteLine(
                "ConstructorException: " + message +
                "\nМетод вызвавший ошибку" + this.TargetSite
                );
        }
    }
}
