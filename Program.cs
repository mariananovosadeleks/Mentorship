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
        private static List<Parameter> _parametersList = new List<Parameter>()
        {
           new Parameter(Keys.Help, "h", "help"),
           new Parameter(Keys.IpDomainPort),
           new Parameter(Keys.FileName, "f", "file"),
           new Parameter(Keys.Output, "o", "output"),
           new Parameter(Keys.Password,"p", "password"),
           new Parameter(Keys.User, "u", "user"),
           new Parameter(Keys.Version, "v", "version")
        };

        static void Main(string[] args)
        {
            //Call(args);
            //only for testing
            //var fakeArg = @"-help -s C:\Users\mariana.novosad\source\repos\Mentorship\source -d C:\Users\mariana.novosad\source\repos\Mentorship\destination -f test.txt";
            var fakeArg = @"--help -p C:\Users\mariana.novosad\source\repos\Mentorship\source -o C:\Users\mariana.novosad\source\repos\Mentorship\destination -u test.txt";

            var fakeParameters = fakeArg.Split("-")
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .ToDictionary((x => x.Split(" ")[0]), GetValue);
            //true data
            var parameters = string.Join(" ", args)
                .Split("-")
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .ToDictionary((x => x.Split(" ")[0]), GetValue);
            if (!IsValid(fakeParameters))
            {
                Help();
                return;
            }

            foreach (var p in fakeParameters)
            {
                var parameter = _parametersList
                    .FirstOrDefault(x => x.FullName == p.Key || x.ShortName == p.Key);
                Execute(parameter.Type, p.Value);
                if (parameter.Type == Keys.Help)
                {
                    return;
                }
            }
        }

        private static void Execute(Keys key, string parameter)
        {
            switch (key)
            {
                case Keys.Help:
                    Help();
                    break;
                case Keys.Password:
                    Console.WriteLine("password");
                    break;
                case Keys.Version:
                    Version();
                    break;                
            }
        }

        private static string GetValue(string param)
        {
            var array = param.Split(" ");
            var value = array.Length > 1 ? array[1] : string.Empty;
            return value;
        }

        private static bool IsValid(Dictionary<string, string> parameters)
        {

            if (parameters == null)
            {
                return false;
            }
            return parameters.Keys
               .All(i => _parametersList
                       .Any(y => y.FullName == i || y.ShortName == i));
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

        private static void Version()
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Console.WriteLine("version: " + version);
            return;
        }
    }
}

