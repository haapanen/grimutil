using System;

namespace Haapanen.GrimUtil.Ui.Entities
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
