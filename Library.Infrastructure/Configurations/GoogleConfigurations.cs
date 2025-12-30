using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Configurations
{
    public class GoogleConfigurations
    {
        public static string SectionName => nameof(GoogleConfigurations);
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string BaseUrl { get; set; }

        public string RedirectPath { get; set; }
    }
}
