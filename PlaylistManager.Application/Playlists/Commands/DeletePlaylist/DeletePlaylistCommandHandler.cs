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

namespace PlaylistManager.Application.Playlists.Commands.DeletePlaylist
{
    public class DeletePlaylistCommandHandler : IRequestHandler<DeletePlaylistCommand, int>
    {
        private readonly IPlaylistsContext playlistContext;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public DeletePlaylistCommandHandler(IPlaylistsContext _playlistContext, IMediator _mediator, IMapper _mapper)
        {
            playlistContext = _playlistContext;
            mediator = _mediator;
            mapper = _mapper;
        }

        public async Task<int> Handle(DeletePlaylistCommand request, CancellationToken cancellationToken)
        {
            var playlistEntity = playlistContext.GetPlaylist(request.Id);

            if (playlistEntity == null)
            {
                throw new NotFoundException(nameof(Playlist), request.Id);
            }

            var deletedPlaylistId = playlistContext.DeletePlaylist(request.Id);

            return deletedPlaylistId;
        }
    }
}
