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

namespace GoogleDiskApp
{
    public partial class Form1 : Form
    {
        private List<Sheaf> modList;
        public static string Path;
        public Form1()
        {
            InitializeComponent();
        }

        private void wyszukajZmodyfikowanePlikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Sheaf> allFiles = DataManipulations.GetListOfFiles();
            string fileName = Environment.CurrentDirectory + "\\list.txt";
            List<Sheaf> log = DataManipulations.ReadFromFile(fileName);
            modList = DataManipulations.CheckForModyfications(log, allFiles);
            checkedListBox.DataSource = modList;
            checkedListBox.DisplayMember = "FullDataSet";
            uploadButton.Enabled = true;
        }

        private void aktualizujPlikŹródłowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text, caption;
            DialogResult dr = MessageBox.Show("Czy na pewno chcesz zaktualizować plik źródłowy?", "Uwaga!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                List<Sheaf> allFiles = DataManipulations.GetListOfFiles();
                DataManipulations.UpdateFileLog(allFiles, modList);

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

        private void button1_Click(object sender, EventArgs e)
        {
            modList = GoogleDriveUpload.UploadFile(modList);
            //GoogleDriveUpload.Test();
        }
    }
}
