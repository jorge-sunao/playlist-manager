using System;
using PlaylistManager.Core.Entities;
using System.Collections.Generic;

namespace PlaylistManager.Application.Common.Interfaces
{
    public interface IPlaylistsContext
    {
        public List<Playlist> GetPlaylists();
        public Playlist GetPlaylist(int id);
        public Playlist AddPlaylist(Playlist playlistItem);
        public List<Playlist> AddPlaylists(List<Playlist> playlistList);
        public Playlist UpdatePlaylist(int id, Playlist playlistItem);
        public int DeletePlaylist(int id);
    }
}
