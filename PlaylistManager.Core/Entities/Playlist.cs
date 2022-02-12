using System;
using PlaylistManager.Core.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaylistManager.Core.Entities
{
    public class Playlist : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public IEnumerable<int> VideoIds { get; set; }
    }
}
