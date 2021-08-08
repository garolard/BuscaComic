using BuscaComic.Core.DataAccess;
using BuscaComic.Core.DTOs;
using BuscaComic.Core.Mappers;
using BuscaComic.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaComic.Core.Services.Impl
{
    public class SearchService : ISearchService
    {
        private readonly IComicRepository comicRepository;
        private readonly ICharacterRepository characterRepository;
        private readonly IMapper<Character, CharacterInListDTO> characterMapper;
        private readonly IMapper<Character, CharacterDetailDTO> characterDetailMapper;
        private readonly IMapper<Comic, ComicInListDTO> comicMaper;
        private readonly IMapper<Comic, ComicDetailDTO> comicDetailMapper;


        public SearchService(IComicRepository comicRepository, 
            ICharacterRepository characterRepository, 
            IMapper<Character, CharacterInListDTO> characterMapper, 
            IMapper<Comic, ComicInListDTO> comicMaper, 
            IMapper<Character, CharacterDetailDTO> characterDetailMapper, 
            IMapper<Comic, ComicDetailDTO> comicDetailMapper)
        {
            this.comicRepository = comicRepository;
            this.characterRepository = characterRepository;
            this.characterMapper = characterMapper;
            this.comicMaper = comicMaper;
            this.characterDetailMapper = characterDetailMapper;
            this.comicDetailMapper = comicDetailMapper;
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

        public async Task<CharacterDetailDTO> GetCharacterById(int id)
        {
            var character = await characterRepository.FindById(id);
            return characterDetailMapper.Map(character);
        }

        public async Task<ComicDetailDTO> GetComicById(int id)
        {
            var comic = await comicRepository.FindById(id);
            return comicDetailMapper.Map(comic);
        }
    }
}
