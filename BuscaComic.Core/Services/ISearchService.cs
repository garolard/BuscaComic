using BuscaComic.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuscaComic.Core.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<IElementInListDTO>> Search(string query);
    }
}
