using BuscaComic.Core.Common.DBC;
using BuscaComic.Core.Common.System;
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
        public void An_Endpoint_Must_Be_Provided()
        {
            Assert.Throws<PreconditionException>(() => helpers.GetApiUrl("", new Dictionary<string, object>()));
        }

        [Fact]
        public void Should_Build_A_Valid_Api_Url()
        {
            using (SystemTime.Custom(() => new DateTime(2021, 09, 08, 12, 0, 0, 0)))
            {
                var url = helpers.GetApiUrl("characters", new Dictionary<string, object>
                {
                    { "name", "Captain America" }
                });

                var ts = SystemTime.Now().Ticks.ToString();
                var publicKey = settingsManager["PublicKey"];
                var privateKey = settingsManager["PrivateKey"];

                var hash = RestHelpers.GenerateHash(ts, publicKey, privateKey);
                Assert.Equal(
                    $"{settingsManager["BaseUrl"]}characters?ts={ts}&apikey={publicKey}&hash={hash}&name=Captain%20America",
                    url);
            }            
        }
    }
}
