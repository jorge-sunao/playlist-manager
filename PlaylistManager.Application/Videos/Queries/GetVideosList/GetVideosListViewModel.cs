using System;
using System.Collections.Generic;

namespace PlaylistManager.Application.Videos.Queries.GetVideosList
{
    public class GetVideosListViewModel
    {
        public IList<VideoDTO> Videos { get; set; }
    }

    public class VideoDTO
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
