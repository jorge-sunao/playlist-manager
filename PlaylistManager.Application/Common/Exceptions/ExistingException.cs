using System;

namespace PlaylistManager.Application.Common.Exceptions
{
    public class ExistingException : Exception
    {
        public ExistingException(string entityNameA, object keyA, string entityNameB, object keyB) : base($"Entity \"{entityNameB}\" ({keyA}) already exists on \"{entityNameB}\" ({keyB}).") { }
    }
}
