using System;
using MediatR;

namespace PlaylistManager.Application.Playlists.Queries.GetVideosPlaylist
{
    public class GetVideosPlaylistQuery : IRequest<GetVideosPlaylistViewModel>
    {
        public int PlaylistId { get; set; }
    }
}
