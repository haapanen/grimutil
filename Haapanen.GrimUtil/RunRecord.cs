using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haapanen.GrimUtil.Ui
{
    public class RunRecord
    {
        public string Run { get; set; }
        public TimeSpan Duration { get; set; }
        public List<Item> Items { get; set; }

        public string ToSpreadsheet()
        {
            return Duration.ToString("g", CultureInfo.InvariantCulture) + "\t" + string.Join("\t", Items.Select(i => i.Count));
        }
    }
}
