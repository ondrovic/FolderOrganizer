namespace FolderOrganizer
{
    internal class Constents
    {
        public const string ExtensionPropertyKey = "extensions";
        public const string TypePropertyKey = "type";
        public const string BaseFolderPropertyKey = "base_folder";
        public const string RemoveAction = "remove";
        public const string AddAction = "add";
        public const int MinimumExtensionLengh = 2;
        public static string SettingsFileName = $@"{Environment.CurrentDirectory}\appSettings.json";
    }
}
