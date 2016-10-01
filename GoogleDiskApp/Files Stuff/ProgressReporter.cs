using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDiskApp.Files_Stuff
{
    public class ProgressReporter : IProggressReporter
    {
        public class ProgressReportArgs
        {
            public ProgressReportArgs(long total, long current, int percent)
            {
                Total = total;
                Current = current;
                Percent = percent;
            }

            public long Total { get; private set; }
            public long Current { get; private set; }
            public int Percent { get; private set; }
        }

        private readonly Action<ProgressReportArgs> _setPartialProgress;
        //count, current, percent
        private readonly Action<ProgressReportArgs> _setTotalProgress;

        public ProgressReporter(Action<ProgressReportArgs> setPartialProgress, Action<ProgressReportArgs> setTotalProgress)
        {
            _setPartialProgress = setPartialProgress;
            _setTotalProgress = setTotalProgress;
        }


        private static int ToPercent(long count, long current)
        {
            return count > 0
                ? (int)((double)current / count * 100)
                : 0;
        }

        //te 2 metody wywołuje klasa z logiką, a one wywołują metody które zostały wstrzyknięte z UI ( InitializeProgressReporter )
        public void ReportPartial(long current, long count)
        {
            _setPartialProgress(new ProgressReportArgs(count, current, ToPercent(count, current)));
        }

        public void ReportTotal(long current, long count, int? percent = null)
        {
            _setTotalProgress(new ProgressReportArgs(count, current, percent ?? ToPercent(count, current)));
        }
    }
}
