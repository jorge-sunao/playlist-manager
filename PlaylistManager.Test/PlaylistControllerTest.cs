using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaylistManager.API.Controllers.Playlists;
using PlaylistManager.Application.Playlists.Queries.GetPlaylistsList;
using System;
using Xunit;

namespace PlaylistManager.Test
{
    public class PlaylistControllerTest
    {
        private readonly PlaylistController _controller;
        private readonly IMediator _mediator;

        public PlaylistControllerTest()
        {
            _mediator = HttpContext.RequestServices.GetService<IMediator>();
            _controller = new PlaylistController();
        }

        [Fact]
        public async void Get_WhenCalled_ReturnsAllItems_FirstLoad()
        {
            // Act
            var okResult = await _controller.GetAll();
            // Assert
            var items = Assert.IsType<GetPlaylistsListViewModel>(okResult.Value);
            Assert.Equal(2, items.Playlists.Count);
        }
    }
}
