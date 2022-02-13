using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using PlaylistManager.Application.Playlists.Queries.GetPlaylistsList;
using PlaylistManager.Application.Playlists.Commands.CreatePlaylist;
using PlaylistManager.Application.Playlists.Commands.UpdatePlaylist;
using PlaylistManager.Application.Playlists.Commands.DeletePlaylist;
using PlaylistManager.Application.Playlists.Commands.AddVideo;
using PlaylistManager.Application.Playlists.Commands.RemoveVideo;
using PlaylistManager.Application.Playlists.Queries.GetVideosPlaylist;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetPlaylistsListViewModel>> GetAll()
        {
            try
            {
                var vm = await Mediator.Send(new GetPlaylistsListQuery());
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieve videos from a playlist
        /// GET: api/Playlists
        /// </summary>
        [HttpGet]
        [Route("{id}/Videos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetVideosPlaylistViewModel>> GetVideos(int id)
        {
            try
            {
                var vm = await Mediator.Send(new GetVideosPlaylistQuery() { PlaylistId = id });
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create a new playlist
        /// POST: api/Playlists
        /// </summary>
        /// <param name="command"></param>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreatePlaylistCommand command)
        {
            try
            {
                var createPlaylist = await Mediator.Send(command);
                return Ok(createPlaylist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update an existing playlist
        /// PUT: api/Playlists/5
        /// </summary>
        /// <param name="command"></param>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UpdatePlaylistCommand command)
        {
            try
            {
                var updatedPlaylist = await Mediator.Send(command);
                return Ok(updatedPlaylist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Add video to playlist
        /// PUT: api/Playlists/5/AddVideo
        /// </summary>
        /// <param name="command"></param>
        [HttpPut]
        [Route("AddVideo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddVideoToPlaylist([FromBody] AddVideoCommand command)
        {
            try
            {
                var updatedPlaylist = await Mediator.Send(command);
                return Ok(updatedPlaylist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove video to playlist
        /// PUT: api/Playlists/5/RemoveVideo
        /// </summary>
        /// <param name="command"></param>
        [HttpPut]
        [Route("RemoveVideo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveVideoToPlaylist([FromBody] RemoveVideoCommand command)
        {
            try
            {
                var updatedPlaylist = await Mediator.Send(command);
                return Ok(updatedPlaylist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete an existing playlist
        /// DELETE: api/Playlists/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedId = await Mediator.Send(new DeletePlaylistCommand { Id = id });

                return Ok(deletedId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
