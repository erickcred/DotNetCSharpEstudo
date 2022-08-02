using System;
using System.Linq;
using System.Collections.Generic;
using MaoNaMassa.ContentContext;
using MaoNaMassa.ContentContext.Enums;
using MaoNaMassa.SubscriptionContext;

namespace MaoNaMassa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            List<Article> articles = new List<Article>();
            articles.Add(new Article("Artigo sobre OOP", "funcionamento-da-oop"));
            articles.Add(new Article("Artigo sobre CSahrp", "csharp"));
            articles.Add(new Article("Artigo .NET", "dotnet"));

            // foreach (Article article in articles)
            // {
            //     Console.WriteLine(article.Id);
            //     Console.WriteLine(article.Title);
            //     Console.WriteLine(article.Url);
            //     Console.WriteLine("-----------------------");
            // }

            List<Course> courses = new List<Course>();
            Course courseOOP = new Course("Fundamentos OOP", "fundamentos-oop", EContentLevel.Beginner);
            Course courseCSharp = new Course("Fundamento C#", "fundamentos-csahrp", EContentLevel.Intermediary);
            Course courseAspNet = new Course("Fundamentos ASP.NET", "fundamentos-aspnet", EContentLevel.Beginner);
            courses.Add(courseOOP);
            courses.Add(courseCSharp);
            courses.Add(courseAspNet);


            List<Career> careers = new List<Career>();
            Career careerDotNet = new Career("Especialista .NET", "especiasta-dotnet");

            CareerItem careerItem = new CareerItem(1, "Começe por aqui", "", courseOOP);
            CareerItem careerItem1 = new CareerItem(2, "Especialista .NET", "", courseCSharp);
            CareerItem careerItem2 = new CareerItem(3, "Aprenda .NET", "", null);

            careerDotNet.CareerItems.Add(careerItem1);
            careerDotNet.CareerItems.Add(careerItem);
            careerDotNet.CareerItems.Add(careerItem2);
            careers.Add(careerDotNet);

            foreach (var career in careers)
            {
                Console.WriteLine($"Career {career.Title} - {career.Url}");

                foreach (var item in career.CareerItems.OrderBy(x => x.Order))
                {
                    Console.WriteLine($"{item.Order} - {item.Title}");
                    Console.WriteLine($"{item.Course?.Title} - {item.Course?.Level}");
                    foreach (var notification in item.Notifications)
                    {
                        Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }
                    Console.WriteLine("-----------");
                }
            }

            PayPalSubscription payPalSubscription = new PayPalSubscription();
            Student student = new Student();
            student.CreateSubscription(payPalSubscription);
            Console.WriteLine(student.IsPremium);
        }
    }
}