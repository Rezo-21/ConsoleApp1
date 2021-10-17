using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class program
    {
        public static object locker = new object();

        public static int i1 = 0;
        #region deadlock
        //static void M1()
        //{
        //for (int i = 0; i <= i1; i++)
        //{

        //}
        //}
        //static void M2()
        //{
        //for (int i = 0; i >= i1; i--)
        //{

        //}
        //}
        #endregion
        static void Main(string[] args)
        {
            #region thread
            // Thread thread = new Thread(new ThreadStart(DoWork));
            //  thread.Start();

            //  Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork2));
            //  thread2.Start(int.MaxValue);

            //  int j = 0;
            //  for (int i = 0; i < int.MaxValue; i++)
            //  {
            //      j++;

            //      if (j % 10000 == 0)
            //      {
            //          Console.WriteLine("Main");
            //       }
            //  }
            #endregion

            #region async/await
            //Console.WriteLine("begin Main");
            //DoWorkAsync();
            //Console.WriteLine("continue Main");
            //for (int i = 0; i < 10; i++)
            //{                 
            //    Console.WriteLine("Main");                  
            //}
            //Console.WriteLine("end Main");
            #endregion

            var result = SaveFileAsync("d:\\test.txt");
            var input = Console.ReadLine();
            Console.WriteLine(result.Result);
            Console.ReadLine();
        }

        static async Task<bool> SaveFileAsync(string path)
        {
            var result = await Task<bool>.Run(() => SaveFile(path));
            return result;
        }

        static bool SaveFile(string path)
        {
            lock (locker)
            {
                var rnd = new Random();
                var text = "";
                for (int i = 0; i < 50000; i++)
                {
                    text += rnd.Next();
                }
            }

            using (var sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.WriteLine();
            }

            return true;
        }

        static async Task DoWorkAsync()
        {
            Console.WriteLine("begin Async");

            await Task.Run(() => DoWork());

            Console.WriteLine("end Async");
        }
        static void DoWork()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("DoWork");
            }
        }
        static void DoWork2(object max)
        {
            int j = 0;

            if (j % 10000 == 0)
            {
                Console.WriteLine("DoWork2");
            }
        }
    }
}
