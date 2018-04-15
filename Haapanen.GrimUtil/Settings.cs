using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Haapanen.GrimUtil.Ui
{
    public class Settings 
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Keys StartTimerKey { get; set; } = Keys.F1;
        [JsonConverter(typeof(StringEnumConverter))]
        public Keys StopTimerKey { get; set; } = Keys.F2;
        [JsonConverter(typeof(StringEnumConverter))]
        public Keys ResetTimerKey { get; set; } = Keys.F5;
        [JsonConverter(typeof(StringEnumConverter))]
        public Keys ChangeRunKey { get; set; } = Keys.F6;
        [JsonConverter(typeof(StringEnumConverter))]
        public Keys SelectPreviousItemKey { get; set; } = Keys.F3;
        [JsonConverter(typeof(StringEnumConverter))]
        public Keys SelectedNextItemKey { get; set; } = Keys.F4;
        [JsonConverter(typeof(StringEnumConverter))]
        public Keys IncrementCurrentItemKey { get; set; } = Keys.Add;
        [JsonConverter(typeof(StringEnumConverter))]
        public Keys DecrementCurrentItemKey { get; set; } = Keys.Subtract;

        public List<Run> Runs { get; set; } = new List<Run>();

        public Settings Clone()
        {
            return JsonConvert.DeserializeObject<Settings>(JsonConvert.SerializeObject(this));
        }
    }
}
