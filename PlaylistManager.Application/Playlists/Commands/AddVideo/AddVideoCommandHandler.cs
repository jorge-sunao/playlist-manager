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

namespace PlaylistManager.Application.Playlists.Commands.AddVideo
{
    public class AddVideoCommandHandler : IRequestHandler<AddVideoCommand, Playlist>
    {
        private readonly IPlaylistsContext playlistContext;
        private readonly IVideosContext videosContext;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public AddVideoCommandHandler(IPlaylistsContext _playlistContext, IVideosContext _videosContext, IMediator _mediator, IMapper _mapper)
        {
            playlistContext = _playlistContext;
            videosContext = _videosContext;
            mediator = _mediator;
            mapper = _mapper;
        }

        public async Task<Playlist> Handle(AddVideoCommand request, CancellationToken cancellationToken)
        {
            var playlistEntity = playlistContext.GetPlaylist(request.PlaylistId);

            if (playlistEntity == null)
            {
                throw new NotFoundException(nameof(Playlist), request.PlaylistId);
            }

            if (playlistEntity.VideoIds == null)
                playlistEntity.VideoIds = new List<int>();

            var videoEntity = videosContext.GetVideo(request.VideoId);

            if (videoEntity == null)
            {
                throw new NotFoundException(nameof(Video), request.VideoId);
            }

            if (playlistEntity.VideoIds.Any(vi => vi == request.VideoId))
            {
                throw new ExistingException(nameof(Video), request.VideoId, nameof(Playlist), request.PlaylistId);
            }

            playlistEntity.VideoIds = playlistEntity.VideoIds.Concat(new[] { request.VideoId });

           var updatedPlaylist = playlistContext.UpdatePlaylist(request.PlaylistId, playlistEntity);
            return updatedPlaylist;
        }
    }
}
