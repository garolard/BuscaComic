using BuscaComic.Core.Common.DBC;
using BuscaComic.Core.DataAccess;
using BuscaComic.Core.DTOs;
using BuscaComic.Core.Mappers;
using BuscaComic.Core.Models;
using BuscaComic.Core.Services;
using BuscaComic.Core.Services.Impl;
using BuscaComic.Test.Common;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BuscaComic.Test.Services
{
    public class SearchServiceSpecs
    {
        private readonly ObjectMother db;
        private readonly ISearchService service;

        [Fact]
        public async void Empty_Search_Term_Returns_Empty_Result()
        {
            var items = await service.Search("");

            Assert.Empty(items);
        }

        [Fact]
        public async void Can_Search_Multiple_Type_Of_Items()
        {
            var items = await service.Search("Thor");

            Assert.Contains(items, i => i.Type == ItemType.Character);
            Assert.Contains(items, i => i.Type == ItemType.Comic);
        }

        [Fact]
        public async void Result_Not_Related_To_Query_Are_Not_Returned()
        {
            var items = await service.Search(db.Hulk.Name);

            Assert.DoesNotContain(items, i => i.Type == ItemType.Character && i.Name.Equals(db.Thor.Name));
            Assert.Equal(items.Where(i => i.Type == ItemType.Comic).Select(c => c.Name), db.HulkComics.Select(c => c.Title));
        }

        [Fact]
        public async void Must_Provide_Valid_Id_To_Search_Characters_And_Comic()
        {
            await Assert.ThrowsAsync<PreconditionException>(async () => await service.GetCharacterById(0));
            await Assert.ThrowsAsync<PreconditionException>(async () => await service.GetCharacterById(-1));
            await Assert.ThrowsAsync<PreconditionException>(async () => await service.GetComicById(0));
            await Assert.ThrowsAsync<PreconditionException>(async () => await service.GetComicById(-1));
        }

        [Fact]
        public async void Can_Search_Individual_Characters()
        {
            var character = await service.GetCharacterById(db.Thor.Id);

            Assert.Equal(character.Id, db.Thor.Id);
            Assert.Equal(character.Name, db.Thor.Name);
            Assert.Equal(character.Description, db.Thor.Description);
            Assert.Equal(character.ThumbnailUrl, $"{db.Thor.Thumbnail.Path}.{db.Thor.Thumbnail.Extension}");
            Assert.Equal(character.Events.Select(e => e.Name), db.Thor.Events.Items.Select(i => i.Name));
        }

        [Fact]
        public async void Can_Search_Individual_Comic()
        {
            var comic = await service.GetComicById(db.AgeOfHeroes.Id);

            Assert.Equal(comic.Id, db.AgeOfHeroes.Id);
            Assert.Equal(comic.Title, db.AgeOfHeroes.Title);
            Assert.Equal(comic.Format, db.AgeOfHeroes.Format);
        }

        public SearchServiceSpecs()
        {
            db = new ObjectMother();

            var characterRepositoryMock = new Mock<ICharacterRepository>();
            var comicRepositoryMock = new Mock<IComicRepository>();
            var characterInListMapperMock = new Mock<IMapper<Character, CharacterInListDTO>>();
            var characterDetailMapperMock = new Mock<IMapper<Character, CharacterDetailDTO>>();
            var comicInListMapperMock = new Mock<IMapper<Comic, ComicInListDTO>>();
            var comicDetailMapperMock = new Mock<IMapper<Comic, ComicDetailDTO>>();

            ConfigMock(characterRepositoryMock);
            ConfigMock(comicRepositoryMock);
            ConfigMock(characterInListMapperMock);
            ConfigMock(characterDetailMapperMock);
            ConfigMock(comicInListMapperMock);
            ConfigMock(comicDetailMapperMock);

            service = new SearchService(
                comicRepositoryMock.Object, 
                characterRepositoryMock.Object, 
                characterInListMapperMock.Object, 
                comicInListMapperMock.Object, 
                characterDetailMapperMock.Object, 
                comicDetailMapperMock.Object
            );
        }

        private void ConfigMock(Mock<ICharacterRepository> mock)
        {
            mock.Setup(x => x.SearchCharactersByName(It.IsAny<string>()))
                .Returns((string term) => { 
                    return Task.FromResult(
                        db.AllCharacters.Where(x => x.Name.Contains(term)).ToArray()); 
                });
            mock.Setup(x => x.FindById(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    return Task.FromResult(
                        db.AllCharacters.First(x => x.Id == id));
                });
        }

        private void ConfigMock(Mock<IComicRepository> mock)
        {
            mock.Setup(x => x.SearchComicsByName(It.IsAny<string>()))
                .Returns((string term) =>
                {
                    return Task.FromResult(
                        db.AllComics.Where(x => x.Characters.Items.Any(c => c.Name.Contains(term))).ToArray());
                });
            mock.Setup(x => x.FindById(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    return Task.FromResult(
                        db.AllComics.First(x => x.Id == id));
                });
        }

        // Si el día de mañana cambia la lógica del mapper, no solo habrá
        // que tocar los tests del propio mapper si no acordarse
        // de cambiar estos métodos. Por eso no me gustan los mocks
        private void ConfigMock(Mock<IMapper<Character, CharacterInListDTO>> mock)
        {
            mock.Setup(x => x.Map(It.IsAny<Character>()))
                .Returns((Character c) =>
                {
                    return new CharacterInListDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        ImageUrl = $"{c.Thumbnail.Path}.{c.Thumbnail.Extension}",
                        Description = c.Description,
                        Type = ItemType.Character
                    };
                });
        }

        private void ConfigMock(Mock<IMapper<Character, CharacterDetailDTO>> mock)
        {
            mock.Setup(x => x.Map(It.IsAny<Character>()))
               .Returns((Character c) =>
               {
                   return new CharacterDetailDTO
                   {
                       Id = c.Id,
                       Name = c.Name,
                       Description = c.Description,
                       ThumbnailUrl = $"{c.Thumbnail.Path}.{c.Thumbnail.Extension}",
                       Events = c.Events.Items.Select(x => new EventDTO { Name = x.Name })
                   };
               });
        }

        private void ConfigMock(Mock<IMapper<Comic, ComicInListDTO>> mock)
        {
            mock.Setup(x => x.Map(It.IsAny<Comic>()))
               .Returns((Comic c) =>
               {
                   return new ComicInListDTO
                   {
                       Id = c.Id,
                       Name = c.Title,
                       Description = c.Description,
                       ImageUrl = $"{c.Thumbnail.Path}.{c.Thumbnail.Extension}",
                       Type = ItemType.Comic
                   };
               });
        }

        private void ConfigMock(Mock<IMapper<Comic, ComicDetailDTO>> mock)
        {
            mock.Setup(x => x.Map(It.IsAny<Comic>()))
               .Returns((Comic c) =>
               {
                   return new ComicDetailDTO
                   {
                       Id = c.Id,
                       Title = c.Title,
                       Format = c.Format,
                       Characters = c.Characters.Items.Select(c => new CharacterInListDTO { Name = c.Name })
                   };
               });
        }
    }
}
