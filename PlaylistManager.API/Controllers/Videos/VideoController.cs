using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using PlaylistManager.Application.Videos.Queries.GetVideosList;

namespace PlaylistManager.API.Controllers.Playlists
{
    [Route("api/Videos")]
    public class VideoController : BaseController
    {
        /// <summary>
        /// Get environment test
        /// GET: api/Videos/Test
        /// </summary>
        [HttpGet]
        [Route("Test")]
        public ActionResult<string> GetStageTest()
        {
            return Ok(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        }

        /// <summary>
        /// Retrieve all videos
        /// GET: api/Videos
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<GetVideosListViewModel>> GetAll()
        {
            var vm = await Mediator.Send(new GetVideosListQuery());
            return Ok(vm);
        }
    }
}
