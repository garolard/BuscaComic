using Android.App;
using Android.OS;
using BuscaComic.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace BuscaComic.Droid.Views
{
    [Activity(Label = "ComicDetailActivity")]
    public class ComicDetailActivity : MvxActivity<ComicDetailViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_comic_detail);
            this.CreateBinding().For("Title").To<ComicDetailViewModel>(vn => vn.Name).Apply();

            // Trucar el focus request del listview para que la actividad no
            // empiece con un scroll raro
            FindViewById(Resource.Id.characters_list).SetFocusable(Android.Views.ViewFocusability.NotFocusable);
        }
    }
}