using BuscaComic.Core.DTOs;
using BuscaComic.Core.Services;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuscaComic.Core.ViewModels
{
    public class CharacterDetailViewModel : MvxViewModel<CharacterInListDTO>
    {
        private CharacterInListDTO param;

        private readonly ISearchService searchService;

        public CharacterDetailViewModel(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public override void Prepare(CharacterInListDTO parameter)
        {
            param = parameter;
        }

        public async override Task Initialize()
        {
            await base.Initialize();
            var detail = await searchService.GetCharacterById(param.Id);
            Description = detail.Description;
            Events = detail.Events;
        }

        public string ImageUrl
        {
            get => param.ImageUrl;
        }

        public string Name
        {
            get => param.Name;
        }

        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private IEnumerable<EventDTO> events;
        public IEnumerable<EventDTO> Events
        {
            get => events;
            set => SetProperty(ref events, value);
        }
    }
}
