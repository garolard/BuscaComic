using BuscaComic.Core.DTOs;
using BuscaComic.Core.Mappers;
using BuscaComic.Core.Models;
using BuscaComic.Test.Common;
using Xunit;

namespace BuscaComic.Test.Mappers
{
    public class ComicToComicInListDTOMapperSpecs
    {
        private readonly ObjectMother db;
        private readonly IMapper<Comic, ComicInListDTO> mapper;       

        [Fact]
        public void Should_Map_A_Comic()
        {
            var dto = mapper.Map(db.AgeOfHeroes);

            Assert.Equal(db.AgeOfHeroes.Id, dto.Id);
            Assert.Equal(db.AgeOfHeroes.Title, dto.Name);
            Assert.Equal(db.AgeOfHeroes.Description, dto.Description);
            Assert.Equal($"{db.AgeOfHeroes.Thumbnail.Path}.{db.AgeOfHeroes.Thumbnail.Extension}", dto.ImageUrl);
            Assert.Equal(ItemType.Comic, dto.Type);
        }

        public ComicToComicInListDTOMapperSpecs()
        {
            db = new ObjectMother();
            mapper = new ComicToComicInListDTOMapper();
        }
    }
}
