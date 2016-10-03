using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDiskApp.Files_Stuff
{
    public class Sheaf
    {
        private string _path, _name, _folderId;
        private DateTime _lastModyfication;

        public Sheaf(string path, string name, DateTime lastModyfication)
        {
            _path = path;
            _name = name;
            _lastModyfication = lastModyfication;
        }

        public Sheaf()
        {
            
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public string FolderId
        {
            get { return _folderId; }
            set { _folderId = value; }
        }

        public string Name {
            get
            {
                int indexOfDot = _name.IndexOf(".", StringComparison.Ordinal);
                if (indexOfDot != -1)
                {
                    return _name.Substring(0, indexOfDot);
                }
                return _name;
            }
            set { _name = value; }
        }

        public DateTime LastModyfication
        {
            get { return _lastModyfication;}
            set { _lastModyfication = value; }
        }

        public List<string> Parents()
        {
            return new List<string>() {_folderId};
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
