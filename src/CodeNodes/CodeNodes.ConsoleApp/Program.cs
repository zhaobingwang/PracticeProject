using CodeNodes.Core;
using System;

namespace CodeNodes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentationComments comments = new DocumentationComments();
            //comments.Add(1, 2);
            //comments.Add(1.2, 3.4);
            System.Console.WriteLine(Math.Ceiling((decimal)(3) / 2));
            System.Console.WriteLine(100/9.0);
            System.Console.WriteLine(50);
            System.Console.WriteLine(50F);
        }
    }
}
