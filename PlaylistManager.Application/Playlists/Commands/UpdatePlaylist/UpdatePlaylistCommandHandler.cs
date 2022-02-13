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

namespace PlaylistManager.Application.Playlists.Commands.UpdatePlaylist
{
    public class UpdatePlaylistCommandHandler : IRequestHandler<UpdatePlaylistCommand, Playlist>
    {
        private readonly IPlaylistsContext playlistContext;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public UpdatePlaylistCommandHandler(IPlaylistsContext _playlistContext, IMediator _mediator, IMapper _mapper)
        {
            playlistContext = _playlistContext;
            mediator = _mediator;
            mapper = _mapper;
        }

        public async Task<Playlist> Handle(UpdatePlaylistCommand request, CancellationToken cancellationToken)
        {
            var playlistEntity = playlistContext.GetPlaylist(request.Id);

            if (playlistEntity == null)
            {
                throw new NotFoundException(nameof(Playlist), request.Id);
            }

            playlistEntity.Name = request.Name;
            playlistEntity.Description = request.Description;

            var addedPlaylist = playlistContext.UpdatePlaylist(request.Id, playlistEntity);

            return addedPlaylist;
        }
    }
}
