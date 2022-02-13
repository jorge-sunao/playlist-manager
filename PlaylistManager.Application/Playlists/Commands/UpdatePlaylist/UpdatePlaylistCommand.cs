using MediatR;
using PlaylistManager.Core.Entities;
using System;

namespace PlaylistManager.Application.Playlists.Commands.UpdatePlaylist
{
    public class UpdatePlaylistCommand : IRequest<Playlist>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
