using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Mentorship.Models;
using Mentorship.Models.Enums;

namespace Mentorship
{
    class Program
    {
        private List<Parameter> _parametersList = new List<Parameter>()
        {
           new Parameter(Keys.Help, "-h", "--help"),
           new Parameter(Keys.IpDomainPort),
           new Parameter(Keys.FileName, "-f", "--file"),
           new Parameter(Keys.Output, "-o", "--output"),
           new Parameter(Keys.Password,"-p", "--password"),
           new Parameter(Keys.User, "-u", "--user")  
        };

        static void Main(string[] args)
        {
            Call(args);
            //only for testing
            var fakeArg = @"-help -s C:\Users\mariana.novosad\source\repos\Mentorship\source -d C:\Users\mariana.novosad\source\repos\Mentorship\destination -f test.txt";
            var fakeParameters = fakeArg.Split("-")
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .ToDictionary((x => x.Split(" ")[0]), GetValue);
            //true data
            var parameters = string.Join(" ", args)
                .Split("-")
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .ToDictionary((x => x.Split(" ")[0]), GetValue);

            Console.WriteLine("PARAMETERS:" + fakeParameters);
        }

        private static string GetValue(string param)
        {
            var array = param.Split(" ");
            var value = array.Length > 1 ? array[1] : string.Empty;
            return value;
        }

         private static void Help()
         {
            var files = File.ReadAllText(@"C:\Users\mariana.novosad\source\repos\Mentorship\help.txt");
            Console.WriteLine(files);
         }

        private static void Move(string[] args)
        {
            string source = args[1];
            string destination = args[3];
            string file = args[5];

            string sourceFile = System.IO.Path.Combine(source, file);
            string destFile = System.IO.Path.Combine(destination, file);

            System.IO.File.Move(sourceFile, destFile);
            return;
        }

        private static void Call(string[] args)
        {
            if (args.Length > 0 && args[0] == "-s" && args[2] == "-d" && args[4] == "-f")
            {
                Move(args);
            }
            else if (args.Length == 0 || args[0] == "-h")
            {
                Help();
            }
            else if (args.Length == 0 || args[0] == "-v")
            {
                Version(args);
            }
            else 
            {
                Console.WriteLine("shit");
            }
        }

        private static void Version(string[] args)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Console.WriteLine("version: " + version);
            return;
        }
    }
}
