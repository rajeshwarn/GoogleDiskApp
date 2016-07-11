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
        }

        private void aktualizujPlikŹródłowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Sheaf> allFiles = DataManipulations.GetListOfFiles();
            DataManipulations.CreateFilesLog(allFiles);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
