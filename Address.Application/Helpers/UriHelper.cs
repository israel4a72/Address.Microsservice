using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address.Application.Helpers
{
    public static class UriHelper
    {
        public static Uri GetCepUrl(string cep)
        {
            return new Uri($"https://viacep.com.br/ws/{cep}/json/");
        }
    }
}