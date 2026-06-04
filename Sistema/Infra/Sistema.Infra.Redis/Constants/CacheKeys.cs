using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Infra.Redis.Constants
{
    public class CacheKeys
    {
        private static readonly string _prefix = "Sistema";
        public static string PrefixWithEnvironment(string environmentName) => $"{_prefix}_{environmentName.ToLowerInvariant()}_";
    }

}
