using Android.App;
using Android.OS;
using BuscaComic.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace BuscaComic.Droid.Views
{
    [Activity(Label = "CharacterDetailActivity")]
    public class CharacterDetailActivity : MvxActivity<CharacterDetailViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_character_detail);
            this.CreateBinding().For("Title").To<CharacterDetailViewModel>(vn => vn.Name).Apply();
        }
    }
}