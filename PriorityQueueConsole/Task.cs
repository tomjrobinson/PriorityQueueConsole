using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriorityQueueConsole
{
    


    public class PriorityQueue<T>
    {
        private int count = 0;
        private QueueElement[] queueArray = new QueueElement[10];

        private int parent(int index)
        {
            return (index - 1) / 2;
        }
        private int left(int index)
        {
            return index * 2 + 1;
        }
        private int right(int index)
        {
            return index * 2 + 2;
        }

        public void Enqueue(int Priority, T item)
        {
            queueArray[count] = new QueueElement(Priority, item);
            heapUp(count);
            count++;
        }
        private void swap(int fromIndex, int toIndex)
        {
            QueueElement Temp = queueArray[toIndex];
            queueArray[toIndex] = queueArray[fromIndex];
            queueArray[fromIndex] = Temp;
        }

        private void heapUp(int index){
            //base case/termination case
            //either the most basic ammount of work you have to do or exit condition
            if (index == 0) return;

            //iterative case - a portion of work
            if (queueArray[parent(index)].priority > queueArray[index].priority)
                swap(parent(index), index);
          
            //recursive call
            heapUp(parent(index));
        }

        private void heapDown(int index)
        {
            if (right(index) <= count - 1 && queueArray[right(index)].priority
                < queueArray[left(index)].priority)
            {
                if (queueArray[right(index)].priority < queueArray[index].priority)
                    swap(right(index), index);

                heapDown(right(index));
            }
            else if (left(index) <= count - 1)
            {
                if (queueArray[left(index)].priority < queueArray[index].priority)
                    swap(left(index), index);

                heapDown(left(index));
            }
        }

        public T Dequeue()
        {

            if (count == 0)
                throw new QueueEmptyException();

            T returnValue = queueArray[0].Item;

            
            queueArray[0] = queueArray[count - 1];

            heapDown(0);

            count--;
            return returnValue;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        class QueueElement
        {
            public int priority;
            public T Item;

            public QueueElement(int Priority, T item)
            {
                this.priority = Priority;
                this.Item = item;
            }
        }
    }

    class QueueEmptyException : Exception
    {
        public QueueEmptyException() : base("Queue is empty")
        {
            
        }
    }
}
