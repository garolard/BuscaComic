using BuscaComic.Core.Infraestructure;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace BuscaComic.Core
{
    public class AppSettingsManager : IAppSettingsManager
    {
        private static AppSettingsManager instance;
        private readonly JObject secrets;

        private const string Namespace = "BuscaComic.Core";
        private const string Filename = "appsettings.json";

        public AppSettingsManager()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AppSettingsManager)).Assembly;
            var stream = assembly.GetManifestResourceStream($"{Namespace}.{Filename}");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                secrets = JObject.Parse(json);
            }
        }

        public static AppSettingsManager Settings
        {
            get
            {
                if (instance == null)
                    instance = new AppSettingsManager();

                return instance;
            }
        }

        public string this[string key]
        {
            get
            {
                try
                {
                    JToken node = secrets[key];
                    return node.ToString();
                }
                catch (Exception)
                {
                    Debug.WriteLine($"Imposible encontrar el secreto con clave '{key}'");
                    return string.Empty;
                }
            }
        }
    }
}
