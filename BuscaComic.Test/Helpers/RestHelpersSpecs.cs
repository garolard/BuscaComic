using BuscaComic.Core.Helpers;
using BuscaComic.Core.Infrastructure;
using BuscaComic.Core.Infrastructure.Impl;
using BuscaComic.Test.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BuscaComic.Test.Helpers
{
    public class RestHelpersSpecs
    {
        private readonly AppSettingsManager settingsManager;
        private readonly RestHelpers helpers;

        public RestHelpersSpecs()
        {
            this.settingsManager = new AppSettingsManagerFake();
            this.helpers = new RestHelpers(settingsManager);
        }

        [Fact]
        public void Should_Build_A_Valid_Api_Url()
        {
            var url = helpers.GetApiUrl("characters", new Dictionary<string, object>
            {
                { "name", "Captain America" }
            });

            // Hace falta un sistema para hacer fakes sobre el tiempo para que los ticks sean
            // los mismos aqui que en la llamada a GetApiUrl de más arriba
            var ts = DateTime.Now.Ticks.ToString();
            var publicKey = settingsManager["PublicKey"];
            var privateKey = settingsManager["PrivateKey"];

            var hash = RestHelpers.GenerateHash(ts, publicKey, privateKey);
            Assert.Equal(
                $"{settingsManager["BaseUrl"]}characters?ts={ts}&apikey={publicKey}&hash={hash}&name='Captain%20America",
                url);
        }
    }
}
