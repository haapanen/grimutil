using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Haapanen.GrimUtil.Ui
{
    public class SettingsRepository
    {
        private readonly string _dataFolder;
        private readonly string _settingsPath;

        public SettingsRepository(string dataFolder)
        {
            _dataFolder = dataFolder;
            _settingsPath = Path.Combine(_dataFolder, FileNameConstants.Settings);
        }

        public Settings LoadSettings()
        {
            if (!File.Exists(_settingsPath))
            {
                var settings = new Settings();
                File.WriteAllText(_settingsPath, JsonConvert.SerializeObject(settings, Formatting.Indented));
                return settings;
            }

            return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(_settingsPath));
        }

        public void WriteSettings(Settings settings)
        {
            File.WriteAllText(_settingsPath, JsonConvert.SerializeObject(settings, Formatting.Indented));
        }

        public void BackupSettingsFile()
        {
            var contents = File.ReadAllText(_settingsPath);
            File.WriteAllText(_settingsPath + $"-{DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss")}.bak", contents);
        }
    }
}
