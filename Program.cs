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

            //Get parameters string
            var arg = @"-help -s C:\Users\mariana.novosad\source\repos\Mentorship\source -d C:\Users\mariana.novosad\source\repos\Mentorship\destination -f test.txt";
            //string[] parameters = String.Join(" ", args).Split("-");

            //Func<string, string> someFunctionDelegate = parameter => parameter + "1";
            var parameters = arg.Split("-");
            var param1 = parameters.Where(HasValue).Select(Method);

            var param = param1.ToDictionary(GetKey, GetValue);



            //someFunctionDelegate.Invoke("text");
            

            Console.WriteLine("PARAMETERS:" + parameters);
        }

        public static bool HasValue(string keyValueStr)
        {
           

            return !String.IsNullOrWhiteSpace(keyValueStr);
        }

        public static string GetKey(KeyValuePair<string,string> pair)
        {
            return pair.Key;
        }

        public static string GetValue(KeyValuePair<string, string> pair)
        {
            return pair.Value;
        }

        public static KeyValuePair<string, string> Method(string parameter)
        {
            var value = string.Empty;
            var arr = parameter.Split(" ");
            var key = arr[0];
            if(arr.Length > 1)
            {
                value = arr[1];
            }

            var keyValue = new KeyValuePair<string, string>(key, value);

            return keyValue;
        }

        private static readonly Dictionary<string, Action<string[]>> commandMap = new Dictionary<string, Action<string[]>>(StringComparer.InvariantCultureIgnoreCase)
        {
            [nameof(Help)] = Help,
            [nameof(Key)] = Key,
            [nameof(Decrypt)] = Decrypt,
            [nameof(SkipFormat)] = SkipFormat,
            [nameof(Version)] = Version,
            [nameof(Move)] = Move

        };//шоб шо



        public void  Parse (string[] args)
        {
            Dictionary<string, string> parsedParameters = new Dictionary<string, string>();
            //string flag = "-";

            //for(int i = 0; i < args.Length; i++)
            //{
            //    if (args[i] == null) continue;

            //    string key = "";
            //    string value = "";


            //}




        }


         static void Help(string[] args)
         {
            var files = File.ReadLines(@"C:\Users\mariana.novosad\source\repos\Mentorship\help.txt");
            foreach(var f in files)
            {
                Console.WriteLine(f);
            }
            return;
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
                Help(args);
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
