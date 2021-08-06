using BuscaComic.Core.DataAccess;
using BuscaComic.Core.DTOs;
using BuscaComic.Core.Mappers;
using BuscaComic.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaComic.Core.Services.Impl
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository repository;
        private readonly IMapper<Character, CharacterInListDTO> mapper;

        public CharacterService(ICharacterRepository repository, IMapper<Character, CharacterInListDTO> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CharacterInListDTO[]> SearchCharactersByName(string name)
        {
            var result = await repository.SearchCharactersByName(name);
            return result.Select(mapper.Map).ToArray();
        }
    }
}
