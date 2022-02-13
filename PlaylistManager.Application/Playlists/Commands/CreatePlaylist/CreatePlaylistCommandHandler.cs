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

namespace PlaylistManager.Application.Playlists.Commands.CreatePlaylist
{
    public class CreatePlaylistCommandHandler : IRequestHandler<CreatePlaylistCommand, Playlist>
    {
        private readonly IPlaylistsContext playlistContext;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CreatePlaylistCommandHandler(IPlaylistsContext _playlistContext, IMediator _mediator, IMapper _mapper)
        {
            playlistContext = _playlistContext;
            mediator = _mediator;
            mapper = _mapper;
        }

        public async Task<Playlist> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken)
        {
            var playlistEntity = playlistContext.GetPlaylist(request.Id);

            if (playlistEntity != null)
            {
                throw new DuplicatedException(nameof(Playlist), request.Id);
            }

            var playlist = mapper.Map<Playlist>(request);
            var addedPlaylist = playlistContext.AddPlaylist(playlist);

            return addedPlaylist;
        }
    }
}
