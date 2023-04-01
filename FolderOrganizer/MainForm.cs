using Microsoft.VisualBasic;

namespace FolderOrganizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Utilities.IsButtonEnabled(RunButton, SelectedFolderTextBox);
            Utilities.IsButtonEnabled(ExtensionRemoveButton, ExtensionsListBox);
            Utilities.IsButtonEnabled(ExtensionAddButton, ExtensionAddTextBox);
            Utilities.IsButtonEnabled(ClearButton, SelectedFolderTextBox);
            Utilities.IsChildTextBoxEnabled(ExtensionAddButton, ExtensionBaseFolderOverrideTextBox);

            ExtensionsListBox.Items.AddRange(Models.SupportedExtensions().Select(e => e.Type).ToArray());
        }

        #region clicks

        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Utilities.ClearTextBoxText(SelectedFolderTextBox);
        }

        private void ExtensionAddButton_Click(object sender, EventArgs e)
        {
            Utilities.UpdateSettingFile(Constents.SettingsFileName, ExtensionAddTextBox.Text, Constents.ExtensionPropertyKey, Constents.AddAction, ExtensionsListBox, ExtensionBaseFolderOverrideTextBox);
            Utilities.ClearTextBoxText(ExtensionAddTextBox);
            Utilities.ClearTextBoxText(ExtensionBaseFolderOverrideTextBox);
            RunButton.Focus();
        }

        private void ExtensionRemoveButton_Click(object sender, EventArgs e)
        {
            Utilities.IsButtonEnabled(ExtensionRemoveButton, ExtensionsListBox);
            foreach (var item in ExtensionsListBox.SelectedItems.Cast<object>().ToList())
            {
                Utilities.UpdateSettingFile(Constents.SettingsFileName, item, Constents.ExtensionPropertyKey, Constents.RemoveAction, ExtensionsListBox, null);
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            OrganizeFolder();
        }

        #endregion

        #region changes
        private void SelectedFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Utilities.IsButtonEnabled(ClearButton, SelectedFolderTextBox);
            Utilities.IsButtonEnabled(RunButton, SelectedFolderTextBox);
        }

        private void ExtensionAddTextBox_TextChanged(object sender, EventArgs e)
        {
            Utilities.IsButtonEnabled(ExtensionAddButton, ExtensionAddTextBox, Constents.MinimumExtensionLengh);
            Utilities.IsChildTextBoxEnabled(ExtensionAddButton, ExtensionBaseFolderOverrideTextBox);
        }


        private void ExtensionsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Utilities.IsButtonEnabled(ExtensionRemoveButton, ExtensionsListBox);
        }
        #endregion


        private void FolderBrowserDialog()
        {
            DialogResult result = FolderSelectionDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                SelectedFolderTextBox.Text = FolderSelectionDialog.SelectedPath;
            }
        }

        private void OrganizeFolder()
        {
            var items = Models.SupportedExtensions();

            OrganizeProgressBar.Minimum = 0;
            OrganizeProgressBar.Maximum = items.Count();

            if (string.IsNullOrEmpty(SelectedFolderTextBox.Text))
            {
                return;
            }

            foreach (var extension in items)
            {
                Utilities.OrganizeFilesWithExtensions(SelectedFolderTextBox.Text, extension.BaseFolder, extension.Type);
                OrganizeProgressBar.Increment(1);
            }

            SelectedFolderTextBox.Text = string.Empty;
        }
    }
}