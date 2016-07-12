using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDiskApp.Files_Stuff
{
    class Sheaf
    {
        private string path, name;
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

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public DateTime LastModyfication
        {
            get { return lastModyfication;}
            set { lastModyfication = value; }
        }

        public string FullDataSet
        {
            get
            {

                string subName = "";
                int indexOfDot = name.IndexOf(".", StringComparison.Ordinal);
                subName = name.Substring(0, indexOfDot);
                return "Nazwa pliku: " + subName + " | Ostatnia modyfikacja: " + LastModyfication + " | Ścieżka: " + Path; 
                
            }
        }
    }
}
