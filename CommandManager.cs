using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Mentorship.Models.Enums;

namespace Mentorship
{
    class CommandManager
    {
       
        public void Check(Dictionary<string, string> parameters, string[] args)
        {
            if (!IsValid(parameters))
            {
                Help();
                return;
            }

            foreach (var p in parameters)
            {
                var parameter = ConstatntHelper.ParametersList
                    .FirstOrDefault(x => x.FullName == p.Key || x.ShortName == p.Key);
                Execute(parameter.Type, p.Value);
                if (parameter.Type == Keys.Help)
                {
                    return;
                }
            }
        }

        private void Execute(Keys key, string parameter)
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

        private void Version()
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Console.WriteLine("version: " + version);
            return;
        }

        private void Help()
        {
            var files = File.ReadAllText(@"C:\Users\mariana.novosad\source\repos\Mentorship\help.txt");
            Console.WriteLine(files);
        }

        private bool IsValid(Dictionary<string, string> parameters)
        {
            if (parameters == null)
            {
                return false;
            }
            return parameters.Keys
               .All(i => ConstatntHelper.ParametersList
                       .Any(y => y.FullName == i || y.ShortName == i));
        }
    }
}
