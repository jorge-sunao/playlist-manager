using System;
using PlaylistManager.Application.Common.Interfaces;
using PlaylistManager.Core.Entities;
using System.Collections.Generic;

namespace PlaylistManager.Infrastructure.Database
{
    public class VideosContext : IVideosContext
    {
        private List<Video> _videos;

        public VideosContext()
        {
            _videos = new List<Video>();
        }

        public List<Video> GetVideos()
        {
            return _videos;
        }

        public Video GetVideo(int id)
        {
            Video videoItem = null;
            for (var index = _videos.Count - 1; index >= 0; index--)
            {
                if (_videos[index].Id == id)
                {
                    videoItem = _videos[index];
                }
            }
            return videoItem;
        }

        public List<Video> AddVideos(List<Video> videosList)
        {
            List<Video> videosToAdd = new List<Video>();

            foreach (var video in videosList)
            {
                if (video.DateCreated == DateTime.MinValue)
                {
                    video.DateCreated = DateTime.Now;
                }

                video.DateLastModified = DateTime.Now;

                videosToAdd.Add(video);
            }

            _videos.AddRange(videosToAdd);
            return _videos;
        }
    }
}
