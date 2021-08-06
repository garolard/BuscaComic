using BuscaComic.Core.Infrastructure;
using BuscaComic.Core.Models;
using System;
using System.Threading.Tasks;

namespace BuscaComic.Core.DataAccess.Impl
{
    public class ComicRepository : IComicRepository
    {
        private readonly IRestFacade facade;

        public ComicRepository(IRestFacade facade)
        {
            this.facade = facade;
        }

        public async Task<Comic[]> SearchComicsByName(string name)
        {
            return null;
        }
    }
}
