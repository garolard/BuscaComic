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
            Mvx.IoCProvider.RegisterSingleton<IAppSettingsManager>(new AppSettingsManager());
            Mvx.IoCProvider.RegisterSingleton<IRestFacade>(new RestFacade());

            // Registrar ViewModel inicial
            RegisterAppStart<MainViewModel>();
        }
    }
}
