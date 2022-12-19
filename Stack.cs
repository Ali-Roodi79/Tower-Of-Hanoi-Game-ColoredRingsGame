using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Of_Hanoi
{
    public class Stack
    {
        private string[] Array;
        private int Top;
        private int Count;

        public Stack(int size)
        {
            Array = new string[size];
            Top = -1;
        }
        public void Push(string value)
        {
            if(IsFull())
            {
                throw new InvalidOperationException("Stack Overflow !");
            }
            else
            {
                Array[++Top] = value;
                Count++;
            }

        }
        public string Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The Stack is Empty !");
            }
            else
            {
                Count--;
                return Array[Top--];
            }
        }
        public string Peek()
        {
            return Array[Top];
        }
        public bool IsEmpty()
        {
            return Top == -1;
        }
        public bool IsFull()
        {
            return Top == Array.Length - 1;
        }
        public string GetItem(int index)
        {
            if (IsEmpty() || index > Top) return default;
            else return Array[index];
        }
        public string[] GetArrray()
        {
            return Array;
        }
        public int GetCount()
        {
            return Count;
        }
    }
}
