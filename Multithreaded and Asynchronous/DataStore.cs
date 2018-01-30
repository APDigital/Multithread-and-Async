using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreaded_and_Asynchronous
{
    class DataStores
    {
        private class DataStore { public int Value { get; set; } }

        private DataStore firstStore = new DataStore();
        private DataStore secondStore = new DataStore();

        public void ConcurrencyTest()
        {
            var thread1 = new Thread(IncrementTheValue);
            var thread2 = new Thread(IncrementTheValue);

            thread1.Start();
            thread2.Start();

            thread1.Join(); // Wait for the thread to finish executing
            thread2.Join();

            Console.WriteLine($"Final values: First:{firstStore.Value}, Second:{secondStore.Value}");
        }

        private void IncrementTheValue()
        {
            lock (firstStore)
            {
                lock (secondStore)
                {
                    firstStore.Value++;
                    secondStore.Value++;
                }
                
            }
        }
    }
}
