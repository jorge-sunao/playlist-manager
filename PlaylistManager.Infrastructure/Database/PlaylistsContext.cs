using System;
using PlaylistManager.Application.Common.Interfaces;
using PlaylistManager.Core.Entities;
using System.Collections.Generic;

namespace PlaylistManager.Infrastructure.Database
{
    public class PlaylistsContext : IPlaylistsContext
    {
        private List<Playlist> _playlists;

        public PlaylistsContext()
        {
            _playlists = new List<Playlist>();
        }

        public List<Playlist> GetPlaylists()
        {
            return _playlists;
        }

        public Playlist GetPlaylist(int id)
        {
            Playlist playlistItem = null;
            for (var index = _playlists.Count - 1; index >= 0; index--)
            {
                if (_playlists[index].Id == id)
                {
                    playlistItem = _playlists[index];
                }
            }
            return playlistItem;
        }

        public Playlist AddPlaylist(Playlist playlistItem)
        {
            _playlists.Add(playlistItem);
            return playlistItem;
        }
    }
}
