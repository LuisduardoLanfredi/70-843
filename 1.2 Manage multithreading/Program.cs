using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._2_Manage_multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            #region lock

            //int num = 0;

            //object _lock = new object();

            //var t = Task.Run(() =>
            //{
            //    for (int i = 0; i < 10000000; i++)
            //    {
            //        lock (_lock)
            //            num++;
            //    }
            //});

            //for (int i = 0; i < 10000000; i++)
            //{
            //    lock (_lock)
            //        num--;
            //}

            //t.Wait();
            //Console.WriteLine(num);

            #endregion

            #region deadlock

            //var _lockA = new Object();
            //var _lockB = new Object();

            //Task.Run(() =>
            //{
            //    lock(_lockA)
            //    {
            //        lock (_lockB)
            //        {
            //            Console.WriteLine("A and B are locked.");
            //        }
            //    }
            //});

            //lock (_lockB)
            //{
            //    Thread.Sleep(1000);
            //    lock (_lockA)
            //    {
            //        Console.WriteLine("B and A are locked.");
            //    }
            //}

            //Console.WriteLine("finish");

            #endregion

            #region interlocked class

            //int num = 0;

            //object _lock = new object();

            //var t = Task.Run(() =>
            //{
            //    for (int i = 0; i < 10000000; i++)
            //    {
            //       Interlocked.Increment(ref num);
            //    }
            //});

            //for (int i = 0; i < 10000000; i++)
            //    Interlocked.Decrement(ref num);

            //t.Wait();
            //Console.WriteLine(num);

            #endregion

            #region cancelationtoken

            //CancellationTokenSource source = new CancellationTokenSource();
            //var token = source.Token;

            //var t = Task.Run(() =>
            //{
            //    while (!token.IsCancellationRequested)
            //    {
            //        Console.Write("*");
            //        Thread.Sleep(500);
            //    }

            //    token.ThrowIfCancellationRequested();
            //}, token);


            //try
            //{
            //    Console.ReadLine();
            //    source.Cancel();
            //    t.Wait();
            //}
            //catch (AggregateException e)
            //{
            //    Console.WriteLine(e.InnerExceptions[0].ToString());
            //}

            #endregion

            Console.ReadLine();
        }
    }
}
