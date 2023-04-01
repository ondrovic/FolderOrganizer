using Newtonsoft.Json;

namespace FolderOrganizer
{
    internal class Models
    {
        private partial class Settings
        {
            [JsonProperty(Constents.ExtensionPropertyKey)]
            public Extension[] Extensions { get; set; } = default!;
        }

        internal partial class Extension
        {
            [JsonProperty(Constents.TypePropertyKey)]
            public string Type { get; set; } = default!;
            [JsonProperty(Constents.BaseFolderPropertyKey)]
            public string BaseFolder { get; set; } = default!;
        }

        public static IEnumerable<Extension> SupportedExtensions()
        {
            Settings? settings = null;
            if (Utilities.SettingsFileExists(Constents.SettingsFileName))
            {
                using StreamReader reader = File.OpenText(Constents.SettingsFileName);
                settings = JsonConvert.DeserializeObject<Settings>(reader.ReadToEnd());
            }

            return settings?.Extensions ?? Enumerable.Empty<Extension>();
        }
    }
}
