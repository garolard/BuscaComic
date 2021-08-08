using BuscaComic.Core.Helpers;
using BuscaComic.Core.Infrastructure;
using BuscaComic.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuscaComic.Core.DataAccess.Impl
{
    public class ComicRepository : IComicRepository
    {
        private readonly IRestFacade facade;
        private readonly RestHelpers helpers;

        public ComicRepository(IRestFacade facade, RestHelpers helpers)
        {
            this.facade = facade;
            this.helpers = helpers;
        }

        public async Task<Comic[]> SearchComicsByName(string name)
        {
            var url = helpers.GetApiUrl("comics", new Dictionary<string, object>
            {
                { "title", name }
            });

            var res = await facade.Get(url);
            var apiObject = helpers.TryParseResponse<ApiResponseWrapper<Comic>>(res);
            return apiObject.Data.Results;
        }

        public async Task<Comic> FindById(int id)
        {
            var url = helpers.GetApiUrl($"comics/{id}");

            var res = await facade.Get(url);
            var apiObject = helpers.TryParseResponse<ApiResponseWrapper<Comic>>(res);
            return apiObject.Data.Results[0];
        }
    }
}
