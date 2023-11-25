using System.Diagnostics.Metrics;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestForSTRandARRAY
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Метод Main начал работу в потоке{Thread.CurrentThread.ManagedThreadId}");
            await Server.AddToCount(1);
            Server.GetCount();
            await Server.AddToCount(2);
            Server.GetCount();
            Console.WriteLine($"Метод Main закончил работу в потоке{Thread.CurrentThread.ManagedThreadId}");
            Console.ReadLine();
        }

        public static class Server
        {
            private static int count;

            public static async Task GetCount() {

                Console.WriteLine($"Метод GetCount начал работу в потоке {Thread.CurrentThread.ManagedThreadId}");
                await Task.Run(()=>Console.WriteLine(count));// Задача выполняется во вторичном потоке
                Console.WriteLine($"Метод GetCount закончил работу в потоке {Thread.CurrentThread.ManagedThreadId}");
            }

            public static async Task AddToCount(int value)
            {
                Console.WriteLine($"Метод AddToCount начал работу в потоке{Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(10000); // имитация продолжительной работы
                count = value;
                Console.WriteLine($"Метод AddToCount закончил работу в потоке{Thread.CurrentThread.ManagedThreadId}");
              
            }

        }


        public static int[] Matrix(int[,] matrix)// По спирали
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int l = -1;
            int k = 0;
            int[] Resualt = new int[matrix.Length];
            int count = 0;
            int One = 1;

            while (n > 0 && m > 0)
            {

                for (int i = 0; i < n; i++)
                {
                    l = l + One;
                    Resualt[count] = matrix[l, k];
                    count++;
                }
                n--;

                for (int i = 0; i < m - 1; i++)
                {

                    k = k + One;
                    Resualt[count] = matrix[l, k];
                    count++;
                }
                m--;

                One = One * (-1);
            }
            foreach (var a in Resualt)
                Console.Write(a+";");
            Console.WriteLine();


            return Resualt;
        }



        public static string ZipStirng(string str)
        {
            str = str.Trim();

            if (str.Count()==0)
                return str;

            var array = str.ToCharArray();
            StringBuilder stringBuilder = new StringBuilder();

            int Chisler = 1;
            char NowChar = array[0];

            for(int i = 1; i < array.Length; i++)
            {
                if (NowChar != array[i])
                {
                    stringBuilder.Append(NowChar);
                    if(Chisler!=1)
                        stringBuilder.Append(Chisler);
                    NowChar = array[i];
                    Chisler = 1;
                }
                else
                {
                    Chisler++;
                }

            }
            stringBuilder.Append(NowChar);
            if (Chisler != 1)
                stringBuilder.Append(Chisler);

            return stringBuilder.ToString();
        }


        //a3s3d
        public static string DeZipString(string str) {

            str = str.Trim();
            if (str.Count() == 0)
                return str;

            StringBuilder stringBuilder = new StringBuilder();
            var array = str.ToCharArray();
            char NowChar='1';

            for(int i = 0; i < array.Length; i++)
            {
                if (array[i]>50 && array[i]<57)//Если число
                {
                    for (int j=0;j < (array[i] - 48)-1; j++)
                    {
                        stringBuilder.Append(NowChar);
                    }
                }
                else
                {
                    NowChar = array[i];
                    stringBuilder.Append(array[i]);
                }
            }

            return stringBuilder.ToString();
        }

    }

}