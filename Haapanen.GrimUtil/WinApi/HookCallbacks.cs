using System;

namespace Haapanen.GrimUtil.Ui.WinApi
{
    public class HookCallbacks
    {
        public Action OnKeyDown { get; set; }
        public Action OnKeyUp { get; set; }
    }
}