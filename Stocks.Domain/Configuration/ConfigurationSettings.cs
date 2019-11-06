using System;
using Microsoft.Extensions.Configuration;

namespace Stocks.Domain.Configuration
{
    public static class ConfigurationExtensions
    {
        public static T GetSection<T>(this IConfiguration configuration, string key)
            => configuration.GetSection(key).Get<T>();

    }

    public class DataProtectionSettings
    {
        public string Location { get; set; }
    }

    public class ApiSettings
    {
        public Uri Uri { get; set; }
    }

    public class AuthServiceSettings
    {
        public string Authority { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
