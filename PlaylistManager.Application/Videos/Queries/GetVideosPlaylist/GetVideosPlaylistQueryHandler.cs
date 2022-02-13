using AutoMapper;
using MediatR;
using PlaylistManager.Application.Common.Exceptions;
using PlaylistManager.Application.Common.Interfaces;
using PlaylistManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlaylistManager.Application.Playlists.Queries.GetVideosPlaylist
{
    public class GetVideosPlaylistQueryHandler : IRequestHandler<GetVideosPlaylistQuery, GetVideosPlaylistViewModel>
    {
        private readonly IPlaylistsContext playlistsContext;
        private readonly IVideosContext videosContext;
        private readonly IMapper mapper;

        public GetVideosPlaylistQueryHandler(IPlaylistsContext _playlistsContext, IVideosContext _videosContext, IMapper _mapper)
        {
            playlistsContext = _playlistsContext;
            videosContext = _videosContext;
            mapper = _mapper;
        }

        public async Task<GetVideosPlaylistViewModel> Handle(GetVideosPlaylistQuery request, CancellationToken cancellationToken)
        {
            var playlist = playlistsContext.GetPlaylist(request.PlaylistId);

            if (playlist == null)
            {
                throw new NotFoundException(nameof(Playlist), request);
            }

            List<Video> listOfVideos = new List<Video>();
            
            foreach (var videoId in playlist.VideoIds)
            {
                var videoEntity = videosContext.GetVideo(videoId);

                if (videoEntity != null)
                {
                    listOfVideos.Add(videoEntity);
                }
            }

            var videosDTO = mapper.Map<List<VideosPlaylistDTO>>(listOfVideos);

            var videosList = new GetVideosPlaylistViewModel { Videos = videosDTO };

            return videosList;
        }
    }
}
