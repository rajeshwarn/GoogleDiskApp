using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDiskApp.Files_Stuff
{
    interface IProggressReporter
    {
        void ReportPartial(long current, long count);
        void ReportTotal(long current, long count, int? percent=null);
    }
}
