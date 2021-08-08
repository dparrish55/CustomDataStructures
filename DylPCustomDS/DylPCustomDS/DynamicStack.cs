using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DylPCustomDS
{
    public class DynamicStack
    {
        public dynamic[] elements;
        public int size;
        private int ubound;

        public DynamicStack()
        {
            this.elements = new dynamic[0];
            this.size = 0;
            this.ubound = 0;
        }

        public DynamicStack(dynamic[] initializerArray)
        {
            for( int i = 0; i < initializerArray.GetLength(0); i++ )
            {
                this.Push(initializerArray[i]);
            }
        }

        public dynamic Pop()
        {
            dynamic topValue = this.elements[this.size - 1];
            this.elements[this.size - 1] = null;
            this.size -= 1;

            if (this.size <= this.ubound / 2)
            {
                this.ubound /= 2;
            }

            return topValue;
        }

        public void Push(dynamic valueToPush)
        {
            if (this.size + 1 > this.ubound)
            {
                if (this.ubound == 0)
                {
                    this.ubound = 1;
                }
                else
                {
                    this.ubound *= 2;
                }

                Array.Resize<dynamic>(ref this.elements, this.ubound);
            }

            elements[this.size] = valueToPush;
            this.size += 1;
        }

        public dynamic Top()
        {
            return this.elements[this.size - 1];
        }
    }
}
