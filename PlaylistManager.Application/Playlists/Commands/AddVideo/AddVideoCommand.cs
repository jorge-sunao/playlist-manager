using MediatR;
using PlaylistManager.Core.Entities;
using System;

namespace PlaylistManager.Application.Playlists.Commands.AddVideo
{
    public class AddVideoCommand : IRequest<Playlist>
    {
        public int PlaylistId { get; set; }
        public int VideoId { get; set; }

    }
}
