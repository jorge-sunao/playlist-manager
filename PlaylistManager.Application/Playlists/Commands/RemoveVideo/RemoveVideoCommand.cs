using MediatR;
using PlaylistManager.Core.Entities;
using System;

namespace PlaylistManager.Application.Playlists.Commands.RemoveVideo
{
    public class RemoveVideoCommand : IRequest<Playlist>
    {
        public int PlaylistId { get; set; }
        public int VideoId { get; set; }

    }
}
