using System.Windows.Forms;

namespace TextSearch
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            progressBarFileLoading = new ProgressBar();
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            labelLoadingFile = new Label();
            textBoxResults = new TextBox();
            textBoxDirectory = new TextBox();
            buttonBrowse = new Button();
            label1 = new Label();
            label2 = new Label();
            radioButtonPrefix = new RadioButton();
            radioButtonSuffix = new RadioButton();
            textBoxSuffix = new TextBox();
            textBoxPrefix = new TextBox();
            label3 = new Label();
            label4 = new Label();
            listBoxFiles = new ListBox();
            checkBoxShutDown = new CheckBox();
            label5 = new Label();
            textBoxLineCount = new TextBox();
            SuspendLayout();
            // 
            // progressBarFileLoading
            // 
            progressBarFileLoading.Location = new Point(11, 612);
            progressBarFileLoading.Name = "progressBarFileLoading";
            progressBarFileLoading.Size = new Size(1238, 29);
            progressBarFileLoading.Style = ProgressBarStyle.Continuous;
            progressBarFileLoading.TabIndex = 0;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.None;
            textBoxSearch.Enabled = false;
            textBoxSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSearch.Location = new Point(233, 79);
            textBoxSearch.Multiline = true;
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.ScrollBars = ScrollBars.Vertical;
            textBoxSearch.Size = new Size(811, 91);
            textBoxSearch.TabIndex = 7;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.LightYellow;
            buttonSearch.Enabled = false;
            buttonSearch.FlatStyle = FlatStyle.Popup;
            buttonSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSearch.Location = new Point(1050, 86);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(200, 50);
            buttonSearch.TabIndex = 8;
            buttonSearch.Text = "SEARCH";
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += ButtonSearch_Click;
            // 
            // labelLoadingFile
            // 
            labelLoadingFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelLoadingFile.AutoSize = true;
            labelLoadingFile.Location = new Point(11, 644);
            labelLoadingFile.MaximumSize = new Size(1200, 50);
            labelLoadingFile.Name = "labelLoadingFile";
            labelLoadingFile.Size = new Size(121, 20);
            labelLoadingFile.TabIndex = 99;
            labelLoadingFile.Text = "Loading Text File";
            // 
            // textBoxResults
            // 
            textBoxResults.BackColor = Color.LightGray;
            textBoxResults.BorderStyle = BorderStyle.FixedSingle;
            textBoxResults.Location = new Point(226, 183);
            textBoxResults.MaxLength = int.MaxValue;
            textBoxResults.Multiline = true;
            textBoxResults.Name = "textBoxResults";
            textBoxResults.ReadOnly = true;
            textBoxResults.ScrollBars = ScrollBars.Both;
            textBoxResults.Size = new Size(1024, 424);
            textBoxResults.TabIndex = 99;
            textBoxResults.TabStop = false;
            textBoxResults.Text = resources.GetString("textBoxResults.Text");
            // 
            // textBoxDirectory
            // 
            textBoxDirectory.BackColor = Color.Gold;
            textBoxDirectory.BorderStyle = BorderStyle.None;
            textBoxDirectory.Enabled = false;
            textBoxDirectory.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxDirectory.Location = new Point(94, 12);
            textBoxDirectory.Name = "textBoxDirectory";
            textBoxDirectory.ReadOnly = true;
            textBoxDirectory.Size = new Size(950, 31);
            textBoxDirectory.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            buttonBrowse.BackColor = Color.Gold;
            buttonBrowse.FlatStyle = FlatStyle.Popup;
            buttonBrowse.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonBrowse.Location = new Point(1050, 12);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(200, 30);
            buttonBrowse.TabIndex = 2;
            buttonBrowse.Text = "Browse Directory";
            buttonBrowse.UseVisualStyleBackColor = false;
            buttonBrowse.Click += ButtonBrowse_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(992, 644);
            label1.Name = "label1";
            label1.Size = new Size(258, 20);
            label1.TabIndex = 10;
            label1.Text = "Code by Baird Rouan S. Buenaventura";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 12);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 99;
            label2.Text = "Directory:";
            // 
            // radioButtonPrefix
            // 
            radioButtonPrefix.AutoSize = true;
            radioButtonPrefix.Checked = true;
            radioButtonPrefix.Location = new Point(96, 49);
            radioButtonPrefix.Name = "radioButtonPrefix";
            radioButtonPrefix.Size = new Size(67, 24);
            radioButtonPrefix.TabIndex = 3;
            radioButtonPrefix.TabStop = true;
            radioButtonPrefix.Text = "Prefix";
            radioButtonPrefix.UseVisualStyleBackColor = true;
            radioButtonPrefix.CheckedChanged += RadioButtonPreFix_CheckedChanged;
            // 
            // radioButtonSuffix
            // 
            radioButtonSuffix.AutoSize = true;
            radioButtonSuffix.Location = new Point(677, 49);
            radioButtonSuffix.Name = "radioButtonSuffix";
            radioButtonSuffix.Size = new Size(67, 24);
            radioButtonSuffix.TabIndex = 5;
            radioButtonSuffix.TabStop = true;
            radioButtonSuffix.Text = "Suffix";
            radioButtonSuffix.UseVisualStyleBackColor = true;
            radioButtonSuffix.CheckedChanged += RadioButton2_CheckedChanged;
            // 
            // textBoxSuffix
            // 
            textBoxSuffix.BackColor = Color.Khaki;
            textBoxSuffix.BorderStyle = BorderStyle.None;
            textBoxSuffix.Enabled = false;
            textBoxSuffix.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSuffix.Location = new Point(750, 49);
            textBoxSuffix.Name = "textBoxSuffix";
            textBoxSuffix.Size = new Size(500, 31);
            textBoxSuffix.TabIndex = 6;
            textBoxSuffix.TextChanged += TextBoxPrefixSuffix_TextChanged;
            // 
            // textBoxPrefix
            // 
            textBoxPrefix.BackColor = Color.Khaki;
            textBoxPrefix.BorderStyle = BorderStyle.None;
            textBoxPrefix.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPrefix.Location = new Point(171, 49);
            textBoxPrefix.Name = "textBoxPrefix";
            textBoxPrefix.Size = new Size(500, 31);
            textBoxPrefix.TabIndex = 4;
            textBoxPrefix.Text = "ULOG";
            textBoxPrefix.TextChanged += TextBoxPrefixSuffix_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 49);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 99;
            label3.Text = "Filename:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(171, 79);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 99;
            label4.Text = "Search:";
            // 
            // listBoxFiles
            // 
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.ItemHeight = 20;
            listBoxFiles.Location = new Point(12, 183);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(208, 424);
            listBoxFiles.TabIndex = 100;
            listBoxFiles.SelectedIndexChanged += ListBoxFiles_SelectedIndexChanged;
            // 
            // checkBoxShutDown
            // 
            checkBoxShutDown.AutoSize = true;
            checkBoxShutDown.Checked = true;
            checkBoxShutDown.CheckState = CheckState.Checked;
            checkBoxShutDown.Location = new Point(1083, 142);
            checkBoxShutDown.Name = "checkBoxShutDown";
            checkBoxShutDown.Size = new Size(166, 24);
            checkBoxShutDown.TabIndex = 101;
            checkBoxShutDown.Text = "Exit When Complete";
            checkBoxShutDown.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 96);
            label5.Name = "label5";
            label5.Size = new Size(123, 40);
            label5.TabIndex = 102;
            label5.Text = "Lines Before&After\r\nsearch hit:\r\n";
            // 
            // textBoxLineCount
            // 
            textBoxLineCount.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLineCount.Location = new Point(12, 140);
            textBoxLineCount.Name = "textBoxLineCount";
            textBoxLineCount.Size = new Size(208, 30);
            textBoxLineCount.TabIndex = 103;
            textBoxLineCount.Text = "5000";
            textBoxLineCount.TextChanged += textBoxLineCount_TextChanged;
            // 
            // Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(1262, 673);
            Controls.Add(textBoxLineCount);
            Controls.Add(label5);
            Controls.Add(checkBoxShutDown);
            Controls.Add(listBoxFiles);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBoxPrefix);
            Controls.Add(textBoxSuffix);
            Controls.Add(radioButtonSuffix);
            Controls.Add(radioButtonPrefix);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonBrowse);
            Controls.Add(textBoxDirectory);
            Controls.Add(textBoxResults);
            Controls.Add(labelLoadingFile);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxSearch);
            Controls.Add(progressBarFileLoading);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Search";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOG Multiple File Search";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBarFileLoading;
        private TextBox textBoxSearch;
        private Button buttonSearch;
        private Label labelLoadingFile;
        private TextBox textBoxResults;
        private TextBox textBoxDirectory;
        private Button buttonBrowse;
        private Label label1;
        private Label label2;
        private RadioButton radioButtonPrefix;
        private RadioButton radioButtonSuffix;
        private TextBox textBoxSuffix;
        private TextBox textBoxPrefix;
        private Label label3;
        private Label label4;
        private ListBox listBoxFiles;
        private CheckBox checkBoxShutDown;
        private Label label5;
        private TextBox textBoxLineCount;
    }
}