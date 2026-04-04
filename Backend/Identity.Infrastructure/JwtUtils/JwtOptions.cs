using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Infrastructure.JwtUtils
{
    public class JwtOptions
    {
        public string Secret { get; set; } = null!;
        public int ExpirationHours { get; set; }
    }
}
