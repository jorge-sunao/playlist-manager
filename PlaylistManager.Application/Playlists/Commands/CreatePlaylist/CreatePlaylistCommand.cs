using MediatR;
using PlaylistManager.Core.Entities;
using System;

namespace PlaylistManager.Application.Playlists.Commands.CreatePlaylist
{
    public class CreatePlaylistCommand : IRequest<Playlist>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
