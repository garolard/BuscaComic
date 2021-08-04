using BuscaComic.Core.DataAccess;
using BuscaComic.Core.DataAccess.Impl;
using BuscaComic.Core.Infraestructure;
using BuscaComic.Core.Infraestructure.Impl;
using BuscaComic.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace BuscaComic.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            // Registrar dependencias
            Mvx.IoCProvider.RegisterSingleton(new AppSettingsManager());
            Mvx.IoCProvider.RegisterSingleton<IRestFacade>(new RestFacade());

            Mvx.IoCProvider.RegisterType<IMarvelRepository, MarvelRepository>();

            // Registrar ViewModel inicial
            RegisterAppStart<MainViewModel>();
        }
    }
}
