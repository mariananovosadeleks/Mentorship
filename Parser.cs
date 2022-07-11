using System;
using System.Collections.Generic;
using System.Linq;

namespace Mentorship
{
    public class Parser
    {
        public Dictionary<string, string> Parse(string[] parameters)
        {
            return string.Join(" ", parameters)
            .Split("-")
            .Where(x => !String.IsNullOrWhiteSpace(x))
            .ToDictionary((x => x.Split(" ")[0]), GetValue);
        }

        private string GetValue(string param)
        {
            var array = param.Split(" ");
            var value = array.Length > 1 ? array[1] : string.Empty;
            return value;
        }

    }
}
