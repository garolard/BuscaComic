using BuscaComic.Core.Common.DBC;
using BuscaComic.Core.Infrastructure;
using BuscaComic.Core.Infrastructure.Impl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BuscaComic.Core.Helpers
{
    public class RestHelpers
    {
        private readonly AppSettingsManager settings;

        public RestHelpers() : this(AppSettingsManager.Instance)
        {
        }

        // Para tests
        public RestHelpers(AppSettingsManager settings)
        {
            this.settings = settings;
        }

        public string GetApiUrl(string endpoint, IDictionary<string, object> urlParams)
        {
            Check.Require(!string.IsNullOrEmpty(endpoint), "No se puede construir una URL de API válida sin un endpoint");

            var ts = DateTime.Now.Ticks.ToString();
            var publicKey = settings["PublicKey"];
            var privateKey = settings["PrivateKey"];
            var hash = GenerateHash(ts, publicKey, privateKey);

            var builder = new StringBuilder();

            foreach (var pair in urlParams)
            {
                builder
                    .Append(Uri.EscapeUriString(pair.Key))
                    .Append("=")
                    .Append(Uri.EscapeUriString(pair.Value.ToString()));

                if (!urlParams.Last().Equals(pair))
                    builder.Append("&");
            }

            return $"{settings["BaseUrl"]}{endpoint}?ts={ts}&apikey={publicKey}&hash={hash}&" +
                builder.ToString();
        }

        // public para los tests
        public static string GenerateHash(string timestamp, string publicKey, string privateKey)
        {
            Check.Require(!string.IsNullOrEmpty(timestamp));
            Check.Require(!string.IsNullOrEmpty(publicKey), "Hay que definir un PublicKey en appsettings.json");
            Check.Require(!string.IsNullOrEmpty(privateKey), "Hay que definir un PrivateKey en appsettings.json");

            byte[] bytes = Encoding.UTF8.GetBytes(timestamp + privateKey + publicKey);
            var generator = MD5.Create();
            byte[] byteHash = generator.ComputeHash(bytes);
            return BitConverter.ToString(byteHash).ToLower().Replace("-", "");
        }

        public T TryParseResponse<T>(string res)
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
