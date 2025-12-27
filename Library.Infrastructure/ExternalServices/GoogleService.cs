using Library.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.ExternalServices
{
    public class GoogleService : IGoogleService
    {
        public Task<string> GetIdTocken(string code, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public string GetRedirectLink()
        {
            throw new NotImplementedException();
        }
    }
}
