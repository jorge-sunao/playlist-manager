using System;

namespace PlaylistManager.Application.Common.Exceptions
{
    public class DuplicatedException : Exception
    {
        public DuplicatedException(string name, object key) : base($"Entity \"{name}\" ({key}) already exists.") { }
    }
}
