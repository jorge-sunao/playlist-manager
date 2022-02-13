using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistManager.Application.Playlists.Queries.GetVideosPlaylist
{
    public class GetVideosPlaylistViewModel
    {
        public IList<VideosPlaylistDTO> Videos { get; set; }
    }

    public class VideosPlaylistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Thumbnail { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }

}
