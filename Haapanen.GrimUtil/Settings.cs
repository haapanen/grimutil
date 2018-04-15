using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Haapanen.GrimUtil.Ui
{
    public class Settings 
    {
        public Keys StartTimerKey { get; set; } = Keys.F1;
        public Keys StopTimerKey { get; set; } = Keys.F2;
        public Keys ResetTimerKey { get; set; } = Keys.F3;
        public Keys ChangeRunKey { get; set; } = Keys.F5;

        public List<string> Runs { get; set; } = new List<string>();

        public Settings Clone()
        {
            return JsonConvert.DeserializeObject<Settings>(JsonConvert.SerializeObject(this));
        }
    }
}
