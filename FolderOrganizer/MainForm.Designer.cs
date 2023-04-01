namespace FolderOrganizer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            RunButton = new Button();
            folder_selection_groupbox = new GroupBox();
            ClearButton = new Button();
            FolderBrowseButton = new Button();
            SelectedFolderTextBox = new TextBox();
            FolderSelectionDialog = new FolderBrowserDialog();
            OrganizeProgressBar = new ProgressBar();
            extensions_groupbox = new GroupBox();
            ExtensionRemoveButton = new Button();
            ExtensionsListBox = new ListBox();
            add_new_extension_groupbox = new GroupBox();
            ExtensionBaseFolderOverrideTextBox = new TextBox();
            ExtensionAddTextBox = new TextBox();
            ExtensionAddButton = new Button();
            status_message_groupbox = new GroupBox();
            status_message_textbox = new TextBox();
            folder_selection_groupbox.SuspendLayout();
            extensions_groupbox.SuspendLayout();
            add_new_extension_groupbox.SuspendLayout();
            status_message_groupbox.SuspendLayout();
            SuspendLayout();
            // 
            // RunButton
            // 
            RunButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RunButton.Location = new Point(711, 374);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(75, 71);
            RunButton.TabIndex = 0;
            RunButton.Text = "run";
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_Click;
            // 
            // folder_selection_groupbox
            // 
            folder_selection_groupbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            folder_selection_groupbox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            folder_selection_groupbox.Controls.Add(ClearButton);
            folder_selection_groupbox.Controls.Add(FolderBrowseButton);
            folder_selection_groupbox.Controls.Add(SelectedFolderTextBox);
            folder_selection_groupbox.Location = new Point(12, 12);
            folder_selection_groupbox.Name = "folder_selection_groupbox";
            folder_selection_groupbox.Size = new Size(774, 67);
            folder_selection_groupbox.TabIndex = 1;
            folder_selection_groupbox.TabStop = false;
            folder_selection_groupbox.Text = "Folder";
            // 
            // ClearButton
            // 
            ClearButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ClearButton.Location = new Point(684, 38);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 2;
            ClearButton.Text = "clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // FolderBrowseButton
            // 
            FolderBrowseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FolderBrowseButton.Location = new Point(684, 11);
            FolderBrowseButton.Name = "FolderBrowseButton";
            FolderBrowseButton.Size = new Size(75, 23);
            FolderBrowseButton.TabIndex = 1;
            FolderBrowseButton.Text = "browse";
            FolderBrowseButton.UseVisualStyleBackColor = true;
            FolderBrowseButton.Click += FolderBrowseButton_Click;
            // 
            // SelectedFolderTextBox
            // 
            SelectedFolderTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SelectedFolderTextBox.BorderStyle = BorderStyle.None;
            SelectedFolderTextBox.Location = new Point(15, 22);
            SelectedFolderTextBox.Name = "SelectedFolderTextBox";
            SelectedFolderTextBox.ReadOnly = true;
            SelectedFolderTextBox.Size = new Size(643, 16);
            SelectedFolderTextBox.TabIndex = 0;
            SelectedFolderTextBox.TextChanged += SelectedFolderTextBox_TextChanged;
            // 
            // OrganizeProgressBar
            // 
            OrganizeProgressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            OrganizeProgressBar.Location = new Point(148, 338);
            OrganizeProgressBar.Name = "OrganizeProgressBar";
            OrganizeProgressBar.Size = new Size(638, 23);
            OrganizeProgressBar.TabIndex = 3;
            // 
            // extensions_groupbox
            // 
            extensions_groupbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            extensions_groupbox.Controls.Add(ExtensionRemoveButton);
            extensions_groupbox.Controls.Add(ExtensionsListBox);
            extensions_groupbox.Location = new Point(12, 85);
            extensions_groupbox.Name = "extensions_groupbox";
            extensions_groupbox.Size = new Size(130, 276);
            extensions_groupbox.TabIndex = 4;
            extensions_groupbox.TabStop = false;
            extensions_groupbox.Text = "Current Extensions";
            // 
            // ExtensionRemoveButton
            // 
            ExtensionRemoveButton.Location = new Point(6, 242);
            ExtensionRemoveButton.Name = "ExtensionRemoveButton";
            ExtensionRemoveButton.Size = new Size(118, 23);
            ExtensionRemoveButton.TabIndex = 1;
            ExtensionRemoveButton.Text = "remove";
            ExtensionRemoveButton.UseVisualStyleBackColor = true;
            ExtensionRemoveButton.Click += ExtensionRemoveButton_Click;
            // 
            // ExtensionsListBox
            // 
            ExtensionsListBox.BorderStyle = BorderStyle.None;
            ExtensionsListBox.DrawMode = DrawMode.OwnerDrawFixed;
            ExtensionsListBox.FormattingEnabled = true;
            ExtensionsListBox.ItemHeight = 15;
            ExtensionsListBox.Location = new Point(6, 22);
            ExtensionsListBox.Name = "ExtensionsListBox";
            ExtensionsListBox.SelectionMode = SelectionMode.MultiSimple;
            ExtensionsListBox.Size = new Size(118, 210);
            ExtensionsListBox.Sorted = true;
            ExtensionsListBox.TabIndex = 0;
            ExtensionsListBox.DrawItem += ExtensionsListBoxDrawItems;
            ExtensionsListBox.SelectedValueChanged += ExtensionsListBox_SelectedValueChanged;
            // 
            // add_new_extension_groupbox
            // 
            add_new_extension_groupbox.Controls.Add(ExtensionBaseFolderOverrideTextBox);
            add_new_extension_groupbox.Controls.Add(ExtensionAddTextBox);
            add_new_extension_groupbox.Controls.Add(ExtensionAddButton);
            add_new_extension_groupbox.Location = new Point(148, 85);
            add_new_extension_groupbox.Name = "add_new_extension_groupbox";
            add_new_extension_groupbox.Size = new Size(396, 98);
            add_new_extension_groupbox.TabIndex = 5;
            add_new_extension_groupbox.TabStop = false;
            add_new_extension_groupbox.Text = "Add New Extension";
            // 
            // ExtensionBaseFolderOverrideTextBox
            // 
            ExtensionBaseFolderOverrideTextBox.BorderStyle = BorderStyle.None;
            ExtensionBaseFolderOverrideTextBox.Location = new Point(200, 22);
            ExtensionBaseFolderOverrideTextBox.Name = "ExtensionBaseFolderOverrideTextBox";
            ExtensionBaseFolderOverrideTextBox.PlaceholderText = "extentions storage path (optional)";
            ExtensionBaseFolderOverrideTextBox.Size = new Size(188, 16);
            ExtensionBaseFolderOverrideTextBox.TabIndex = 2;
            // 
            // ExtensionAddTextBox
            // 
            ExtensionAddTextBox.BorderStyle = BorderStyle.None;
            ExtensionAddTextBox.Location = new Point(6, 22);
            ExtensionAddTextBox.Name = "ExtensionAddTextBox";
            ExtensionAddTextBox.PlaceholderText = "extension to add";
            ExtensionAddTextBox.Size = new Size(188, 16);
            ExtensionAddTextBox.TabIndex = 1;
            ExtensionAddTextBox.TextChanged += ExtensionAddTextBox_TextChanged;
            // 
            // ExtensionAddButton
            // 
            ExtensionAddButton.Location = new Point(6, 69);
            ExtensionAddButton.Name = "ExtensionAddButton";
            ExtensionAddButton.Size = new Size(382, 23);
            ExtensionAddButton.TabIndex = 0;
            ExtensionAddButton.Text = "add";
            ExtensionAddButton.UseVisualStyleBackColor = true;
            ExtensionAddButton.Click += ExtensionAddButton_Click;
            // 
            // status_message_groupbox
            // 
            status_message_groupbox.Controls.Add(status_message_textbox);
            status_message_groupbox.Location = new Point(12, 367);
            status_message_groupbox.Name = "status_message_groupbox";
            status_message_groupbox.Size = new Size(693, 78);
            status_message_groupbox.TabIndex = 6;
            status_message_groupbox.TabStop = false;
            status_message_groupbox.Text = "Status Messages";
            status_message_groupbox.Visible = false;
            // 
            // status_message_textbox
            // 
            status_message_textbox.BorderStyle = BorderStyle.None;
            status_message_textbox.Location = new Point(6, 22);
            status_message_textbox.Multiline = true;
            status_message_textbox.Name = "status_message_textbox";
            status_message_textbox.ReadOnly = true;
            status_message_textbox.Size = new Size(681, 43);
            status_message_textbox.TabIndex = 0;
            status_message_textbox.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(status_message_groupbox);
            Controls.Add(add_new_extension_groupbox);
            Controls.Add(extensions_groupbox);
            Controls.Add(OrganizeProgressBar);
            Controls.Add(folder_selection_groupbox);
            Controls.Add(RunButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Folder Organizer";
            Load += MainForm_Load;
            folder_selection_groupbox.ResumeLayout(false);
            folder_selection_groupbox.PerformLayout();
            extensions_groupbox.ResumeLayout(false);
            add_new_extension_groupbox.ResumeLayout(false);
            add_new_extension_groupbox.PerformLayout();
            status_message_groupbox.ResumeLayout(false);
            status_message_groupbox.PerformLayout();
            ResumeLayout(false);
        }

        private void ExtensionsListBoxDrawItems(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                string text = ExtensionsListBox.Items[e.Index].ToString();
                SizeF textSize = e.Graphics.MeasureString(text, ExtensionsListBox.Font);

                float x = (e.Bounds.Width - textSize.Width) / 2;
                float y = (e.Bounds.Height - textSize.Height) / 2;

                e.Graphics.DrawString(text, ExtensionsListBox.Font, SystemBrushes.ControlText, e.Bounds.Left + x, e.Bounds.Top + y);
            }

            e.DrawFocusRectangle();
        }

        #endregion

        private Button RunButton;
        private GroupBox folder_selection_groupbox;
        private FolderBrowserDialog FolderSelectionDialog;
        private Button FolderBrowseButton;
        private TextBox SelectedFolderTextBox;
        private ProgressBar OrganizeProgressBar;
        private GroupBox extensions_groupbox;
        private Button ExtensionRemoveButton;
        private GroupBox add_new_extension_groupbox;
        private Button ExtensionAddButton;
        private TextBox ExtensionAddTextBox;
        private Button ClearButton;
        private GroupBox status_message_groupbox;
        private TextBox status_message_textbox;
        private ListBox ExtensionsListBox;
        internal TextBox ExtensionBaseFolderOverrideTextBox;
    }
}