using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haapanen.GrimUtil.Ui
{
    public partial class FormMain : Form
    {
        private readonly KeyboardHook _hook = new KeyboardHook();

        private readonly string _appDataFolder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GrimUtil");
        private readonly SettingsRepository _settingsRepository;
        private Settings _settings;
        private TimerManager _timerManager = new TimerManager();
        private Timer _viewRefreshTimer = new Timer();
        private int _currentRun = 0;
        private List<string> _runs = new List<string>() { "Unknown run" };
        private List<RunRecord> _runRecords = new List<RunRecord>();

        public FormMain()
        {
            InitializeComponent();

            if (!Directory.Exists(_appDataFolder))
            {
                Directory.CreateDirectory(_appDataFolder);
            }
            _settingsRepository = new SettingsRepository(_appDataFolder);
            _settings = _settingsRepository.LoadSettings();

            InitializeKeyboardHook();
            ApplySettings(_settings);
            setupKeysToolStripMenuItem.Click += SetupKeysToolStripMenuItemOnClick;
            copyToClipboardButon.Click += CopyToClipboardButonOnClick;
            clearLogButton.Click += ClearLogButtonOnClick;
            _viewRefreshTimer.Interval = 100;
            _viewRefreshTimer.Tick += ViewRefreshTimerOnTick;
            _viewRefreshTimer.Start();
        }

        private void ClearLogButtonOnClick(object o, EventArgs eventArgs)
        {
            if (MessageBox.Show("Clear log?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _runRecords.Clear();
                logTextBox.Text = "";
            }
        }

        private void CopyToClipboardButonOnClick(object o, EventArgs eventArgs)
        {
            Clipboard.SetText(string.Join("\r\n", _runRecords.Select(r => r.Duration.ToString("g", CultureInfo.InvariantCulture))));
        }

        private void ViewRefreshTimerOnTick(object o, EventArgs eventArgs)
        {
            currentRunTimeLabel.Text = _timerManager.GetDuration(_runs[_currentRun]).ToString("g");
        }

        private void ApplySettings(Settings settings)
        {
            _timerManager.SetAvailableRuns(settings.Runs);
            SetupKeyboardHooks(settings);
            _runs = settings.Runs;
            if (!_runs.Any())
            {
                _runs = new List<string>() { "Unknown run" };
            }
            _currentRun = 0;
            UpdateCurrentRunLabel();
        }

        private void SetupKeysToolStripMenuItemOnClick(object o, EventArgs eventArgs)
        {
            var settingsDialog = new SettingsDialog(_settings);
            if (settingsDialog.ShowDialog() == DialogResult.OK)
            {
                _settings = settingsDialog.Settings;
                _settingsRepository.WriteSettings(settingsDialog.Settings);
                ApplySettings(_settings);
            }
        }

        private void SetupKeyboardHooks(Settings settings)
        {
            _hook.RemoveKeyboardHooks();
            _hook.SetKeyboardHook(settings.StartTimerKey, new HookCallbacks
            {
                OnKeyUp = OnStartTimerPress
            });
            _hook.SetKeyboardHook(settings.ResetTimerKey, new HookCallbacks
            {
                OnKeyUp = OnResetTimerPress
            });
            _hook.SetKeyboardHook(settings.StopTimerKey, new HookCallbacks
            {
                OnKeyUp = OnStopTimerPress
            });
            _hook.SetKeyboardHook(settings.ChangeRunKey, new HookCallbacks
            {
                OnKeyUp = OnChangeRunPress
            });
        }

        private void OnStartTimerPress()
        {
            _timerManager.StartTimer(_runs[_currentRun]);
        }

        private void OnResetTimerPress()
        {
            var currentRun = _runs[_currentRun];
            var duration = _timerManager.GetDuration(currentRun);
            _runRecords.Add(new RunRecord
            {
                Run = currentRun,
                Duration = _timerManager.GetDuration(currentRun)
            });
            logTextBox.Text = string.Format("{0}: {1}\r\n", currentRun, duration.ToString("g", CultureInfo.InvariantCulture)) + logTextBox.Text;
            _timerManager.ResetTimer(currentRun);
        }

        private void OnStopTimerPress()
        {
            _timerManager.StopTimer(_runs[_currentRun]);
        }

        private void OnChangeRunPress()
        {
            _currentRun = (_currentRun + 1) % _runs.Count;
            UpdateCurrentRunLabel();
        }

        private void UpdateCurrentRunLabel()
        {
            currentRunLabel.Text = _runs[_currentRun];
        }

        private void InitializeKeyboardHook()
        {
            _hook.Hook();
            this.Closing += (sender, args) => { _hook.Unhook(); };
        }
    }
}
