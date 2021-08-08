using BuscaComic.Core.Models;
using System.Threading.Tasks;

namespace BuscaComic.Core.DataAccess
{
    public interface IComicRepository
    {
        Task<Comic[]> SearchComicsByName(string name);
        Task<Comic> FindById(int id);
    }
}
