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
            // DateFormat();
            // AdicionandoValores();
            // ComparandoData();
            CulturaDeData();
            
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

            Console.WriteLine($"Mostrando mês extenço e ano: {mesestenco}");
            Console.WriteLine($"Mostrando ano: {ano}");
            Console.WriteLine($"Mostrando dia e mês extenço: {diaEMes}");
            Console.WriteLine("Mostrando dia mês ano: " + String.Format("{0:dd/MM/yyyy}", now));
        }

        public static void AdicionandoValores()
        {
            DateTime data = DateTime.Now;
            Console.WriteLine($"Data horiginal: {data}");

            Console.WriteLine($"Adicionando uma Hora: {data.AddHours(1)}");
            Console.WriteLine($"Adicionando dois dias: {data.AddDays(2)}");
            Console.WriteLine($"Adicionando um mês: {data.AddMonths(1)}");
        }

        public static void ComparandoData()
        {
            DateTime data = DateTime.Now;

            if (data.Date == DateTime.Now.Date)
                Console.WriteLine("Eh");
            else
                Console.WriteLine("Não eh");

            if (data.Date < Convert.ToDateTime("10/10/2022"))
                Console.WriteLine($"{data} eh menor que 10/10/2022");
        }

        public static void CulturaDeData()
        {

        }

    }
}