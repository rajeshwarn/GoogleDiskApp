using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDiskApp.Files_Stuff
{
    class Sheaf
    {
        private string path, name, folderID;
        private DateTime lastModyfication;

        public Sheaf(string path, string name, DateTime lastModyfication)
        {
            this.path = path;
            this.name = name;
            this.lastModyfication = lastModyfication;
        }

        public Sheaf()
        {
            
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public string FolderID
        {
            get { return folderID; }
            set { folderID = value; }
        }

        public string Name {
            get
            {   
                int indexOfDot = name.IndexOf(".", StringComparison.Ordinal);
                return name.Substring(0, indexOfDot); 
            }
            set { name = value; }
        }

        public DateTime LastModyfication
        {
            get { return lastModyfication;}
            set { lastModyfication = value; }
        }

        public List<string> Parents()
        {
            return new List<string>() {folderID};
        }

        public string FullDataSet
        {
            get
            {
                return "Nazwa pliku: " + Name + " | Ostatnia modyfikacja: " + LastModyfication + " | Ścieżka: " + Path; 
            }
        }
    }
}
