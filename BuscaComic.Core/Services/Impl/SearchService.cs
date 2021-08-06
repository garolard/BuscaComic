using BuscaComic.Core.DataAccess;
using BuscaComic.Core.DTOs;
using BuscaComic.Core.Mappers;
using BuscaComic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaComic.Core.Services.Impl
{
    public class SearchService : ISearchService
    {
        private readonly IComicRepository comicRepository;
        private readonly ICharacterRepository characterRepository;
        private readonly IMapper<Character, CharacterInListDTO> characterMapper;
        private readonly IMapper<Comic, ComicInListDTO> comicMaper;

        public SearchService(IComicRepository comicRepository, ICharacterRepository characterRepository, IMapper<Character, CharacterInListDTO> characterMapper, IMapper<Comic, ComicInListDTO> comicMaper)
        {
            this.comicRepository = comicRepository;
            this.characterRepository = characterRepository;
            this.characterMapper = characterMapper;
            this.comicMaper = comicMaper;
        }

        public async Task<IEnumerable<IElementInListDTO>> Search(string query)
        {
            // Esto seguro que podría tirarse mejor con un WaitAll aunque ahora mismo
            // no estoy seguro
            var characters = await characterRepository.SearchCharactersByName(query);
            var comics = await comicRepository.SearchComicsByName(query);

            return characters.Select(characterMapper.Map)
                .AsEnumerable<IElementInListDTO>()
                .Concat(comics.Select(comicMaper.Map));
        }
    }
}
