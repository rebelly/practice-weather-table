using System;
// закрыть поля
namespace ConsoleApp1
{
    enum month1
    {
        январь = 0,
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
        public month1 month;
        static int[] month_length = new int[]
        {
           31, 28,31,30,31,30,31,31,30,31,30,31
        };
        public int month_n;
        public int day;
        public int[,] temp;
        private int[] maxtemp = { -5, -3, 2, 11, 19, 22, 24, 22, 16, 8, 1, -3 };
        private int[] mintemp = { -10, -10, -5, 2, 8, 12, 14, 12, 7, 2, -3, -7 };
        public int month_l;
        public temp_table()
        {
            Random rnd = new Random();
            this.month_n = rnd.Next(1, 12);
            this.month = (month1)(month_n);
            this.day = rnd.Next(0, 7);
            
            temp = new int[6, 7];
            this.month_l = month_length[this.month_n];
            temp_table.gen_mass(out temp, this.day, this.month_l, this.mintemp, this.maxtemp, this.month_n);

        }
        static void gen_mass(out int[,] temp, int day, int month_l,  int[] mintemp, int[] maxtemp, int month_n)
        {
            Random rnd = new Random();
            temp = new int[6, 7];
            int k = 0;
            bool end = false;
            int tem;
           
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = -1000;
                }
            }
                    for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (k >= month_l)
                    {
                        end = true;
                        break;
                    }
                    if (i == 0)
                    {
                        if (j >= day)
                        {
                            tem = rnd.Next(mintemp[month_n], maxtemp[month_n]);
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
                        tem = rnd.Next(mintemp[month_n], maxtemp[month_n]);
                        temp[i, j] = tem;
                        k++;
                    }


                }
                if (end) break;
            }
        }
        public temp_table(int day, int month)
        {
            this.day = day;
            this.month_l = month_length[(int)this.month];
            temp = new int[6, 7];
            this.month = (month1)(month);
            this.month_n = month;
            temp_table.gen_mass(out temp, this.day, this.month_l, this.mintemp, this.maxtemp, this.month_n);

        }
        public int biggest_jump()
        {
            int res = 0;
            int prev = -1;
            for (int i = 0; i < this.temp.GetLength(0); i++)
            {
                if (prev != -1000 & this.temp[i, 0] != -1000 & Math.Abs(prev - this.temp[i, 0]) > res) res = Math.Abs(prev - this.temp[i, 0]);
                for (int j = 0; j < this.temp.GetLength(1) - 1; j++)
                {
                    if (this.temp[i, j] != -1000 & this.temp[i, j + 1]  != -1000&  Math.Abs(this.temp[i, j] - this.temp[i, j + 1]) > res)
                    {
                        res = Math.Abs(this.temp[i, j] - this.temp[i, j + 1]);
                    }

                }
                prev = this.temp[i, this.temp.GetLength(1) - 1];
            }
            return res;
        }
        public void change_talbe(int day2)
        {
            int tmp;    
            Random rnd = new Random();
            int[] mas = new int[7];
            int day1 = day2 - this.day;
             Console.WriteLine(day);
            Console.WriteLine(day1);
            if (day1 > 0)
            {

                while (day1 > 0)
                {
                    for (int i = 0; i < this.temp.GetLength(0); i++)
                    {
                        tmp = this.temp[i, this.temp.GetLength(1) - 1];
                        mas[i] = tmp;
                        for (int j = this.temp.GetLength(1) - 1; j > 0; j--)
                        {
                            this.temp[i, j] = this.temp[i, j - 1];

                        }
                    {

                    } 
                    }
                    for (int i = 1; i < this.temp.GetLength(0); i++)
                    {
                        this.temp[i - 1, 0] = mas[i];
                    }
                    if ( mas[mas.Length-1] != -1000)
                    this.temp[temp.GetLength(0) - 1, 1] = mas[mas.Length-1];
                    else this.temp[temp.GetLength(0) - 1, 1] = rnd.Next(this.mintemp[this.month_n], this.maxtemp[this.month_n]);
                    day1--;
                } // сдвиг вправо, то есть день меняется в большую сторону
                for (int i = 0; i < day2 - this.day; i++)
                {
                    temp[0, i] = -1000;
                }
            }
            else
            { // тут такая логика, если у нас изначально первый день - среда, но в процессе меняется на четверг, то данные со среды должны кануть в небытье потому что среда становится последним днем
                // предыдушего месяца 
                day1 = -day1;
                while (day1 > 0)
                {
                    for (int i = 0; i < this.temp.GetLength(0); i++)
                    {
                        tmp = this.temp[i, 0];
                        mas[i] = tmp;
                        for (int j = 1; j < this.temp.GetLength(1); j++)
                        {
                            this.temp[i, j-1] = this.temp[i, j ];

                        }

                    }
                    for (int i = this.temp.GetLength(0) ; i > 0; i--)
                    {
                        this.temp[i -  1, this.temp.GetLength(1)-1] = mas[i];
                    }
                    day1--;
                } 
// сдвиг влево, то есть если дата становится меньше
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
                    if (this.temp[i, j] != -1000 & this.temp[i, j + 1] != -1000 & Math.Abs(this.temp[i, j] - this.temp[i, j + 1]) > res)
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
                    if (k >= 31)
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
                    change_talbe(value-1);
                    day = value-1;
                
                }
                else
                {
                    Console.WriteLine("Нет такого дня недели, выбираю день по умолчанию - понедельник");
                }
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
            temp_table table1; 
            Console.WriteLine();
            int day;
            int temp;
            int day_g;
            int month_g;
            bool nailed = false;
            Console.WriteLine("Введите 0 , если хотите ввести номер месяца и первый день месяца вручную и 1, если хотите сделать это автоматически");
            string a = Console.ReadLine();
            if (int.TryParse(a, out int x))
            {
                if (x == 0) {
                    Console.WriteLine("Введите месяц, где январь - 1, декабрь - 12");
                    string month1 = Console.ReadLine();
                    if (!int.TryParse(month1, out month_g))
                    {
                        nailed = true;
                    }
                    else
                    {
                        if (month_g <= 0 | month_g >= 13)
                        {
                            nailed = true;
                        }
                    }
                    Console.WriteLine("Введите первый день, где понедельник - 1, воскресенье - 7");
                    string day1 = Console.ReadLine();
                    if (!int.TryParse(day1, out day_g) )
                    {
                        nailed = true;
                    }
                    else
                    {
                        if (day_g <= 0 | day_g >= 8)
                        {
                            nailed = true;
                        }
                    }
                    if (!nailed)
                        table1 = new temp_table(day_g - 1, month_g - 1);
                    else
                    {
                        Console.WriteLine("Месяц или первый день были заданы неверно, создаю объект по умолчанию");
                        table1 = new temp_table();
                    }
                    
                }
                else table1 = new temp_table();
            }
            else
            {
                Console.WriteLine("Неверно, создаю объект по умолчанию");
                table1 = new temp_table();
            }
            
            string req;
            do
            {
                
               
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Дневник погоды за месяц {table1.month}");
                for (int i = 1; i < 7; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{(days)i }\t");
                }
                Console.Write($"{(days)0 }\t");
                Console.WriteLine();
                table1.print_table();
                Console.WriteLine();
                Console.WriteLine($"Количество дней в дневнике погоды за месяц {table1.month}: {table1.Diary_Days}");
                Console.WriteLine($"Количество дней в дневнике погоды, когда темперпатура была 0 градусов, месяц {table1.month}: {table1.zer_days}");
                Console.WriteLine($"Максимальный перепад температуры составил: {table1.biggest_jump()}");
                Console.WriteLine($"Максимальный перепад температуры составил: {table1.biggest_jump(out day, out temp)}. Это произошло {day} числа, в тот день температура была равна {temp}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Список команд:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Введите 1, если хотите поменять дату первого дня месяца или введите 0, если хотите завершить работу с программой");
                req = Console.ReadLine();
                if (req == "1")
                {
                    Console.WriteLine("Введите номер дня недели, который равен первому дню месяца, где 1 - понедельник, 7 - воскресенье");
                    string tr = Console.ReadLine();
                    if (int.TryParse(tr, out int ok))
                        table1.Day = ok;
                }
            }
            while (req != "0");
        } 
    }
}
