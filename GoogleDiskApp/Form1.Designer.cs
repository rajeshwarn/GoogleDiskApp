namespace GoogleDiskApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyszukajZmodyfikowanePlikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktualizujPlikŹródłowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zakończToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadButton = new System.Windows.Forms.Button();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressBarAll = new System.Windows.Forms.ProgressBar();
            this.checkAllButton = new System.Windows.Forms.Button();
            this.updateAllCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(741, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wyszukajZmodyfikowanePlikiToolStripMenuItem,
            this.aktualizujPlikŹródłowyToolStripMenuItem,
            this.zakończToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // wyszukajZmodyfikowanePlikiToolStripMenuItem
            // 
            this.wyszukajZmodyfikowanePlikiToolStripMenuItem.Name = "wyszukajZmodyfikowanePlikiToolStripMenuItem";
            this.wyszukajZmodyfikowanePlikiToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.wyszukajZmodyfikowanePlikiToolStripMenuItem.Text = "Wyszukaj zmodyfikowane pliki";
            this.wyszukajZmodyfikowanePlikiToolStripMenuItem.Click += new System.EventHandler(this.wyszukajZmodyfikowanePlikiToolStripMenuItem_Click);
            // 
            // aktualizujPlikŹródłowyToolStripMenuItem
            // 
            this.aktualizujPlikŹródłowyToolStripMenuItem.Enabled = false;
            this.aktualizujPlikŹródłowyToolStripMenuItem.Name = "aktualizujPlikŹródłowyToolStripMenuItem";
            this.aktualizujPlikŹródłowyToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.aktualizujPlikŹródłowyToolStripMenuItem.Text = "Aktualizuj plik źródłowy";
            // 
            // zakończToolStripMenuItem
            // 
            this.zakończToolStripMenuItem.Name = "zakończToolStripMenuItem";
            this.zakończToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.zakończToolStripMenuItem.Text = "Zakończ";
            this.zakończToolStripMenuItem.Click += new System.EventHandler(this.zakończToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autorToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // autorToolStripMenuItem
            // 
            this.autorToolStripMenuItem.Name = "autorToolStripMenuItem";
            this.autorToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.autorToolStripMenuItem.Text = "Autor";
            this.autorToolStripMenuItem.Click += new System.EventHandler(this.autorToolStripMenuItem_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Enabled = false;
            this.uploadButton.Location = new System.Drawing.Point(529, 382);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 53);
            this.uploadButton.TabIndex = 1;
            this.uploadButton.Text = "Prześlij dane";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(12, 27);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(592, 349);
            this.checkedListBox.TabIndex = 2;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 382);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(511, 23);
            this.progressBar.TabIndex = 3;
            // 
            // progressBarAll
            // 
            this.progressBarAll.Location = new System.Drawing.Point(12, 411);
            this.progressBarAll.Name = "progressBarAll";
            this.progressBarAll.Size = new System.Drawing.Size(511, 23);
            this.progressBarAll.TabIndex = 4;
            // 
            // checkAllButton
            // 
            this.checkAllButton.Location = new System.Drawing.Point(610, 27);
            this.checkAllButton.Name = "checkAllButton";
            this.checkAllButton.Size = new System.Drawing.Size(119, 37);
            this.checkAllButton.TabIndex = 5;
            this.checkAllButton.Text = "Zaznacz wszystko";
            this.checkAllButton.UseVisualStyleBackColor = true;
            this.checkAllButton.Click += new System.EventHandler(this.checkAllButton_Click);
            // 
            // updateAllCheckBox
            // 
            this.updateAllCheckBox.AutoSize = true;
            this.updateAllCheckBox.Location = new System.Drawing.Point(610, 71);
            this.updateAllCheckBox.Name = "updateAllCheckBox";
            this.updateAllCheckBox.Size = new System.Drawing.Size(132, 17);
            this.updateAllCheckBox.TabIndex = 6;
            this.updateAllCheckBox.Text = "Zaktualizuj o wszystko";
            this.updateAllCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 440);
            this.Controls.Add(this.updateAllCheckBox);
            this.Controls.Add(this.checkAllButton);
            this.Controls.Add(this.progressBarAll);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zakończToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyszukajZmodyfikowanePlikiToolStripMenuItem;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ProgressBar progressBarAll;
        private System.Windows.Forms.ToolStripMenuItem aktualizujPlikŹródłowyToolStripMenuItem;
        private System.Windows.Forms.Button checkAllButton;
        private System.Windows.Forms.CheckBox updateAllCheckBox;
    }
}

