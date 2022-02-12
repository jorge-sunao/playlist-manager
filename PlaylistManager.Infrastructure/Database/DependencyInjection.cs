using System;
using Microsoft.Extensions.DependencyInjection;
using PlaylistManager.Application.Common.Interfaces;

namespace PlaylistManager.Infrastructure.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IPlaylistsContext, PlaylistsContext>();
            services.AddSingleton<IVideosContext, VideosContext>();

            return services;
        }
    }
}
