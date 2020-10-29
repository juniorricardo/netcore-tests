using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BasicEssentials;
using static System.Text.RegularExpressions.Regex;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {

            Regex rx = new Regex(@"^\w+$");
            var metrics = GetMetrics();

            var padre = metrics.Where(i => rx.IsMatch(i.Name)).ToList();
            string message = string.Empty;
            padre.ForEach(i =>
            {
                if (!i.State) return;
                message += GetMessage(i.Name, metrics);
            });
            Console.WriteLine(message);
            
            //var client = new ClientHttp();
            // client.GetRestSharp();
            Console.WriteLine(DigitalRoot(942));
            //client.GetSmp();
            Console.WriteLine("Hello World!");
        }
        public static int DigitalRoot(long n)
        {
            // Your awesome code here!
            // var result = 0;
            // while (n != 0)
            // {
            //     var dig = (int) (n % 10);
            //     result += dig;
            //     n -= dig;
            //     n /= 10;
            //     if (n != 0 || result <= 10) continue;
            //     n = result;
            //     result = 0;
            // }
            // return result;
            
            //return (int)(1 + (n - 1) % 9);
            
            // if (n < 10) return (int)n;
            // long r = 0;
            // while (n > 0)
            // {
            //     r += n % 10;
            //     n /= 10;
            // }
            // return DigitalRoot(r);
            return (int) (n < 10 ? n : DigitalRoot(n / 10 + n % 10) );
        }

        public static List<Metric> GetMetrics()
        {
            return new List<Metric>()
            {
                new Metric("benchmark","Lorem ipsum dolor sit amet.",true),
                new Metric("benchmark.Product", "Lorem ipsum dolor sit amet.", true),
                new Metric("benchmark.Product.incubate", "a", false),
                new Metric("benchmark.Product.incubate.MMK", "a", false),
                new Metric("benchmark.Product.incubate.JSA", "a", false),
                new Metric("benchmark.Product.Usability", "Lorem ipsum dolor sit amet.", true),
                new Metric("benchmark.Product.Usability.SDD", "a", false),
                new Metric("benchmark.Product.Usability.TTD", "Lorem ipsum dolor sit amet.", true),
                new Metric("benchmark.Account", "a", false),
                new Metric("benchmark.Account.Pennsylvania", "a", false),
                new Metric("benchmark.Account.Pennsylvania.implement", "a", false),
                new Metric("benchmark.Account.Pennsylvania.implement.BZD", "a", false),
                new Metric("benchmark.Account.Pennsylvania.implement.BDN", "a", false),
                new Metric("benchmark.Account.orchestrate.quantify.RKL", "a", false)
            };
        }

        public static string GetMessage(string metricName,
            List<Metric> metrics)
        {
            string message = string.Empty;
            foreach (var metricItem in metrics)
            {
                if (metricItem.State)
                {
                    message += metricItem.Message;
                    var rex = "(^";
                    rex += Regex.Replace(metricItem.Name,@"\.", @"\.");
                    rex += @")\.(\w+$)";

                    var childList = metrics.Where(i =>
                            Regex.IsMatch(i.Name, rex))
                        .ToList();
                    foreach (var child in childList)
                    {
                        message += GetMessage(child.Name, childList);
                    }
                }
            }
            return message;
        }
        
    }

    public class Metric
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public Boolean State { get; set; }

        public Metric(string name, string message, bool state)
        {
            Name = name;
            Message = message;
            State = state;
        }
    }
}