using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDiskApp.Files_Stuff
{
    class Sheaf
    {
        public string path, name;
        public DateTime lastModyfication;

        public Sheaf(string path, string name, DateTime lastModyfication)
        {
            this.path = path;
            this.name = name;
            this.lastModyfication = lastModyfication;
        }
    }
}
