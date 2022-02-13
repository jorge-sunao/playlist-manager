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

namespace PlaylistManager.Application.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, GetVideosListViewModel>
    {
        private readonly IVideosContext videosContext;
        private readonly IMapper mapper;

        public GetVideosListQueryHandler(IVideosContext _videosContext, IMapper _mapper)
        {
            videosContext = _videosContext;
            mapper = _mapper;
        }

        public async Task<GetVideosListViewModel> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            var videosDTO = mapper.Map<List<VideoDTO>>(videosContext.GetVideos());

            if (videosDTO == null)
            {
                throw new NotFoundException(nameof(Video), request);
            }

            var videosList = new GetVideosListViewModel { Videos = videosDTO };

            return videosList;
        }
    }
}
