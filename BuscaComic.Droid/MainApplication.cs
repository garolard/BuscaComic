using Android.App;
using Android.Runtime;
using BuscaComic.Core;
using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using Serilog;
using Serilog.Extensions.Logging;
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
            // serilog configuration
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                // add more sinks here
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
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