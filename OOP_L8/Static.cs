using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L8
{
    static class Static
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int MediumElemStack(Stack<int> stack)
        {
            int medium = stack.Count / 2;
            int[] temp = new int[stack.Count];
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                temp[i] = stack.Remove();
            }
            for (int i = 0; i < temp.Length; i++)
            {
                stack.Add(temp[i]);
            }
            return temp[medium];
        }

        public static int GetMaxElement(Stack<int> stack1)
        {
            int[] temp = new int[stack1.Count];
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                temp[i] = stack1.Remove();
            }
            return temp.Max();
        }

        public static int GetMinElement(Stack<int> stack)
        {
            int[] temp = new int[stack.Count];
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                temp[i] = stack.Remove();
            }
            return temp.Min();
        }

        public static Stack<int> IncrementN(Stack<int> stack, int N)
        {
            int[] temp = new int[stack.Count];
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                temp[i] = stack.Remove();
            }
            for (int i = 0; i < temp.Length; i++)
            {
                stack.Add(temp[i] + N);
            }
            return stack;
        }
    }
}
