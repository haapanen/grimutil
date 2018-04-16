using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Haapanen.GrimUtil.Ui.Entities
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
