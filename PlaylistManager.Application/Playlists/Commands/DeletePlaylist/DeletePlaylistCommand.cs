using MediatR;
using PlaylistManager.Core.Entities;
using System;

namespace PlaylistManager.Application.Playlists.Commands.DeletePlaylist
{
    public class DeletePlaylistCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
