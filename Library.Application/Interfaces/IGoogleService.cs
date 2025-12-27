using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IGoogleService
    {
        Task<string> GetIdTocken(string code, CancellationToken ct = default);

        string GetRedirectLink();
    }
}
