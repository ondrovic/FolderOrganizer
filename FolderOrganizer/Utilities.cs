using Newtonsoft.Json.Linq;


namespace FolderOrganizer
{

    /// <summary>
    /// This class provides utility methods for various operations.
    /// </summary>
    internal class Utilities
    {
        /// <summary>
        /// Checks if the settings file exists at the given file path.
        /// </summary>
        /// <param name="filePath">The file path of the settings file.</param>
        /// <returns>True if the settings file exists, false otherwise.</returns>
        public static bool SettingsFileExists(string filePath)
        {
            return File.Exists(filePath);
        }


        // This method enables or disables a button based on the content of a text box.
        public static void IsButtonEnabled(Button button, TextBox textBox)
        {
            if (button != null && textBox != null)
            {
                button.Enabled = !string.IsNullOrWhiteSpace(textBox.Text);
            }
        }

        /// <summary>
        /// This method enables or disables a button based on the length of the text in a textbox.
        /// </summary>
        /// <param name="button">The button to enable or disable.</param>
        /// <param name="textBox">The textbox to check the length of.</param>
        /// <param name="minLength">The minimum length of the text in the textbox for the button to be enabled.</param>
        public static void IsButtonEnabled(Button button, TextBox textBox, int minLength)
        {
            button.Enabled = textBox.Text.Length >= minLength;
        }

        /// <summary>
        /// This method enables a button if there is at least one item selected in a list box.
        /// </summary>
        public static void IsButtonEnabled(Button button, ListBox listBox) => button.Enabled = listBox.SelectedIndices.Count > 0;

        /// <summary>
        /// This method enables or disables a TextBox based on the Enabled property of a Button.
        /// </summary>
        public static void IsChildTextBoxEnabled(Button parentButton, TextBox childTextBox) => childTextBox.Enabled = parentButton.Enabled;

        /// <summary>
        /// Gets the base folder name from the textbox or the item if the textbox is empty.
        /// </summary>
        /// <param name="textBox">The textbox to get the base folder name from.</param>
        /// <param name="item">The item to use if the textbox is empty.</param>
        /// <returns>The base folder name.</returns>
        public static string? GetBaseFolderName(TextBox textBox, string? item)
        {
            return string.IsNullOrEmpty(textBox.Text) ? item : textBox.Text;
        }

        /// <summary>
        /// Clears the text of the given TextBox.
        /// </summary>
        public static void ClearTextBoxText(TextBox textBox) => textBox.Text = string.Empty;

        /// <summary>
        /// Clears the contents of the specified TextBox.
        /// </summary>
        public static void ClearButtonClick(TextBox textBox) => textBox.Clear();

        /// <summary>
        /// Retrieves the content of a file as a JObject.
        /// </summary>
        /// <param name="fileName">The name of the file to retrieve.</param>
        /// <returns>The content of the file as a JObject, or null if the file does not exist.</returns>
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

        /// <summary>
        /// This method retrieves a JArray from a JObject based on the provided property key.
        /// </summary>
        /// <param name="jsonData">The JObject to search.</param>
        /// <param name="propertyKey">The property key to search for.</param>
        /// <returns>A JArray if found, otherwise null.</returns>
        private static JArray? GetFileContentArray(JObject jsonData, string propertyKey)
        {
            if (jsonData[propertyKey] is not JArray itemArray)
            {
                return null;
            }

            return itemArray;
        }

        /// <summary>
        /// Removes an item from a JArray based on a given item.
        /// </summary>
        private static void RemoveItem(JArray itemArray, object item)
        {
            var matchingItem = itemArray.FirstOrDefault(x => x["type"]?.ToString() == item.ToString());

            if (matchingItem == null)
            {
                return;
            }

            itemArray.Remove(matchingItem);
        }

        /// <summary>
        /// This method adds an item to the itemArray and updates the textBox with the new item.
        /// </summary>
        /// <param name="itemArray">The array to add the item to.</param>
        /// <param name="item">The item to add.</param>
        /// <param name="textBox">The textBox to update.</param>
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

        /// <summary>
        /// Writes the content of a JObject to a file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="jsonData">The JObject to write.</param>
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


        /// <summary>
        /// This method updates the setting file with the given parameters.
        /// </summary>
        /// <param name="fileName">The name of the file to be updated.</param>
        /// <param name="item">The item to be updated.</param>
        /// <param name="propertyKey">The key of the property to be updated.</param>
        /// <param name="actionType">The type of action to be performed.</param>
        /// <param name="listBox">The list box to be updated.</param>
        /// <param name="textBox">The text box to be updated.</param>
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

        /// <summary>
        /// Creates a folder if it does not already exist.
        /// </summary>
        /// <param name="folderPath">The path of the folder to create.</param>
        private static void CreateFolderIfMissing(string folderPath)
{
    if (!Directory.Exists(folderPath))
    {
        Directory.CreateDirectory(folderPath);
    }
}

/// <summary>
/// Moves a file from the specified file path to the specified folder path.
/// </summary>
/// <param name="filePath">The path of the file to move.</param>
/// <param name="folderPath">The path of the folder to move the file to.</param>
private static void MoveFileToFolder(string filePath, string folderPath)
{
    File.Move(filePath, Path.Combine(folderPath, Path.GetFileName(filePath)), true);
}

/// <summary>
/// This method returns a list of files with the specified extension from the given folder path.
/// </summary>
/// <param name="folderPath">The path of the folder to search.</param>
/// <param name="extension">The extension of the files to search for.</param>
/// <returns>A list of files with the specified extension.</returns>
private static List<string> GetFilesWithExtension(string folderPath, string extension)
{
    return Directory.GetFiles(folderPath, $"*.{extension}").ToList();
}

/// <summary>
/// This method organizes files with specific extensions into a base folder.
/// </summary>
/// <param name="folderPath">The path of the folder containing the files.</param>
/// <param name="baseFolder">The base folder to organize the files into.</param>
/// <param name="extension">The extension of the files to organize.</param>
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
