using System;
using System.IO;
using System.Net;

namespace SharpLock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sharplock";
            Console.WriteLine("SharpLock");
            Console.WriteLine("");
            Console.Write("Username: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.Write("List: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string list = Console.ReadLine();
            Console.WriteLine("");

            foreach (string site in File.ReadLines(list))
            {
                //https://stackoverflow.com/questions/5378429/check-if-a-url-is-reachable-help-in-optimizing-a-class
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(site + name);
                request.Timeout = 15000;
                request.Method = "HEAD";
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Site [" + site + name + "] Successful");
                    }
                }
                catch (WebException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Site [" + site + "] Unsuccessful");
                }
            }
            Console.ReadKey();
        }
    }
}
