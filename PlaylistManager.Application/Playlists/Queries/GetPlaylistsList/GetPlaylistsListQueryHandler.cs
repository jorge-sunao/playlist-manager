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

namespace PlaylistManager.Application.Playlists.Queries.GetPlaylistsList
{
    public class GetPlaylistsListQueryHandler : IRequestHandler<GetPlaylistsListQuery, GetPlaylistsListViewModel>
    {
        private readonly IPlaylistsContext PlaylistsContext;
        private readonly IMapper mapper;

        public GetPlaylistsListQueryHandler(IPlaylistsContext _playlistsContext, IMapper _mapper)
        {
            PlaylistsContext = _playlistsContext;
            mapper = _mapper;
        }

        public async Task<GetPlaylistsListViewModel> Handle(GetPlaylistsListQuery request, CancellationToken cancellationToken)
        {
            var playlistsDTO = mapper.Map<List<PlaylistDTO>>(PlaylistsContext.GetPlaylists());

            if (playlistsDTO == null)
            {
                throw new NotFoundException(nameof(Playlist), request);
            }

            var playlistList = new GetPlaylistsListViewModel { Playlists = playlistsDTO };

            return playlistList;
        }
    }
}
