using BuscaComic.Core.Models;
using System.Threading.Tasks;

namespace BuscaComic.Core.DataAccess
{
    public interface IMarvelRepository
    {
        Task<CharacterSearch> SearchCharactersByName(string name);
    }
}
