using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Services
{
    public interface ISpotifyServices
    {
        public Task<string> GetToken(string clientId, string clientSecret, string code);
    }
}
