using Newtonsoft.Json;
using PlaylistManager.Application.Common.Interfaces;
using PlaylistManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistManager.Infrastructure.Database
{
    public static class DataInitialiser
    {
        public static async Task SeedData(IPlaylistsContext playlistsContext, IVideosContext videosContext)
        {
            string videoJson = File.ReadAllText(@"Data" + Path.DirectorySeparatorChar + "videos.json");
            List<Video> videosList = JsonConvert.DeserializeObject<List<Video>>(videoJson);

            videosContext.AddVideos(videosList);

            string playlistJson = File.ReadAllText(@"Data" + Path.DirectorySeparatorChar + "playlists.json");
            List<Playlist> playlistsList = JsonConvert.DeserializeObject<List<Playlist>>(playlistJson);

            playlistsContext.AddPlaylists(playlistsList);
        }
    }
}
