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
            // CulturaDeData();
            // TimeZones();
            TimeSpans();
            QuantidadeDeDiasDoMes();

            Console.WriteLine($"\nEh final de semana: {FinalDeSemana(DateTime.Now.DayOfWeek)}");            
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
            DateTime data = DateTime.Now;

            Console.WriteLine("Apresentação de datas: (CultureInfo):");
            CultureInfo ptBr = new CultureInfo("pt-BR");
            CultureInfo ptPt = new CultureInfo("pt-PT");
            CultureInfo enUs = new CultureInfo("en-US");
            CultureInfo enCa = new CultureInfo("en-CA");
            CultureInfo deDe = new CultureInfo("de-DE");
            CultureInfo atual = CultureInfo.CurrentCulture;

            Console.WriteLine($"Português Brasil: {data.ToString(ptBr)}");
            Console.WriteLine($"Português Potugual: {data.ToString(ptPt)}");
            Console.WriteLine($"Inglês Esdos Unidos: {data.ToString(enUs)}");
            Console.WriteLine($"Inglês Canada: {data.ToString(enUs)}");
            Console.WriteLine($"Inglês Dinamarca: {string.Format("{0:G}", data.ToString(deDe))}");
        }

        public static void TimeZones()
        {
            DateTime utcDate = DateTime.UtcNow;

            Console.WriteLine($"Datado Servidor: {DateTime.Now}");
            Console.WriteLine($"Hora universal: {utcDate}");
            Console.WriteLine($"Data local: {utcDate.ToLocalTime()}");

            Console.WriteLine("\nTimezones:");
            TimeZoneInfo timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
            Console.WriteLine(timezoneAustralia);

            DateTime horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezoneAustralia);
            Console.WriteLine($"Australia: {horaAustralia}");

            Console.WriteLine("\nListando Timezones");
            var timezones = TimeZoneInfo.GetSystemTimeZones();
            foreach (var timezone in timezones)
            {
                Console.WriteLine($@"{timezone.Id}
                 {timezone}
                 {TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezone)}");
                Console.WriteLine("----");
            }

        }

        public static void TimeSpans()
        {
            TimeSpan timeSpan = new TimeSpan();
            Console.WriteLine(timeSpan); // assim ele sempra mostrará 00:00:00

            TimeSpan timeSpan1 =  new TimeSpan(1); // Nano segundos
            Console.WriteLine($"Nano segundos: {timeSpan1}");

            TimeSpan timeSpanHoraMinutoSegundo = new TimeSpan(5, 12, 8);
            Console.WriteLine($"Hora Minuto Segundo: {timeSpanHoraMinutoSegundo}");

            TimeSpan timeSpanDiaHoraMinutoSegundo = new TimeSpan(3, 5, 50, 10);
            Console.WriteLine($"Dia Hora Minuto Segundo: {timeSpanDiaHoraMinutoSegundo}");

            TimeSpan timeSpanDiaHoraMinutoSegundoMilisegundo = new TimeSpan(15, 12, 55, 8, 100);
            Console.WriteLine($"Dia Hora Minuto Segundo Milisegundo: {timeSpanDiaHoraMinutoSegundoMilisegundo}");

            Console.WriteLine("");
            Console.WriteLine($"Hms - Dhms: {timeSpanHoraMinutoSegundo - timeSpanDiaHoraMinutoSegundo}");
            Console.WriteLine($"Dias: {timeSpanDiaHoraMinutoSegundo.Days}");
            Console.WriteLine($"Adicionando horas: {timeSpanDiaHoraMinutoSegundo.Add(new TimeSpan(12, 0, 0))}");


        }

        public static void QuantidadeDeDiasDoMes()
        {
            Console.WriteLine("\nVer a quantidade de dias que um mes tem:");
            Console.WriteLine($"08/2022 tem {DateTime.DaysInMonth(2022, 8)} dias");
        }
        
        public static bool FinalDeSemana(DayOfWeek today)
        {
            return today == DayOfWeek.Saturday || today == DayOfWeek.Sunday;
        }

    }
}