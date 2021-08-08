using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DylPCustomDS
{
    public class DynamicQueue
    {
        public List<dynamic> elements = new List<dynamic>();
        public int size = 0;

        public DynamicQueue()
        {
            ;
        }

        public DynamicQueue(dynamic[] initializerArray)
        {
            for( int i = 0; i < initializerArray.GetLength(0); i++ )
            {
                this.Enqueue(initializerArray[i]);
            }
        }

        public dynamic Dequeue()
        {
            dynamic topValue = this.elements[0];
            this.elements.RemoveAt(0);
            this.size -= 1;

            return topValue;
        }

        public void Enqueue(dynamic valueToPush)
        {
            elements.Add(valueToPush);
            this.size += 1;
        }

        public dynamic Next()
        {
            return this.elements[0];
        }
    }
}
