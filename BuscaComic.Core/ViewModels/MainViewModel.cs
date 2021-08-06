using BuscaComic.Core.DTOs;
using BuscaComic.Core.Services;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuscaComic.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly ISearchService service;

        public MainViewModel(ISearchService service)
        {
            this.service = service;
        }

        public async override Task Initialize()
        {
            await base.Initialize();
            SearchResults = await service.Search("captain america");
        }

        private IEnumerable<IElementInListDTO> searchResults;
        public IEnumerable<IElementInListDTO> SearchResults
        {
            get => searchResults;
            set
            {
                searchResults = value;
                RaisePropertyChanged(() => SearchResults);
            }
        }
    }
}
