using System;

namespace BuscaComic.Core.Common.System
{
    public class DisposableAction : IDisposable
    {
        private readonly Action _action;

        public DisposableAction(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            this._action = action;
        }

        public void Dispose()
        {
            this._action();
        }
    }
}
