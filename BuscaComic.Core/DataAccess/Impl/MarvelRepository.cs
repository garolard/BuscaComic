using BuscaComic.Core.Infraestructure;
using BuscaComic.Core.Infraestructure.Impl;
using BuscaComic.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BuscaComic.Core.DataAccess.Impl
{
    public class MarvelRepository : IMarvelRepository
    {
        private readonly AppSettingsManager settings;
        private readonly IRestFacade facade;

        public MarvelRepository(AppSettingsManager settings, IRestFacade facade)
        {
            this.settings = settings;
            this.facade = facade;
        }

        public async Task<CharacterSearch> SearchCharactersByName(string name)
        {
            var ts = DateTime.Now.Ticks.ToString();
            var publicKey = settings["PublicKey"];
            var privateKey = settings["PrivateKey"];
            var hash = GenerateHash(ts, publicKey, privateKey);

            var url = $"{settings["BaseUrl"]}characters?ts={ts}&apikey={publicKey}&hash={hash}&" +
                $"name={Uri.EscapeUriString(name)}";

            var res = await facade.Get(url);
            return TryParseResponse<CharacterSearch>(res);
        }

        private string GenerateHash(string timestamp, string publicKey, string privateKey)
        {
            // ¿Quizá un Check.Require para que los parámetros no vengan vacíos?

            byte[] bytes = Encoding.UTF8.GetBytes(timestamp + privateKey + publicKey);
            var generator = MD5.Create();
            byte[] byteHash = generator.ComputeHash(bytes);
            return BitConverter.ToString(byteHash).ToLower().Replace("-", "");
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
            throw new InvalidOperationException(json["message"].ToString());
        }
    }
}
