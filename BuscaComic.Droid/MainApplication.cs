using Android.App;
using Android.Runtime;
using BuscaComic.Core;
using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using System;

namespace BuscaComic.Droid
{
    public class MySetup : MvxAndroidSetup<App>
    {
        public MySetup()
        {
        }

        protected override ILoggerFactory CreateLogFactory()
        {
            return null;
        }

        protected override ILoggerProvider CreateLogProvider()
        {
            return null;
        }
    }

    [Application]
    public class MainApplication : MvxAndroidApplication<MySetup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
    }
}