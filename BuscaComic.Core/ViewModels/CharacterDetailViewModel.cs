﻿using BuscaComic.Core.DTOs;
using BuscaComic.Core.Services;
using MvvmCross.ViewModels;
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
        }

        public string ImageUrl
        {
            get => param.ImageUrl;
        }

        public string Name
        {
            get => param.Name;
        }
    }
}
