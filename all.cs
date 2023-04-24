using System;

namespace ConsoleApp1
{ 
    enum month1
    {
        январь = 1,
        февраль,
        март,
        апрель,
        май,
        июнь,
        июль,
        август,
        сентябрь,
        октябрь,
        ноябрь,
        декабрь
    }
    enum days
    {
        вс = 0, 
        пн = 1,
        вт,
        ср,
        чт,
        пт, 
        сб, 
       
    }
    class temp_table
    {
        static string[] days = new string[] { "понедельник", "вторник", "среда", "четверг", "пятница", "суббота", "воскресенье" };
        public month1 month;
        public int day;
        public int[,] temp = new int[7, 5];
    private int[] maxtemp = { -5, -3, 2, 11, 19, 22, 24, 22, 16, 8, 1, -3 };
    private int[] mintemp = { -10, -10, -5, 2, 8, 12, 14, 12, 7, 2, -3, -7 };
        public temp_table()
        {
            Random rnd = new Random();
            this.month = (month1)rnd.Next(1, 13);
            this.day = rnd.Next(0, 7);
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        if (j >= day) { temp[i, j] = rnd.Next(mintemp[i], maxtemp[i]); }
                        else { temp[i, j] = -150000000; }
                    }
                    else
                    {
                        temp[i, j] = rnd.Next(mintemp[i], maxtemp[i]);
                    }
                }
            }
        }
        public temp_table(int day , int month)
            {
            Random rnd = new Random();
            this.day = day;
            this.month = (month1)month;
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        if (j > day) temp[i, j] = rnd.Next(mintemp[i], maxtemp[i]);
                    }
                    else
                    {
                        temp[i, j] = rnd.Next(mintemp[i], maxtemp[i]);
                    }
                }
            }
        }

        

    }
    class Program
    {
        static void Main(string[] args)
        {
            temp_table table1 =new temp_table();
            for (int i = 0; i < 7; i++) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{(days)i }\t");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = 0; i < (table1.temp).GetLength(0); i++)
            {
                
                for (int j = 0; j < (table1.temp).GetLength(1); j++)

                { 
                    if (table1.temp[i, j] != -150000000) 
                        Console.Write($"{(((table1.temp.GetLength(1) * i + j) + 1))} {table1.temp[i, j]}\t");
                    else Console.Write($"\t\t");
                }
                Console.WriteLine();
            }

        } // (days)(((table1.temp.GetLength(1) * i + j)+1)%7)}
    }
}
