using Android.App;
using Android.OS;
using BuscaComic.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace BuscaComic.Droid.Views
{
    [Activity(Label = "Buscador", MainLauncher = true)]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_main);
        }
    }
}