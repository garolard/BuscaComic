using BuscaComic.Core.DTOs;
using BuscaComic.Core.Mappers;
using BuscaComic.Core.Models;
using BuscaComic.Test.Common;
using System.Linq;
using Xunit;

namespace BuscaComic.Test.Mappers
{
    public class ComicToComicDetailDTOMapperSpecs
    {
        private readonly ObjectMother db;
        private readonly IMapper<Comic, ComicDetailDTO> mapper;

        [Fact]
        public void Should_Map_A_Comic()
        {
            var comic = mapper.Map(db.AgeOfHeroes);

            Assert.Equal(db.AgeOfHeroes.Id, comic.Id);
            Assert.Equal(db.AgeOfHeroes.Title, comic.Title);
            Assert.Equal(db.AgeOfHeroes.Description, comic.Description);
            Assert.Equal($"{db.AgeOfHeroes.Thumbnail.Path}.{db.AgeOfHeroes.Thumbnail.Extension}", comic.ThumbnailUrl);
            Assert.Equal(db.AgeOfHeroes.Characters.Items.Length, comic.Characters.Count());
        }


        public ComicToComicDetailDTOMapperSpecs()
        {
            db = new ObjectMother();
            mapper = new ComicToComicDetailDTOMapper();
        }
    }
}
