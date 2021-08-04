using BuscaComic.Core.DTOs;
using System.Threading.Tasks;

namespace BuscaComic.Core.Services
{
    public interface ICharacterService
    {
        Task<CharacterDTO[]> SearchCharactersByName(string name);
    }
}
