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
        private List<Sheaf> _fileList;
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
            UpdateFile("Czy na pewno chcesz zaktualizować plik źródłowy?",_fileList);
        }

        private void wyszukajZmodyfikowanePlikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var xmlFiles = DataManipulations.ReadFromXml();
            var actualFiles = DataManipulations.GetListOfFiles();

            _fileList = DataManipulations.CheckForModyfications(actualFiles, xmlFiles);

            checkedListBox.DataSource = _fileList;
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

            var uploadList = checkedListBox.CheckedItems.Cast<Sheaf>().ToList();

            await _googleDriveUpload.UploadFile(uploadList);

            string text = "Czy chcesz zaktualizować plik źródłowy?";
            if (updateAllCheckBox.Checked)
            {
                UpdateFile(text, _fileList);
            }
            else
            {
                UpdateFile(text, uploadList);
            }

            progressBarAll.Value = 0;
            progressBar.Value = 0;
        }

        private void UpdateFile(string textInMBox, List<Sheaf> fileList)
        {
            string text, caption;
            DialogResult dr = MessageBox.Show(textInMBox, "Uwaga!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                DataManipulations.UpdateXmlLog(fileList);

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

        private void checkAllButton_Click(object sender, EventArgs e)
        {
            IsListChecked = !_isListChecked;
        }

        private bool _isListChecked;
        public bool IsListChecked
        {
            get { return _isListChecked; }
            set
            {
                if (!_isListChecked)
                {
                    for (int i = 0, count = checkedListBox.Items.Count; i < count; i++)
                    {
                        checkedListBox.SetItemChecked(i, true);
                    }
                    checkAllButton.Text = "Odznacz wszystko";
                }
                else
                {
                    for (int i = 0, count = checkedListBox.Items.Count; i < count; i++)
                    {
                        checkedListBox.SetItemChecked(i, false);
                    }
                    checkAllButton.Text = "Zaznacz wszystko";
                }
                _isListChecked = value;
            }
        }
    }
}
