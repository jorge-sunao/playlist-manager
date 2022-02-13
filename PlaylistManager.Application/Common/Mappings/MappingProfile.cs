using AutoMapper;
using PlaylistManager.Application.Playlists.Queries.GetPlaylistsList;
using PlaylistManager.Application.Videos.Queries.GetVideosList;
using PlaylistManager.Core.Entities;
using System;
using System.Linq;
using System.Reflection;

namespace PlaylistManager.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }

            CreateMap<Playlist, PlaylistDTO>();
            CreateMap<Video, VideoDTO>();
        }

    }
}
