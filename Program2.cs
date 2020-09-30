using System;

namespace ConsoleApp2
{

    class Converter
    {
        private double uah_per_usd;
        private double uah_per_euro;
        private double usd_per_uah;
        private double euro_per_uah;

        public Converter(double usd, double euro)
        {
            uah_per_usd = usd;
            uah_per_euro = euro;
            usd_per_uah = 1 / uah_per_usd;
            euro_per_uah = 1 / uah_per_euro;
        }

        public Converter(double val, string type)
        {
            if(type == "usd")
            {
                uah_per_usd = val;
                usd_per_uah = 1 / val;
            }
            else
            {
                uah_per_euro = val;
                euro_per_uah = 1 / val;
            }
        }


        public double usd_to_uah(double usd)
        {
            return usd * uah_per_usd;
        }

        public double euro_to_uah(double euro)
        {
            return euro * uah_per_euro;
        }

        public double uah_to_usd(double uah)
        {
            return uah * usd_per_uah;
        }

        public double uah_to_euro(double uah)
        {
            return uah * euro_per_uah;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            while (true)
            {
                Console.Write("Натиснiть одну з зазначених клавiш\n1 - Конвертувати гривнi в долари\n" +
                    "2 - Конвертувати гривнi в євро\n3 - Конвертувати долари в гривнi\n" +
                    "4 - Конвертувати євро в гривнi\nq - Вихiд\n");
                switch(Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Введiть курс долара");
                        double usd_uah = double.Parse(Console.ReadLine());
                        Converter c1 = new Converter(usd_uah, "usd");
                        Console.WriteLine("Введiть суму:");
                        double value1 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Результат: {0} usd", c1.uah_to_usd(value1));
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Введiть курс євро");
                        double euro_uah = double.Parse(Console.ReadLine());
                        Converter c2 = new Converter(euro_uah, "euro");
                        Console.WriteLine("Введiть суму:");
                        double value2 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Результат: {0} euro", c2.uah_to_euro(value2));
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Введiть курс долара");
                        double uah_usd = double.Parse(Console.ReadLine());
                        Converter c3 = new Converter(uah_usd, "usd");
                        Console.WriteLine("Введiть суму:");
                        double value3 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Результат: {0} uah", c3.usd_to_uah(value3));
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Введiть курс євро");
                        double uah_euro = double.Parse(Console.ReadLine());
                        Converter c4 = new Converter(uah_euro, "euro");
                        Console.WriteLine("Введiть суму:");
                        double value4 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Результат: {0} uah", c4.euro_to_uah(value4));
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
