using BuscaComic.Core.Infrastructure.Impl;
using Newtonsoft.Json.Linq;

namespace BuscaComic.Test.Infrastructure
{
    public class AppSettingsManagerFake : AppSettingsManager
    {
        private static AppSettingsManager instance;

        public AppSettingsManagerFake()
        {
            secrets = JObject.Parse(@"{
    'BaseUrl': 'http://mock.com/',
    'PublicKey': '1234',
    'PrivateKey': '5678'
}");
        }

        public static new AppSettingsManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new AppSettingsManagerFake();

                return instance;
            }
        }
    }
}
