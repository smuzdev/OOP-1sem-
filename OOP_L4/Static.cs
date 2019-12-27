using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L4
{
    static class Static
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int MediumElemStack(Stack stack)
        {
            int medium = stack.Count / 2;
            int[] temp = new int[stack.Count];
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                temp[i] = stack.Pop();
            }
            for (int i = 0; i < temp.Length; i++)
            {
                stack.Push(temp[i]);
            }
            return temp[medium];
        }

        public static int GetMaxElement(Stack stack1)
        {
            int[] temp = new int[stack1.Count];
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                temp[i] = stack1.Pop();
            }
            return temp.Max();
        }

        public static int GetMinElement(Stack stack)
        {
            int[] temp = new int[stack.Count];
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                temp[i] = stack.Pop();
            }
            return temp.Min();
        }

        public static Stack IncrementN(Stack stack, int N)
        {
            int[] temp = new int[stack.Count];
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                temp[i] = stack.Pop();
            }
            for (int i = 0; i < temp.Length; i++)
            {
                stack.Push(temp[i] + N);
            }
            return stack;
        }
    }
}
