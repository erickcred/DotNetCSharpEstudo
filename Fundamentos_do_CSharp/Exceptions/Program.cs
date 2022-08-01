using System;

namespace Exceptions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            
            // Exceptions1();
            // TratandoErros();
            DiparandoExecoes();
        }

        public static void Exceptions1()
        {
            int[] arr = new int[3];

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            } catch (IndexOutOfRangeException error)
            {
                Console.WriteLine("Indice não existente");
                Console.WriteLine(error.Message);
                Console.WriteLine(error.StackTrace);
            }
        }

        public static void TratandoErros()
        {
            int[] arr = new int[3];

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            } catch (IndexOutOfRangeException error)
            {
                Console.WriteLine("Indice não encontrado");
                Console.WriteLine(error.Message);
                Console.WriteLine(error.StackTrace);
            } catch (Exception error)
            {
                Console.WriteLine("Ops! Algo deu errado. (genérico)");
                Console.WriteLine(error.Message);
                Console.WriteLine(error.StackTrace);
            }
        }

        public static void DiparandoExecoes()
        {
            try
            {
                Cadastrar("");
            } catch (MinhaException error)
            {
                Console.WriteLine(error.QuandoAconteceu);
                Console.WriteLine("Ops não deu boa exceção customizada");
            } catch (ArgumentNullException error)
            {
                Console.WriteLine(error.Message);
                Console.WriteLine("Flalha ao cadastrar o texto");                
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        public static void Cadastrar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                throw new MinhaException(DateTime.Now);
            } else
            {
                Console.WriteLine("Salvando arquivo!");
            }
        }

        public class MinhaException : Exception
        {
            public DateTime QuandoAconteceu { get; set; }

            public MinhaException(DateTime date)
            {
                QuandoAconteceu = date;
            }
        }


    }
}