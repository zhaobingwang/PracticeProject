using CodeNodes.Core;
using System;

namespace CodeNodes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentationComments comments = new DocumentationComments();
            Core.Math.Add(1, 2);
            comments.Add(1, 2);
            comments.Add(1.2, 3.4);
        }
    }
}
