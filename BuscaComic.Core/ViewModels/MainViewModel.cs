using BuscaComic.Core.DTOs;
using BuscaComic.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BuscaComic.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly ISearchService searchService;
        private readonly IMvxNavigationService navigationService;

        public MainViewModel(ISearchService searchService, IMvxNavigationService navigationService)
        {
            this.searchService = searchService;
            this.navigationService = navigationService;
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        private IEnumerable<IElementInListDTO> searchResults;
        public IEnumerable<IElementInListDTO> SearchResults
        {
            get => searchResults;
            private set => SetProperty(ref searchResults, value);
        }

        private string searchTerm;
        public string SearchTerm
        {
            get { return searchTerm; }
            set
            {
                searchTerm = value;
                SearchCommand.Execute(null);

                RaisePropertyChanged(() => SearchTerm);
                RaisePropertyChanged(() => SearchResults);
            }
        }

        private MvxNotifyTask taskNotifier;
        public MvxNotifyTask TaskNotifier
        {
            get => taskNotifier;
            private set => SetProperty(ref taskNotifier, value);
        }

        public ICommand SearchCommand
        {
            get => new MvxCommand(() => TaskNotifier = MvxNotifyTask.Create(() => SearchAsync(), onException: ex => OnException(ex)));
        }

        public ICommand ItemClickedCommand
        {
            get => new MvxAsyncCommand<IElementInListDTO>(async (item) =>
            {
                // Esto se podría manejar mejor usando Fragments en una vista DetailActivity común
                // y así si el día de mañana surge un tipo nuevo de item solo hay que implementar
                // el fragment correspondiente.
                switch (item.Type)
                {
                    case ItemType.Character:
                        await navigationService.Navigate<CharacterDetailViewModel, CharacterInListDTO>(item as CharacterInListDTO);
                        break;
                    case ItemType.Comic:
                        await navigationService.Navigate<ComicDetailViewModel, ComicInListDTO>(item as ComicInListDTO);
                        break;
                    default:
                        return;
                }
                
            });
        }

        private async Task SearchAsync()
        {
            if (string.IsNullOrEmpty(searchTerm))
                SearchResults = Enumerable.Empty<IElementInListDTO>();
            else
                SearchResults = await searchService.Search(searchTerm);
        }
        private void OnException(Exception exception)
        {
            // Obviamente esto habría que tratarlo de otra manera mejor
            Debug.WriteLine(exception);
        }
    }
}
