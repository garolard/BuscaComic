using BuscaComic.Core.Models;
using System.Threading.Tasks;

namespace BuscaComic.Core.DataAccess
{
    public interface ICharacterRepository
    {
        Task<Character[]> SearchCharactersByName(string name);
    }
}
