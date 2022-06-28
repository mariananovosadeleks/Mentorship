using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.Models.Enums;

namespace Mentorship.Models
{
    class Parameter
    {
        private string ShortName { get; set; }
        private string FullName { get; set; }
        private Keys Type { get; set; }

        public Parameter(Keys type,  string shortName = "", string fullName = "")
        {
            ShortName = shortName;
            FullName = fullName;
            Type = type;
        }
    }
}
