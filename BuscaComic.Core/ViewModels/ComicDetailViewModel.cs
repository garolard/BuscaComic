using BuscaComic.Core.DTOs;
using BuscaComic.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

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
            if (LoadComicCommand.CanExecute(null))
                LoadComicCommand.Execute(null);
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

        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public IEnumerable<CharacterInListDTO> characters;
        public IEnumerable<CharacterInListDTO> Characters
        {
            get => characters;
            set => SetProperty(ref characters, value);
        }

        private MvxNotifyTask taskNotifier;
        public MvxNotifyTask TaskNotifier
        {
            get => taskNotifier;
            private set => SetProperty(ref taskNotifier, value);
        }

        public ICommand LoadComicCommand
        {
            get => new MvxCommand(() => TaskNotifier = MvxNotifyTask.Create(() => LoadComicAsync(), onException: ex => OnException(ex)));
        }

        private async Task LoadComicAsync()
        {
            var detail = await searchService.GetComicById(param.Id);
            Format = detail.Format;
            Description = detail.Description;
            Characters = detail.Characters;
        }

        private void OnException(Exception exception)
        {
            // Obviamente esto habría que tratarlo de otra manera mejor
            Debug.WriteLine(exception);
        }
    }
}
