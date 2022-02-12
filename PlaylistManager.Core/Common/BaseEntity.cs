using System;

namespace PlaylistManager.Core.Common
{
    public class BaseEntity
    {
        public DateTime DateCreated { get; set; }

        public DateTime? DateLastModified { get; set; }
    }
}
