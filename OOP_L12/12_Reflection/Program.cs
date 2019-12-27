using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace _Reflection
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            TestForReflection testForReflection = new TestForReflection();
            
            Type type = testForReflection.GetType();
            Reflector reflector = new Reflector(type);
            reflector.AboutClass();
            reflector.PublicMethods();
            reflector.FieldsAndProperties();
            reflector.DeclearingInterfaces();
            reflector.MethodByType(typeof(int));
            Reflector.CallMethod("_Reflection.TestForReflection", "SumString");
        }
    }

    public class TestForReflection : Ibasic
    {
        public int propertyA { get; set; }
        public int propertyB { get; set; }
        public int field;

        public int Sum(int a, int b)
        {
            return a + b;
        }

        public void SumString (string a, string b)
        {
            Console.WriteLine(a+b);
        }

        public void run()
        {
            Console.WriteLine("Run");
        }

        public void stop()
        {
            Console.WriteLine("Stop");
        }
    }

    public interface Ibasic
    {
        void run();
        void stop();
    }


    public class Reflector
    {
        public Type type;
        public Reflector(Type type)
        {
            this.type = type;
        }

        //a.выводит всё содержимое класса в текстовый файл;
        public void AboutClass()
        {
            //using автоматически реализует Dispose
            using (FileStream fstream = new FileStream("class.txt", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                foreach (MemberInfo info in type.GetMembers())
                {
                    sw.WriteLine(info.DeclaringType + " - " + info.MemberType + " - " + info.Name + "\n");
                }                   //класс                  //тип члена класса         //имя члена класса
                sw.Close();
            }
        }

        //b. извлекает все общедоступные публичные методы класса;
        public void PublicMethods()
        {
            Console.WriteLine("================");
            Console.WriteLine("Public methods:");
            foreach (MethodInfo method in type.GetMethods())
            {
                if (method.IsPublic)  //если публичный, то выводит  
                {
                    Console.WriteLine(method.Name);
                }
            }
        }

        //с. получает информацию о полях и свойствах класса;
        public void FieldsAndProperties()
        {
            Console.WriteLine("================");
            Console.WriteLine("Fields:");
            foreach (FieldInfo field in type.GetFields())
            {
                Console.WriteLine(field.Name);
            }

            Console.WriteLine("Properties:");
            foreach (PropertyInfo property in type.GetProperties())
            {
                Console.WriteLine(property.Name);
            }
        }

        //d получает все реализованные классом интерфейсы;
        public void DeclearingInterfaces()
        {
            Console.WriteLine("================");
            Console.WriteLine("Declearing Interfaces:");
            foreach (Type interfaces in type.GetInterfaces())
            {
                Console.WriteLine(interfaces.Name);
            }

        }

        //e. выводит по имени класса имена методов, которые содержат заданный(пользователем) тип параметра
        public void MethodByType(Type parameterType)
        {
            MethodInfo[] methods = parameterType.GetMethods();
            IEnumerable<MethodInfo> result = methods
                .Where(a => a.GetParameters()
                .Where(t => t.ParameterType == parameterType)
                    .Count() != 0
                );
            Console.WriteLine($"All methods with type of parameter {parameterType.Name}: ");
            foreach (MethodInfo el in result)
            {
                Console.WriteLine(el.Name);
            }
        }

        //f
        public static void CallMethod(string className, string methodName)
        {
            Type type = Type.GetType(className);
            try
            {
                object obj = Activator.CreateInstance(type);
                string[] _params = File.ReadAllLines(@"Parameters.txt");
                MethodInfo method = type.GetMethod(methodName);
                Console.WriteLine("Result of execution of method:");
                Console.WriteLine(method.Invoke(obj, _params));
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка.");
            }
      
        }
    }
}
