using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1_Multithreading_and_asynchronous_processing
{
    class Program
    {
        #region variables / LocalStatic / ThreadLocal<T>

        [ThreadStatic] // this makes each thread creates each own copy of this variable. always returning the default value of a type. For this specific case -> 0;
        private static int _staticCounter = 10;

        // this makes each thread creates each own copy of this variable. Always returning 10 as default value;
        private static ThreadLocal<int> _threadLocalCounter = new ThreadLocal<int>(() =>
        {
            return 10;
        });

        #endregion

        static void Main(string[] args)
        {
            #region ThreadStart / ParameterizedThreadStart / t.Join / t.IsBackground

            ////Thread t = new Thread(new ThreadStart(MyMethod));
            //Thread t = new Thread(new ParameterizedThreadStart(MyMethod));
            ////t.IsBackground = true; // default is false. If true, the program does not wait it finishes to close.
            //t.Start(50);

            //Console.WriteLine("Main thread.");

            //t.Join(); // wait until both threads finish
            //Console.WriteLine("Finishing both threads execution");

            #endregion

            #region variables / LocalStatic / ThreadLocal<T>

            //var t1 = new Thread(new ThreadStart(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        //_threadLocalCounter.Value++;
            //        //Console.WriteLine(_threadLocalCounter);

            //        _staticCounter++;
            //        Console.WriteLine(_staticCounter);
            //    }
            //}));

            //var t2 = new Thread(new ThreadStart(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        //_threadLocalCounter.Value++;
            //        //Console.WriteLine(_threadLocalCounter);

            //        _staticCounter++;
            //        Console.WriteLine(_staticCounter);
            //    }
            //}));

            //t1.Start();
            //t2.Start();

            #endregion

            #region ThreadPool

            // when using the thread pool, the thread will only run when there is a available thread on the thread pool
            // the problem with thread pool is that we can't manage the thread quite well

            //ThreadPool.QueueUserWorkItem((s) =>
            //{
            //    Console.WriteLine("Running a thread from the thread pool");
            //});

            #endregion

            #region Task / ContinueWith / TaskConfigurationOption

            // working with manage threads from thread pool

            //Task t1 = Task.Run(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.Write("*");
            //    }
            //});

            //Task t2 = Task.Run(action: MyMethod);

            //var t3 = Task.Run(() =>
            //{
            //    return 10;
            //}).ContinueWith(t =>
            //{
            //    return t.Result * 2;
            //});

            //Console.WriteLine(t3.Result);

            //Task.Run(() =>
            //{
            //    Console.WriteLine("start executing a task");
            //    throw new Exception();
            //}).ContinueWith(res =>
            //{
            //    Console.WriteLine("error");
            //}, TaskContinuationOptions.OnlyOnFaulted)
            //.ContinueWith(res =>
            // {
            //     Console.WriteLine("completed");
            // }, TaskContinuationOptions.OnlyOnRanToCompletion);

            #endregion

            #region waitall

            //Task[] tasks = new Task[3];

            //tasks[0] = Task.Run(() => {
            //    Thread.Sleep(1000);
            //    Console.WriteLine("01");
            //});
            //tasks[1] = Task.Run(() => {
            //    Thread.Sleep(3000);
            //    Console.WriteLine("02");
            //});
            //tasks[2] = Task.Run(() => {
            //    Thread.Sleep(2000);
            //    Console.WriteLine("03");
            //});

            //Task.WaitAll(tasks); // wait all tasks to move forward - void
            //Task.WaitAny(tasks); // wait for any of thanks to move forward - return the index

            #endregion

            #region Parallel

            //Parallel.For(0, 10, t =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"line {t}");
            //});

            //var arr = Enumerable.Range(0, 10);
            //Parallel.ForEach(arr, new ParallelOptions() { MaxDegreeOfParallelism = 2 }, t =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"line {t}");
            //});

            //Parallel.Invoke(MyMethod, () => MyMethod(20));

            #endregion

            #region async await

            //var downloadResult = Download("http://www.blackwasp.co.uk/InvokeMaxParallelism.aspx");

            //Console.WriteLine("Main thread");
            //Console.Write(downloadResult.Result);

            #endregion

            #region PLINQ

            //var numbers = Enumerable.Range(0, 1000);

            ////var result = numbers.Where(i => OddNumber(i)).ToList();
            //var result = numbers.AsParallel().Where(i => OddNumber(i)).ToList();

            ////with AsOrdered() the operation is still executed in parallel but it preservs ordering
            ////var result = numbers.AsParallel().AsOrdered().Where(i => OddNumber(i)).ToList();

            ////AsSequencial() breaks the parallel execution. Every command executed after that will be sync
            ////var result = numbers.AsParallel().Where(i => OddNumber(i)).AsSequential().ToList();

            #endregion

            #region concurrent collections

            #region blocking collection

            //BlockingCollection<string> col = new BlockingCollection<string>();

            //Task read = Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(2000);
            //        Console.WriteLine(col.Take());
            //    }
            //});
            //Task write = Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        string s = Console.ReadLine();
            //        if (string.IsNullOrWhiteSpace(s)) break;
            //        col.Add(s);
            //    }
            //});
            //write.Wait();

            #endregion

            #region concurrent bag

            //ConcurrentBag<int> bag = new ConcurrentBag<int>();
            //bag.Add(42);
            //bag.Add(21);
            //int result;
            //if (bag.TryTake(out result))
            //    Console.WriteLine(result);
            //if (bag.TryPeek(out result))
            //    Console.WriteLine($"There is a nextitem:{result}");

            #endregion

            #region ConcurrentStack

            //ConcurrentStack<int> stack = new ConcurrentStack<int>();
            //stack.Push(42);
            //int result;
            //if (stack.TryPop(out result))
            //    Console.WriteLine($"Popped:{result}");
            //stack.PushRange(new int[] { 1, 2, 3 });
            //int[] values = new int[2];
            //stack.TryPopRange(values);
            //foreach (int i in values)
            //    Console.WriteLine(i);

            #endregion

            #region ConcurrentQueue

            //ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            //queue.Enqueue(42);
            //int result;
            //if (queue.TryDequeue(out result))
            //    Console.WriteLine($"Dequeued:{result}");

            #endregion

            #region ConcurrentDictionary

            //var dict = new ConcurrentDictionary<string, int>();
            //if (dict.TryAdd("k1", 42))
            //{
            //    Console.WriteLine("Added");
            //}
            //if (dict.TryUpdate("k1", 21, 42))
            //{
            //    Console.WriteLine("42updatedto21");
            //}
            //dict["k1"] = 42; // Overwrite unconditionally
            //int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            //int r2 = dict.GetOrAdd("k2", 3);

            #endregion

            #endregion

            Console.ReadLine();
        }
        private static bool OddNumber(int i)
        {
            Thread.Sleep(1000);

            if (i % 2 != 0)
            {
                Console.WriteLine(i);
                return true;
            }
            return false;
        }

        private static async Task<string> Download(string url)
        {
            using (HttpClient httpClient = new HttpClient())
                return await httpClient.GetStringAsync(url);
        }

        private static void MyMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Line {i}");
                Thread.Sleep(100);
            }
        }

        private static void MyMethod(object o) // a type object is mandatory when you want to start a thread with parameters
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine($"Line {i}");
                Thread.Sleep(100);
            }
        }
    }
}













