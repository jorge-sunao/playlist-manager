using MediatR;
using System;
namespace PlaylistManager.Application.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<GetVideosListViewModel>
    {
    }
}
