using BuscaComic.Core.Helpers;
using BuscaComic.Core.Infrastructure;
using BuscaComic.Core.Infrastructure.Impl;
using BuscaComic.Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using System.Linq;

namespace BuscaComic.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            // Registrar dependencias
            Mvx.IoCProvider.RegisterSingleton(new AppSettingsManager());
            Mvx.IoCProvider.RegisterSingleton<IRestFacade>(new RestFacade());

            Mvx.IoCProvider.RegisterSingleton(new RestHelpers());

            var typesToRegister = CreatableTypes().EndingWith("Repository")
                .Union(CreatableTypes().EndingWith("Mapper"))
                .Union(CreatableTypes().EndingWith("Service"));

            typesToRegister
                .AsInterfaces()
                .RegisterAsLazySingleton();

            // Registrar ViewModel inicial
            RegisterAppStart<MainViewModel>();
        }
    }
}
