using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDiskApp.Files_Stuff
{
    class ByteSize
    {
        
        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string ToPrettySize(long value, int decimalPlaces = 0)
        {
            var mag = (int)Math.Max(0, Math.Log(value, 1024));
            var adjustedSize = Math.Round(value / Math.Pow(1024, mag), decimalPlaces);
            return String.Format("{0} {1}", adjustedSize, SizeSuffixes[mag]);
        }
    }
}
