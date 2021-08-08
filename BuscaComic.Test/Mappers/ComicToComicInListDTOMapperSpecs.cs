using BuscaComic.Core.DTOs;
using BuscaComic.Core.Mappers;
using BuscaComic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BuscaComic.Test.Mappers
{
    public class ComicToComicInListDTOMapperSpecs
    {
        private readonly IMapper<Comic, ComicInListDTO> mapper;

        public ComicToComicInListDTOMapperSpecs()
        {
            this.mapper = new ComicToComicInListDTOMapper();
        }

        [Fact]
        public void Should_Map_A_Comic()
        {
            var comic = Comic();
            var dto = mapper.Map(comic);

            Assert.Equal(comic.Id, dto.Id);
            Assert.Equal(comic.Title, dto.Name);
            Assert.Equal(comic.Description, dto.Description);
            Assert.Equal($"{comic.Thumbnail.Path}.{comic.Thumbnail.Extension}", dto.ImageUrl);
            Assert.Equal(ItemType.Comic, dto.Type);
        }

        private Comic Comic()
        {
            return new Comic
            {
                Id = 1,
                Title = "Avengers #1",
                Description = "Número 1 de Avengers",
                Thumbnail = new Thumbnail
                {
                    Path = new Uri("https://placeholder.pics/svg/300"),
                    Extension = "jpg"
                }

            };
        }
    }
}
