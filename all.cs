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
        static int[] month_length = new int[]
        {
           31, 28,31,30,31,30,31,30,31,30,31
        };
        public int day;
        public int[,] temp;
        private int[] maxtemp = { -5, -3, 2, 11, 19, 22, 24, 22, 16, 8, 1, -3 };
        private int[] mintemp = { -10, -10, -5, 2, 8, 12, 14, 12, 7, 2, -3, -7 };
        public int month_l;
        public temp_table()
        {
            Random rnd = new Random();
            this.month = (month1)rnd.Next(1, 11);
            this.day = rnd.Next(0, 7);
            int tem;
            temp = new int[5, 7];
            this.month_l = month_length[(int)this.month];
            int k = 0;
            bool end = false;
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (k >= this.month_l) { 
                        end = true;
                        break;
                    }
                    if (i == 0)
                    {
                        if (j >= day)
                        {
                            tem = rnd.Next(mintemp[i], maxtemp[i]);
                            temp[i, j] = tem;
                            k++;
                        }
                        else
                        {
                            temp[i, j] = temp_table.NoData;
                        }
                    }
                    else
                    {
                        tem = rnd.Next(mintemp[i], maxtemp[i]);
                        temp[i, j] = tem;
                        k++;
                    }
                    
                    
                }
                if (end) break;
            }
        }
        public temp_table(int day, int month)
        {
            Random rnd = new Random();
            this.day = day;
            this.month_l = month_length[(int)this.month];
            int k = 0;
            bool end = false;
            temp = new int[5, 7];
            this.month = (month1)month;
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (k >= this.month_l)
                    {
                        end = true;
                        break;
                    }
                    if (i == 0)
                    {
                        if (j > day) { temp[i, j] = rnd.Next(mintemp[i], maxtemp[i]); k++; }
                        else { temp[i, j] = temp_table.NoData; }
                    }
                    else
                    {
                        temp[i, j] = rnd.Next(mintemp[i], maxtemp[i]);
                            k++;
                        }
                }
            }
        }
        public int biggest_jump()
        {
            int res = 0;
            int prev=  -1;
            for (int i = 0; i < this.temp.GetLength(0); i++)
            {
                if (prev != -1000 & this.temp[i, 0]  != -1000 &  Math.Abs(prev - this.temp[i, 0]) > res) res = Math.Abs(prev - this.temp[i, 0]);
                for (int j = 0; j < this.temp.GetLength(1) - 1; j++)
                {
                    if (this.temp[i, j] != -1000 & Math.Abs(this.temp[i, j] - this.temp[i, j + 1]) > res) {
                        res = Math.Abs(this.temp[i, j] - this.temp[i, j + 1]);
                }
                    
                }
                prev = this.temp[i, this.temp.GetLength(1)-1];
            }
            return res;
        }
        public void change_talbe()
        {
            int day1 = this.day;
            int tmp;
            int [,] p = { { 1,2,3,4,5}, { 5,6,7,8,9 }, { 10,11,12,13,14} };
            if (this.day > 0)
            while (this.day != 0)
            {
                for (int i = 0; i < this.temp.GetLength(0); i++)
                {

                    if (i != 0)
                    {
                        tmp = this.temp[i, this.temp.GetLength(1) - 1];
                        for (int j = this.temp.GetLength(1) - 1; j != 0; j--) { 
                            this.temp[i, j] = this.temp[i, j - 1];
                            this.temp[i, 0] = tmp;
                        }
                    }
                    else
                    {

                        for (int j = this.temp.GetLength(1) - 1; j != 0; --j)
                        {
                            this.temp[i, j] = this.temp[i, j - 1];
                            this.temp[0, 0] = temp_table.NoData;
                        }
                    }





                }
                this.day--; // сдвиг вправо, то есть день меняется в большую сторону 

            }


        }

        public int biggest_jump(out int day, out int temp)
        {
            int res = 0;
            int prev = -1;
            day = 1;
            temp = 0;
            int k = -1;
            for (int i = 0; i < this.temp.GetLength(0); i++)
            {
                if (prev != -1000) k++;
                if (prev != -1000 & this.temp[i, 0] != -1000 & Math.Abs(prev - this.temp[i, 0]) > res) { 
                    res = Math.Abs(prev - this.temp[i, 0]);
                    day = k;
                    temp = prev;
                }
                for (int j = 0; j < this.temp.GetLength(1) - 1; j++)
                {
                    if (this.temp[i, j] != -1000) k++;
                    if (this.temp[i, j] != -1000 & Math.Abs(this.temp[i, j] - this.temp[i, j + 1]) > res)
                    {
                        res = Math.Abs(this.temp[i, j] - this.temp[i, j + 1]);
                        day = k;
                        temp = this.temp[i, j];
                    }

                }
                prev = this.temp[i, this.temp.GetLength(1) - 1];
            }
            return res;
        }
        public void print_table()
        {
            bool end = false;
            int k = 0;
            for (int i = 0; i<(this.temp).GetLength(0); i++)
            {

                for (int j = 0; j<(this.temp).GetLength(1); j++)

                {
                    if (k >= this.month_l)
                    {
                        end = true;
                        break;
                    }
                    if (this.temp[i, j] != -1000)
                    {
                        k++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{k} ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"{this.temp[i, j]}\t");
                    }
                    else Console.Write($"\t");
                }
                Console.WriteLine();
                if (end) break;
            }
        }
        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                if (value > 0 & value <= 7) { 
                    day = value;
                
                }
                else
                {
                    Console.WriteLine("Нет такого дня недели, выбираю день по умолчанию - понедельник");
                }
            }
        }
        public int Temp1
        {
            set
            {
                
            }
        }
        public int Month
        {
            get
            {
                return (int)this.month;
            }
           
        }
       
        public int[,] Temp
        {
            get
            {
                return this.temp;
            }
        }
        public int Diary_Days
        {
            get
            {
                int res = 0;
                for (int i = 0; i < this.temp.GetLength(0) ; i++)
                {
                    for (int j = 0; j < this.temp.GetLength(1) ; j++)
                    {
                        if (this.temp[i, j] != -1000) res++;
                    }
                }
                return res;
            }
        }
        public int zer_days
        {
            get
            {
                int res = 0;
                for (int i = 0; i < this.temp.GetLength(0); i++)
                {
                    for (int j = 0; j < this.temp.GetLength(1); j++)
                    {
                        if (this.temp[i, j] == 0) res++;
                    }
                }
                return res;
            }
        }
        static int NoData
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
            temp_table table1 = new temp_table();
            for (int i = 1; i < 7; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{(days)i }\t");
            }
            Console.Write($"{(days)0 }\t");
            int k = 0;
            bool end = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            table1.print_table();
            int day;
            int temp;
            Console.WriteLine($"Максимальный перепад температуры составил {table1.biggest_jump(out day, out temp)} это произошло {day} числа, в тот день температура была равна {temp}");
            int tem;
            int last;
            table1.Day = int.Parse(Console.ReadLine());
            table1.change_talbe();
            

            table1.print_table();
        } // (days)(((table1.temp.GetLength(1) * i + j)+1)%7)}
    }
}
//                    if (i != 0)
//table1.temp[i + 1, 0] = last;
