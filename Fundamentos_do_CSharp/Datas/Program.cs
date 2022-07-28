using System;
using System.Globalization;

namespace Datas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            // StartDate();
            DateFormat();
            
        }

        public static void StartDate()
        {
            DateTime date = new DateTime(2022, 1, 26, 10, 20, 21);

            Console.WriteLine($"Date: {date}");
            Console.WriteLine($"Year: {date.Year}");
            Console.WriteLine($"Month: {date.Month}");
            Console.WriteLine($"Days: {date.Day}");
            Console.WriteLine($"Hours: {date.Hour}");
            Console.WriteLine($"Minutes: {date.Minute}");
            Console.WriteLine($"Seconds: {date.Second}");
            Console.WriteLine();

            date = DateTime.Now;
            Console.WriteLine(date.ToString(CultureInfo.CreateSpecificCulture("en-Us")));
        }

        public static void DateFormat()
        {
            DateTime now = DateTime.Now;

            string mesestenco = String.Format("{0:Y}", now);
            string ano = String.Format("{0:yyyy}", now);
            string diaEMes = String.Format("{0:M}", now);

            Console.WriteLine(mesestenco);
            Console.WriteLine(ano);
            Console.WriteLine(diaEMes);
        }
    }
}