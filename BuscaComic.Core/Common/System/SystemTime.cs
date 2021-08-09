using System;

namespace BuscaComic.Core.Common.System
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = (() => DateTime.Now);
        public static readonly Func<DateTime> Today = (() => Now().Date);

        public static void ToDefault()
        {
            Now = () => DateTime.Now;
        }

        public static void Reset()
        {
            ToDefault();
        }

        public static IDisposable Custom(Func<DateTime> customNowProvider)
        {
            Now = customNowProvider;
            return new DisposableAction(new Action(ToDefault));
        }
    }
}
