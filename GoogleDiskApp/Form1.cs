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
using Google.Apis.Upload;

namespace GoogleDiskApp
{
    public partial class Form1 : Form
    {
        private List<Sheaf> filesList;
        private ProgressReporter _progressReporter;
        private GoogleDriveUpload _googleDriveUpload;
        private object _syncObj = new object();

        protected readonly Action<Control, Action> _invoke = (ctrl, action) =>
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke((MethodInvoker)delegate
                {
                    action();
                });
            }
            else
            {
                action();
            }
        };

        public Form1()
        {
            InitializeComponent();
            aktualizujPlikŹródłowyToolStripMenuItem.Click += AktualizujPlikŹródłowyToolStripMenuItem_Click;

            _progressReporter = InitializeProgressReporter();

            _googleDriveUpload = new GoogleDriveUpload(_progressReporter);
        }

        private ProgressReporter InitializeProgressReporter()
        {
            Action<ProgressReporter.ProgressReportArgs> reportTotal = args =>
            {
                lock (_syncObj)
                {
                    _invoke(progressBarAll, () =>
                    {
                        // co ma się zdarzyc na kontrolce
                        progressBarAll.Value = args.Percent;
                        progressBarAll.Text = args.Current != 0 && args.Total != 0
                            ? $"pozycja: {args.Current} z {args.Total}"
                            : "";
                    });
                }
            };

            Action<ProgressReporter.ProgressReportArgs> reportPartial = args =>
            {
                lock (_syncObj)
                {
                    _invoke(progressBar, () =>
                    {
                        progressBar.Value = args.Percent;
                        progressBar.Text = args.Current != 0 && args.Total != 0
                            ? $"Chapter: {args.Current} of {args.Total}"
                            : "";
                    });
                }
            };

            return new ProgressReporter(reportPartial, reportTotal);
        }

        private void AktualizujPlikŹródłowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateFile("Czy na pewno chcesz zaktualizować plik źródłowy?",filesList);
        }

        private void wyszukajZmodyfikowanePlikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Sheaf> allFiles = DataManipulations.GetListOfFiles();
            string filePath = Environment.CurrentDirectory + "\\list.txt";
            //var acualFileList = DataManipulations.ReadFromFile(filePath);

            //filesList = DataManipulations.CheckForModyfications(acualFileList, allFiles);

            checkedListBox.DataSource = filesList;
            checkedListBox.DisplayMember = "FullDataSet";
            uploadButton.Enabled = true;
            aktualizujPlikŹródłowyToolStripMenuItem.Enabled = true;
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

        private async void uploadButton_Click(object sender, EventArgs e)
        {
            uploadButton.Enabled = false;
            var uploadList = new List<Sheaf>();
            foreach (Sheaf file in checkedListBox.CheckedItems)
            {
                uploadList.Add(file);                
            }

            await _googleDriveUpload.UploadFile(uploadList);

            UpdateFile("Czy chcesz zaktualizować plik źródłowy?", uploadList);
        }

        private void UpdateFile(string textInMBox, List<Sheaf> fileList)
        {
            string text, caption;
            DialogResult dr = MessageBox.Show(textInMBox, "Uwaga!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                //DataManipulations.CreateFilesLog(fileList);

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (filesList == null || filesList.Count == 0)
            {
                filesList = DataManipulations.GetListOfFiles();
            }

            DataManipulations.UpdateFileLog(filesList);
        }
    }
}
