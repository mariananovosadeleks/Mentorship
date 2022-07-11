using System.Collections.Generic;
using Mentorship.Models;
using Mentorship.Models.Enums;

namespace Mentorship
{
    static class ConstatntHelper
    {
        public static List<Parameter> ParametersList = new List<Parameter>()
        {
           new Parameter(Keys.Help, "h", "help"),
           new Parameter(Keys.IpDomainPort),
           new Parameter(Keys.FileName, "f", "file"),
           new Parameter(Keys.Output, "o", "output"),
           new Parameter(Keys.Password,"p", "password"),
           new Parameter(Keys.User, "u", "user"),
           new Parameter(Keys.Version, "v", "version")
        };
    }
}
