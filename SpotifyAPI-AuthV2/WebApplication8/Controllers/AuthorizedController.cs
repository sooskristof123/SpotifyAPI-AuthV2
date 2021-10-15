using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebApplication8.Services;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizedController : ControllerBase
    {
        ISpotifyServices spotifyServices;
        IConfiguration configuration;
        public AuthorizedController(ISpotifyServices spotifyServices, IConfiguration configuration)
        {
            this.spotifyServices = spotifyServices;
            this.configuration = configuration;
        }
        [HttpGet]
        public async Task<string> AuthorizedAsync([FromQuery] string code) {
            //Uri uri = new Uri(HttpContext.Request.GetDisplayUrl());
            //string code = HttpUtility.ParseQueryString(uri.Query).Get("code");
            var token = await spotifyServices.GetToken(configuration["Spotify:clientId"], configuration["Spotify:clientSecret"], code);
            return "Authorized";
        }
    }
}
