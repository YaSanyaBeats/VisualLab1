using System;

namespace VisualLab1
{

    public class HW1
    {
        public static long QueueTime(int[] customers, int n)
        {
            //если покупателей меньше чем касс, то лишние кассы нам не нужны
            if(customers.Length < n)
            {
                n = customers.Length;
            }

            int[] threads = new int[n];
            int totalTime = 0;

            //Загоняем первых клиентов по кассам
            for(int j = 0; j < n; j++)
            {
                threads[j] = customers[j];
            }

            int i = n;
            while(i < customers.Length)
            {
                //ищем покупателя, который освободится быстрее остальных
                int min = threads[0];
                for(int j = 1; j < n; j++)
                {
                    if(threads[j] < min)
                    {
                        min = threads[j];
                    }
                }

                //переходим к времени когда освободилась одна касса
                for (int j = 0; j < n; j++)
                {
                    threads[j] -= min;
                }
                totalTime += min;

                //заполняем свободные кассы
                for (int j = 0; j < n; j++)
                {
                    if(threads[j] == 0 && i < customers.Length)
                    {
                        threads[j] = customers[i];
                        i++;
                    }
                }
            }

            //дожидаемся освобождения всех касс
            int max = 0;
            for (int j = 0; j < n; j++)
            {
                if(threads[j] > max)
                {
                    max = threads[j];
                }
            }
            return totalTime + max;
        }
    }


    class Program
    {
       
        static void Main(string[] args)
        {
            int[] a = { 5, 3, 4 };
            Console.WriteLine("Одна касса [5, 3, 4]. Ожидается: 12. Результат: " + HW1.QueueTime(a, 1));
            int[] b = { 10, 2, 3, 3 };
            Console.WriteLine("Две кассы [10, 2, 3, 3]. Ожидается: 10. Результат: " + HW1.QueueTime(b, 2));
            int[] с = { 2, 3, 10 };
            Console.WriteLine("Две кассы [2, 3, 10]. Ожидается: 12. Результат: " + HW1.QueueTime(с, 2));
            int[] d = { 533, 43, 10 };
            Console.WriteLine("Четыре кассы [533, 43, 10]. Ожидается: 533. Результат: " + HW1.QueueTime(d, 4));
            int[] e = { 55 };
            Console.WriteLine("Одна касса [55]. Ожидается: 55. Результат: " + HW1.QueueTime(e, 1));
            int[] f = {};
            Console.WriteLine("Три кассы []. Ожидается: 0. Результат: " + HW1.QueueTime(f, 3));
            int[] g = {5, 5, 5, 2};
            Console.WriteLine("Три кассы [5, 5, 5, 2]. Ожидается: 7. Результат: " + HW1.QueueTime(g, 3));
        }
    }
}
