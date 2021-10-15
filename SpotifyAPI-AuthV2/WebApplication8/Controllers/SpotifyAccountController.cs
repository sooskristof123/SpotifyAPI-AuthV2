using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyAccountController : ControllerBase
    {
        [HttpGet]
        public RedirectResult RedirectToAuthorization()
        {
            return RedirectPermanent("https://accounts.spotify.com/authorize?client_id=228d1334efe047749b9770adaf6ef31d&response_type=code&redirect_uri=https://localhost:44322/api/Authorized");
        }
    }
}
