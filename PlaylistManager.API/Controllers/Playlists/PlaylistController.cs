using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace PlaylistManager.API.Controllers.Playlists
{
    [Route("api/Playlists")]
    public class PlaylistController : BaseController
    {
        // GET: api/Playlists
        [HttpGet]
        public ActionResult<string> GetStageTest()
        {
            return Ok(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        }
    }
}
