using System;

namespace BuscaComic.Core.Common.DBC
{
    public class PreconditionException : Exception
    {
        public PreconditionException(string message) : base(message)
        {
        }
    }
}
