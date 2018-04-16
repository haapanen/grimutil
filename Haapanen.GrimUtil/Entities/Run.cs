using System.Collections.Generic;

namespace Haapanen.GrimUtil.Ui.Entities
{
    public class Run
    {
        public string Name { get; set; }
        public List<string> TrackedItems { get; set; } = new List<string>();
    }
}
