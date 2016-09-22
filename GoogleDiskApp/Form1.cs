using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleDiskApp.Files_Stuff;
using System.Web;

namespace GoogleDiskApp
{
    public partial class Form1 : Form
    {
        private List<Sheaf> modList;
        private List<Sheaf> log;
        public static string Path;
        public Form1()
        {
            InitializeComponent();
            aktualizujPlikŹródłowyToolStripMenuItem.Click += AktualizujPlikŹródłowyToolStripMenuItem_Click;
        }

        private void AktualizujPlikŹródłowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateFile("Czy na pewno chcesz zaktualizować plik źródłowy?");
        }

        private void wyszukajZmodyfikowanePlikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Sheaf> allFiles = DataManipulations.GetListOfFiles();
            string fileName = Environment.CurrentDirectory + "\\list.txt";
            log = DataManipulations.ReadFromFile(fileName);

            modList = DataManipulations.CheckForModyfications(log, allFiles);

            checkedListBox.DataSource = modList;
            checkedListBox.DisplayMember = "FullDataSet";
            uploadButton.Enabled = true;
        }
        
        private void edytujŚcieżkęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();

            Path = fbd.SelectedPath;
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Autor: Grzegorz Stysiak" + Environment.NewLine + "Email: stysiak.grzegorz@gmail.com";
            MessageBox.Show(text, "Autor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            modList.Clear();
            foreach (Sheaf file in checkedListBox.CheckedItems)
            {
                modList.Add(file);                
            }

            GoogleDriveUpload.UploadFile(modList);

            UpdateFile("Czy chcesz zaktualizować plik źródłowy?");
        }

        private void UpdateFile(string textInMBox)
        {
            string text, caption;
            DialogResult dr = MessageBox.Show(textInMBox, "Uwaga!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                DataManipulations.UpdateFileLog(log, modList);

                text = "Poprawnie zaktualizowałeś plik źródłowy";
                caption = "Aktualizacja";
            }
            else
            {
                text = "Nie zaktualizowałeś pliku źródłowego";
                caption = "Brak aktualizacji";
            }

            MessageBox.Show(text, caption, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
