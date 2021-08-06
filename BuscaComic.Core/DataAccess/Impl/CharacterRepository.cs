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
            var apiObject = TryParseResponse<ApiResponseWrapper<Character>>(res);
            return apiObject.Data.Results;
        }

        private T TryParseResponse<T>(string res)
        {
            var json = JObject.Parse(res);
            if (json["code"].ToString() != "200")
                TranslateAndThrowError(json);

            return JsonConvert.DeserializeObject<T>(res);
        }

        private void TranslateAndThrowError(JObject json)
        {
            if (json.ContainsKey("status"))
                throw new InvalidOperationException(json["status"].ToString());

            if (json.ContainsKey("message"))
                throw new InvalidOperationException(json["message"].ToString());
        }
    }
}
