using Newtonsoft.Json;

namespace FolderOrganizer
{

    /// <summary>
    /// This class contains the models used in the application.
    /// </summary>
    internal class Models
    {
        private partial class Settings
        {
            [JsonProperty(Constants.ExtensionPropertyKey)]
            public Extension[] Extensions { get; set; } = default!;
        }

        internal partial class Extension
        {
            [JsonProperty(Constants.TypePropertyKey)]
            public string Type { get; set; } = default!;
            [JsonProperty(Constants.BaseFolderPropertyKey)]
            public string BaseFolder { get; set; } = default!;
        }


        /// <summary>
        /// Returns a list of supported file extensions
        /// </summary>
        /// <returns>A list of supported file extensions</returns>
        public static IEnumerable<Extension> SupportedExtensions()
        {
            Settings? settings = null;
            if (Utilities.SettingsFileExists(Constants.SettingsFileName))
            {
                using StreamReader reader = File.OpenText(Constants.SettingsFileName);
                settings = JsonConvert.DeserializeObject<Settings>(reader.ReadToEnd());
            }

            return settings?.Extensions ?? Enumerable.Empty<Extension>();
        }
    }
}
