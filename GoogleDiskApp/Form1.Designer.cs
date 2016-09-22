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
            this.zakończToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edytujŚcieżkęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daneUżytkownikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktualizujPlikŹródłowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyświetlPomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadButton = new System.Windows.Forms.Button();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressBarAll = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.opcjeToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wyszukajZmodyfikowanePlikiToolStripMenuItem,
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
            // zakończToolStripMenuItem
            // 
            this.zakończToolStripMenuItem.Name = "zakończToolStripMenuItem";
            this.zakończToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.zakończToolStripMenuItem.Text = "Zakończ";
            this.zakończToolStripMenuItem.Click += new System.EventHandler(this.zakończToolStripMenuItem_Click);
            // 
            // opcjeToolStripMenuItem
            // 
            this.opcjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edytujŚcieżkęToolStripMenuItem,
            this.daneUżytkownikaToolStripMenuItem,
            this.aktualizujPlikŹródłowyToolStripMenuItem});
            this.opcjeToolStripMenuItem.Name = "opcjeToolStripMenuItem";
            this.opcjeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.opcjeToolStripMenuItem.Text = "Opcje";
            // 
            // edytujŚcieżkęToolStripMenuItem
            // 
            this.edytujŚcieżkęToolStripMenuItem.Name = "edytujŚcieżkęToolStripMenuItem";
            this.edytujŚcieżkęToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.edytujŚcieżkęToolStripMenuItem.Text = "Edytuj ścieżkę";
            this.edytujŚcieżkęToolStripMenuItem.Click += new System.EventHandler(this.edytujŚcieżkęToolStripMenuItem_Click);
            // 
            // daneUżytkownikaToolStripMenuItem
            // 
            this.daneUżytkownikaToolStripMenuItem.Name = "daneUżytkownikaToolStripMenuItem";
            this.daneUżytkownikaToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.daneUżytkownikaToolStripMenuItem.Text = "Dane użytkownika";
            // 
            // aktualizujPlikŹródłowyToolStripMenuItem
            // 
            this.aktualizujPlikŹródłowyToolStripMenuItem.Name = "aktualizujPlikŹródłowyToolStripMenuItem";
            this.aktualizujPlikŹródłowyToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aktualizujPlikŹródłowyToolStripMenuItem.Text = "Aktualizuj plik źródłowy";
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wyświetlPomocToolStripMenuItem,
            this.autorToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // wyświetlPomocToolStripMenuItem
            // 
            this.wyświetlPomocToolStripMenuItem.Name = "wyświetlPomocToolStripMenuItem";
            this.wyświetlPomocToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.wyświetlPomocToolStripMenuItem.Text = "Wyświetl Pomoc";
            // 
            // autorToolStripMenuItem
            // 
            this.autorToolStripMenuItem.Name = "autorToolStripMenuItem";
            this.autorToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 468);
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
        private System.Windows.Forms.ToolStripMenuItem opcjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edytujŚcieżkęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daneUżytkownikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aktualizujPlikŹródłowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyświetlPomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyszukajZmodyfikowanePlikiToolStripMenuItem;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ProgressBar progressBarAll;
    }
}

