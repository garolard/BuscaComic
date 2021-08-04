using BuscaComic.Core.DTOs;
using BuscaComic.Core.Services;
using MvvmCross.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuscaComic.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly ICharacterService service;

        public MainViewModel(ICharacterService service)
        {
            this.service = service;
        }

        public async override Task Initialize()
        {
            await base.Initialize();
            SearchResults = await service.SearchCharactersByName("captain america");
        }

        private IEnumerable<CharacterDTO> searchResults;
        public IEnumerable<CharacterDTO> SearchResults
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
