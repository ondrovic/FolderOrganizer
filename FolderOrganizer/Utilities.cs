using Newtonsoft.Json.Linq;
using System.Windows.Forms;


namespace FolderOrganizer
{
    internal class Utilities
    {
        public static bool SettingsFileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public static void IsButtonEnabled(Button button, TextBox textBox)
        {
            if (button != null && textBox != null)
            {
                button.Enabled = !string.IsNullOrWhiteSpace(textBox.Text);
            }
        }

        public static void IsButtonEnabled(Button button, TextBox textBox, int minLength)
        {
            button.Enabled = textBox.Text.Length >= minLength;
        }

        public static void IsButtonEnabled(Button button, ListBox listBox) => button.Enabled = listBox.SelectedIndices.Count > 0;

        public static void IsChildTextBoxEnabled(Button parentButton, TextBox childTextBox) => childTextBox.Enabled = parentButton.Enabled;
        public static string? GetBaseFolderName(TextBox textBox, string? item)
        {
            return string.IsNullOrEmpty(textBox.Text) ? item : textBox.Text;
        }

        public static void ClearTextBoxText(TextBox textBox) => textBox.Text = string.Empty;
        public static void ClearButtonClick(TextBox textBox) => textBox.Clear();
        private static JObject? GetFileContent(string fileName)
        {
            try
            {
                if (!SettingsFileExists(fileName))
                {
                    return null;
                }

                var jsonData = JObject.Parse(File.ReadAllText(fileName));

                return jsonData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static JArray? GetFileContentArray(JObject jsonData, string propertyKey)
        {
            if (jsonData[propertyKey] is not JArray itemArray)
            {
                return null;
            }

            return itemArray;
        }

        private static void RemoveItem(JArray itemArray, object item)
        {
            var matchingItem = itemArray.FirstOrDefault(x => x["type"]?.ToString() == item.ToString());

            if (matchingItem == null)
            {
                return;
            }

            itemArray.Remove(matchingItem);
        }

        private static void AddItem(JArray itemArray, object item, TextBox textBox)
        {
            var matchingItem = itemArray.FirstOrDefault(x => x["type"]?.ToString() == item.ToString());

            if (matchingItem != null)
            {
                return;
            }

            var newItem = new JObject(
                new JProperty("type", item.ToString()),
                new JProperty("base_folder", GetBaseFolderName(textBox, item?.ToString())
            ));

            itemArray.Add(newItem);
        }

        private static void WriteFileContent(string fileName, JObject jsonData)
        {
            try
            {
                if (SettingsFileExists(fileName))
                {
                    File.WriteAllText(fileName, jsonData.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateSettingFile(string fileName, object item, string propertyKey, string actionType, ListBox listBox, TextBox textBox)
        {
            var jsonData = GetFileContent(fileName);

            if (jsonData == null)
            {
                return;
            }

            var extensionItemsArray = GetFileContentArray(jsonData, propertyKey);

            if (extensionItemsArray == null)
            {
                return;
            }

            if (actionType == Constants.RemoveAction)
            {
                RemoveItem(extensionItemsArray, item);
            }

            if (actionType == Constants.AddAction)
            {
                AddItem(extensionItemsArray, item, textBox);
            }

            WriteFileContent(fileName, jsonData);

            listBox.Items.Clear();
            
            foreach (var extensionItem in extensionItemsArray)
            {
                listBox.Items.Add(extensionItem[Constants.TypePropertyKey].ToString());
            }
        }

        private static void CreateFolderIfMissing(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private static void MoveFileToFolder(string filePath, string folderPath)
        {
            File.Move(filePath, Path.Combine(folderPath, Path.GetFileName(filePath)), true);
        }

        private static List<string> GetFilesWithExtension(string folderPath, string extension)
        {
            return Directory.GetFiles(folderPath, $"*.{extension}").ToList();
        }

        internal static void OrganizeFilesWithExtensions(string folderPath, string baseFolder, string extension)
        {
            string typeFolder = $@"{folderPath}\{baseFolder}\{extension}";

            CreateFolderIfMissing(typeFolder);

            List<string> files = GetFilesWithExtension(folderPath, extension);

            foreach (string file in files)
            {
                MoveFileToFolder(file, typeFolder);
            }
        }
    }
}
