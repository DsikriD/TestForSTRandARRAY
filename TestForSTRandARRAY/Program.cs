using System.Diagnostics.Metrics;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestForSTRandARRAY
{
    public class Program
    {
        static void Main(string[] args)
        {
            Server.AddToCountAsync(5);
            Console.WriteLine(Server.GetCountAsync());
            Server.AddToCountAsync(7);
            Console.WriteLine(Server.GetCountAsync());
        }

        public static class Server
        {
            private static int count;

            private static async Task<int> GetCount() {
                return count;
            }

            private static async Task<int> AddToCount(int value)
            {
                count = value;
                return value;
            }

            public static int GetCountAsync()
            {
                var task = GetCount();
                return task.Result;
            }

            public static void AddToCountAsync(int value)
            {
                var task =  AddToCount(value);
                task.Wait();
            }


        }




        public static int[,] Matrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int count = n;
            int value = -n;
            int sum = -1;

            do
            {
                value = -1 * value / n;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    Console.Write(matrix[sum % n, sum / n] + " ");
                }
                value *= n;
                count--;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    Console.Write(matrix[sum % n, sum / n] + " ");
                }
            } while (count > 0);

            return matrix;
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