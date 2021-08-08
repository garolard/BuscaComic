using BuscaComic.Core.DTOs;
using BuscaComic.Core.Services;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuscaComic.Core.ViewModels
{
    public class ComicDetailViewModel : MvxViewModel<ComicInListDTO>
    {
        private ComicInListDTO param;

        private readonly ISearchService searchService;

        public ComicDetailViewModel(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public override void Prepare(ComicInListDTO parameter)
        {
            param = parameter;
        }

        public async override Task Initialize()
        {
            await base.Initialize();
            var detail = await searchService.GetComicById(param.Id);
            Format = detail.Format;
            Character = detail.Characters;
        }

        public string ThumbnailUrl
        {
            get => param.ImageUrl;
        }

        public string Name
        {
            get => param.Name;
        }

        private string format;
        public string Format
        {
            get => format;
            set => SetProperty(ref format, value);
        }

        public IEnumerable<CharacterInListDTO> character;
        public IEnumerable<CharacterInListDTO> Character
        {
            get => character;
            set => SetProperty(ref character, value);
        }
    }
}
