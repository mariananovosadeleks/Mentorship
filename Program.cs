using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Mentorship
{
    class Program
    {
        static void Main(string[] args)
        {

            Call(args);
            //only for testing
            var fakeArg = @"-help -s C:\Users\mariana.novosad\source\repos\Mentorship\source -d C:\Users\mariana.novosad\source\repos\Mentorship\destination -f test.txt";

            var fakeParameters = fakeArg.Split("-").Where(x => !String.IsNullOrWhiteSpace(x)).ToDictionary((x => x.Split(" ")[0]), GetValue);
            //true data
            var parameters = string.Join(" ", args).Split("-").Where(x => !String.IsNullOrWhiteSpace(x)).ToDictionary((x => x.Split(" ")[0]), GetValue);

            Console.WriteLine("PARAMETERS:" + fakeParameters);
        }

        public static string GetValue(string param)
        {
            var array = param.Split(" ");
            var value = array.Length > 1 ? array[1] : string.Empty;

            return value;
        }

        private static readonly Dictionary<string, Action<string[]>> commandMap = new Dictionary<string, Action<string[]>>(StringComparer.InvariantCultureIgnoreCase)
        {
            //[nameof(Help)] = Help,
            [nameof(Key)] = Key,
            [nameof(Decrypt)] = Decrypt,
            [nameof(SkipFormat)] = SkipFormat,
            [nameof(Version)] = Version,
            [nameof(Move)] = Move

        };//шоб шо




         static void Help()
         {
            var files = File.ReadAllText(@"C:\Users\mariana.novosad\source\repos\Mentorship\help.txt");
            Console.WriteLine(files);
        }


        static void Move(string[] args)
        {
            string source = args[1];
            string destination = args[3];
            string file = args[5];

            string sourceFile = System.IO.Path.Combine(source, file);
            string destFile = System.IO.Path.Combine(destination, file);

            System.IO.File.Move(sourceFile, destFile);
            return;
        }

        static void Call(string[] args)
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

        static void Key(string[] args)
        {

        }

        static void Decrypt(string[] args)
        {

        }

        static void SkipFormat(string[] args)
        {

        }

        static void Version(string[] args)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Console.WriteLine("version: " + version);
            return;
        }
    }
}
