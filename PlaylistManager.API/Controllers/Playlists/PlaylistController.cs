using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using PlaylistManager.Application.Playlists.Queries.GetPlaylistsList;

namespace PlaylistManager.API.Controllers.Playlists
{
    [Route("api/Playlists")]
    public class PlaylistController : BaseController
    {
        /// <summary>
        /// Get environment test
        /// GET: api/Playlists/Test
        /// </summary>
        [HttpGet]
        [Route("Test")]
        public ActionResult<string> GetStageTest()
        {
            return Ok(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        }

        /// <summary>
        /// Retrieve all playlists
        /// GET: api/Playlists
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<GetPlaylistsListViewModel>> GetAll()
        {
            var vm = await Mediator.Send(new GetPlaylistsListQuery());
            return Ok(vm);
        }
    }
}
