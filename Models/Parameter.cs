using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.Models.Enums;

namespace Mentorship.Models
{
    class Parameter
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public Keys Type { get; set; }

        public Parameter() { }

        public Parameter(Keys type,  string shortName = "", string fullName = "")
        {
            ShortName = shortName;
            FullName = fullName;
            Type = type;
        }
    }
}
