using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistManager.Application.Playlists.Queries.GetPlaylistsList
{
    public class GetPlaylistsListViewModel
    {
        public IList<PlaylistDTO> Playlists { get; set; }
    }

    public class PlaylistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> VideoIds { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
