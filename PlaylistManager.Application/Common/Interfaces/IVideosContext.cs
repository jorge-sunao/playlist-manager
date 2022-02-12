using PlaylistManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistManager.Application.Common.Interfaces
{
    public interface IVideosContext
    {
        public List<Video> GetVideos();
        public Video GetVideo(int id);
        public List<Video> AddVideos(List<Video> videoList);
    }
}
