using System;
using System.IO;
using Haapanen.GrimUtil.Ui.Entities;
using Newtonsoft.Json;

namespace Haapanen.GrimUtil.Ui.Data
{
    public class SettingsRepository
    {
        private readonly string _settingsPath;

        public SettingsRepository(string dataFolder)
        {
            _settingsPath = Path.Combine(dataFolder, FileNameConstants.Settings);
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
