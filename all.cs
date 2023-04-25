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
        public int[,] temp = new int[5, 7];
        private int[] maxtemp = { -5, -3, 2, 11, 19, 22, 24, 22, 16, 8, 1, -3 };
        private int[] mintemp = { -10, -10, -5, 2, 8, 12, 14, 12, 7, 2, -3, -7 };
        private int[] temps = new int[35];
        public temp_table()
        {
            Random rnd = new Random();
            this.month = (month1)rnd.Next(1, 13);
            this.day = rnd.Next(0, 7);
            int k = 0;
            int tem;
            bool end = false;
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        if (j >= day)
                        {
                            tem = rnd.Next(mintemp[i], maxtemp[i]);
                            temp[i, j] = tem;
                            temps[k] = tem;
                        }
                        else { 
                            temp[i, j] = -150000000;
                            temps[k] = -150000000;
                        }
                    }
                    else
                    {
                        tem = rnd.Next(mintemp[i], maxtemp[i]);
                        temp[i, j] = tem;
                        temps[k] = tem;
                    }
                    k++;
                }
            }
        }
        public temp_table(int day, int month)
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
            public int biggest_jump()
        {
            int res = 0;
            for (int i = 0; i < this.temps.Length-1; i++)
            {

                if (this.temps[i] != -150000000 & Math.Abs(this.temps[i] - this.temps[i + 1]) > res)
                {
                    res = Math.Abs(this.temps[i] - this.temps[i + 1]);
                }


            }
            return res;
        }
        //public void change_talbe(int day)
        //{
        //    int tem;
        //    for (int i = 0; i < temp.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < temp.GetLength(1); j++)
        //        {
        //            if (i == 0)
        //            {
        //                if (j >= day)
        //                {
        //                    tem = rnd.Next(mintemp[i], maxtemp[i]);
        //                    temp[i, j] = tem;
        //                }
        //                else
        //                {
        //                    temp[i, j] = -150000000;
        //                }
        //            }
        //            else
        //            {
        //                tem = rnd.Next(mintemp[i], maxtemp[i]);
        //                temp[i, j] = tem;
        //            }
        //        }
        //    }
        //}
        public int biggest_jump(out int day, out int temp)
        {
            int res = 0;
            temp = 0;
            day = 1;
            for (int i = 0; i < this.temps.Length - 1; i++)
            {

                if (this.temps[i] != -150000000 & Math.Abs(this.temps[i] - this.temps[i + 1]) > res)
                {
                    res = Math.Abs(this.temps[i] - this.temps[i + 1]);
                    temp = temps[i];
                    day = i;
                }


            }
            return res;
        }
       
        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                if (value > 0 & value <= 7) day = value;
                else
                {
                    Console.WriteLine("Нет такого дня недели, выбираю день по умолчанию - понедельник");
                }
            }
        }
        public int Diary_Days
        {
            get
            {
                return temps.Length;
            }
        }
        public int NoData
        {
            get
            {
                return -1000;
            }
        }

        

    }
    class Program
    {
        static void Main(string[] args)
        {
            temp_table table1 =new temp_table();
            for (int i = 1; i < 7; i++) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{(days)i }\t");
            }
            Console.Write($"{(days)0 }\t");
            int k = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = 0; i < (table1.temp).GetLength(0); i++)
            {
                
                for (int j = 0; j < (table1.temp).GetLength(1); j++)

                {
                    if (table1.temp[i, j] != -150000000)
                    {
                        k++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{k} ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"{table1.temp[i, j]}\t");
                    }
                    else Console.Write($"\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"{table1.biggest_jump()}");
            int day;
            int temp; 
            Console.WriteLine($"Максимальный перепад температуры составил {table1.biggest_jump(out day, out temp)} это произошло {day} числа, в тот день температура была равна {temp}");
        } // (days)(((table1.temp.GetLength(1) * i + j)+1)%7)}
    }
}
