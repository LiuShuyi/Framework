using System;
using System.Collections.Generic;

namespace Yintai.Service.Payment.TradeQuery.Contract.Model
{
    public class TaskQueue<T> where T : class
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public TaskQueue()
        {
            orderQueue = new Queue<T>();
        }

        /// <summary>
        /// taskQueue
        /// </summary>
        private readonly Queue<T> orderQueue;

        /// <summary>
        /// locker
        /// </summary>
        private readonly Object locker = new Object();

        /// <summary>
        /// Task Queue Count
        /// </summary>
        public Int32 QueueCount
        {
            get { return orderQueue.Count; }
        }

        /// <summary>
        /// EnQueue Task
        /// </summary>
        /// <param name="paymentOrder"></param>
        public void EnQueue(T paymentOrder)
        {
            lock (locker)
            {
                orderQueue.Enqueue(paymentOrder);
            }
        }

        /// <summary>
        /// EnQueue TaskList
        /// </summary>
        /// <param name="paymentOrderList"></param>
        public void EnQueue(List<T> paymentOrderList)
        {
            lock (locker)
            {
                for (var i = 0; i < paymentOrderList.Count; i++)
                {
                    orderQueue.Enqueue(paymentOrderList[i]);
                }
            }
        }

        /// <summary>
        /// DeQueue Task
        /// </summary>
        /// <returns></returns>
        public T DeQueue()
        {
            lock (locker)
            {
                return orderQueue.Count == 0 ? null : orderQueue.Dequeue();
            }
        }

        public List<T> DeQueueAll()
        {
            var taskList = new List<T>();

            lock (locker)
            {
                if (orderQueue.Count == 0)
                {
                    return null;
                }

                while (true)
                {
                    if (orderQueue.Count <= 0)
                    {
                        break;
                    }

                    var task = orderQueue.Dequeue();

                    taskList.Add(task);
                }
            }

            return taskList;
        }

        /// <summary>
        /// DeQueue TaskList
        /// </summary>
        /// <param name="count">DeQueue Count</param>
        /// <returns></returns>
        public List<T> DeQueue(Int32 count)
        {
            var taskList = new List<T>();

            lock (locker)
            {
                for (var i = 0; i < count; i++)
                {
                    if (orderQueue.Count <= 0)
                    {
                        break;
                    }

                    var task = orderQueue.Dequeue();

                    taskList.Add(task);
                }
            }

            return taskList;
        }
    }
}
