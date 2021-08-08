using BuscaComic.Core.Helpers;
using BuscaComic.Core.Infrastructure;
using BuscaComic.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuscaComic.Core.DataAccess.Impl
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IRestFacade facade;
        private readonly RestHelpers helpers;

        public CharacterRepository(IRestFacade facade, RestHelpers helpers)
        {
            this.facade = facade;
            this.helpers = helpers;
        }

        public async Task<Character[]> SearchCharactersByName(string name)
        {
            var url = helpers.GetApiUrl("characters", new Dictionary<string, object>
            {
                { "name", name }
            });

            var res = await facade.Get(url);
            var apiObject = helpers.TryParseResponse<ApiResponseWrapper<Character>>(res);
            return apiObject.Data.Results;
        }

        public async Task<Character> FindById(int id)
        {
            var url = helpers.GetApiUrl($"characters/{id}");

            var res = await facade.Get(url);
            var apiObject = helpers.TryParseResponse<ApiResponseWrapper<Character>>(res);
            return apiObject.Data.Results[0];
        }
    }
}
