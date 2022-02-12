using System;
using PlaylistManager.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace PlaylistManager.Core.Entities
{
    public class Video: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
    }
}
