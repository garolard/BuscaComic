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

            if (LoadCharacterCommand.CanExecute(null))
                LoadCharacterCommand.Execute(null);
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

        private MvxNotifyTask taskNotifier;
        public MvxNotifyTask TaskNotifier
        {
            get => taskNotifier;
            private set => SetProperty(ref taskNotifier, value);
        }

        public ICommand LoadCharacterCommand
        {
            get => new MvxCommand(() => TaskNotifier = MvxNotifyTask.Create(() => LoadCharacterAsync(), onException: ex => OnException(ex)));
        }

        private async Task LoadCharacterAsync()
        {
            var detail = await searchService.GetCharacterById(param.Id);
            Description = detail.Description;
            Events = detail.Events;
        }

        private void OnException(Exception exception)
        {
            // Obviamente esto habría que tratarlo de otra manera mejor
            Debug.WriteLine(exception);
        }
    }
}
