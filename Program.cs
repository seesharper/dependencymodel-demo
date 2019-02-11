using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyModel;
namespace DependencyModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var fileStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..","..", "..", "obj", "project.assets.json"), FileMode.Open))
            {
                using (var dependencyReader = new DependencyContextJsonReader())
                {
                    var context = dependencyReader.Read(fileStream);
                    foreach(var rl in context.RuntimeLibraries)
                    {
                        Console.WriteLine(rl.Name);
                    }
                }
            }
        }
    }
}
