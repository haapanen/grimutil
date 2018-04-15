using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haapanen.GrimUtil.Ui
{
    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }

        private int _count;
        public string Name { get; }

        public int Count
        {
            get => _count;
            set => _count = Math.Max(value, 0);
        }
    }
}
