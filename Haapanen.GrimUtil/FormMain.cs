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
using Newtonsoft.Json;

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
        private List<Run> _runs = new List<Run>() { new Run() { Name = "Unknown run", TrackedItems = new List<string>() } };
        private List<RunRecord> _runRecords = new List<RunRecord>();
        private Dictionary<string, BindingList<Item>> _trackedItems = new Dictionary<string, BindingList<Item>>();

        public FormMain()
        {
            InitializeComponent();

            if (!Directory.Exists(_appDataFolder))
            {
                Directory.CreateDirectory(_appDataFolder);
            }
            _settingsRepository = new SettingsRepository(_appDataFolder);
            try
            {
                _settings = _settingsRepository.LoadSettings();
            }
            catch (JsonException e)
            {
                _settings = new Settings();
                _settingsRepository.BackupSettingsFile();
                _settingsRepository.WriteSettings(_settings);
            }

            InitializeKeyboardHook();
            ApplySettings(_settings);
            setupKeysToolStripMenuItem.Click += SetupKeysToolStripMenuItemOnClick;
            copyToClipboardButon.Click += CopyToClipboardButonOnClick;
            clearLogButton.Click += ClearLogButtonOnClick;
            _viewRefreshTimer.Interval = 100;
            _viewRefreshTimer.Tick += ViewRefreshTimerOnTick;
            _viewRefreshTimer.Start();
        }

        private string GetCurrentRunName()
        {
            return _runs[_currentRun].Name;
        }

        private void InitializeTrackedItemsGrid()
        {
            if (!_trackedItems.ContainsKey(GetCurrentRunName()))
            {
                _trackedItems[GetCurrentRunName()] = new BindingList<Item>(
                    _runs[_currentRun].TrackedItems.Select(i => new Item(i)
                    {
                        Count = 0
                    }).ToList()
                );
            }
            trackedItemsGrid.DataSource = _trackedItems[GetCurrentRunName()];
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
            Clipboard.SetText(string.Join("\r\n", _runRecords.Select(r => r.ToSpreadsheet())));
        }

        private void ViewRefreshTimerOnTick(object o, EventArgs eventArgs)
        {
            currentRunTimeLabel.Text = _timerManager.GetDuration(GetCurrentRunName()).ToString("g");
        }

        private void ApplySettings(Settings settings)
        {
            _timerManager.SetAvailableRuns(settings.Runs.Select(r => r.Name).ToList());
            SetupKeyboardHooks(settings);
            _runs = settings.Runs;
            if (!_runs.Any())
            {
                _runs = new List<Run>() { new Run() { Name = "Unknown run", TrackedItems = new List<string>() } };
            }
            _currentRun = 0;
            UpdateCurrentRunLabel();
            InitializeTrackedItemsGrid();
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
            _hook.SetKeyboardHook(settings.SelectedNextItemKey, new HookCallbacks
            {
                OnKeyUp = OnNextItemPress
            });
            _hook.SetKeyboardHook(settings.SelectPreviousItemKey, new HookCallbacks
            {
                OnKeyUp = OnPrevItemPress
            });
            _hook.SetKeyboardHook(settings.IncrementCurrentItemKey, new HookCallbacks
            {
                OnKeyUp = OnIncValuePress
            });
            _hook.SetKeyboardHook(settings.DecrementCurrentItemKey, new HookCallbacks
            {
                OnKeyUp = OnDecValuePress
            });
        }

        private void OnDecValuePress()
        {
            _trackedItems[GetCurrentRunName()][trackedItemsGrid.CurrentCell.RowIndex].Count--;
            trackedItemsGrid.Refresh();
        }

        private void OnIncValuePress()
        {
            _trackedItems[GetCurrentRunName()][trackedItemsGrid.CurrentCell.RowIndex].Count++;
            trackedItemsGrid.Refresh();
        }

        private void OnPrevItemPress()
        {
            trackedItemsGrid.CurrentCell = trackedItemsGrid[trackedItemsGrid.CurrentCell.ColumnIndex,
                Math.Max(trackedItemsGrid.CurrentCell.RowIndex - 1, 0)];
        }

        private void OnNextItemPress()
        {
            trackedItemsGrid.CurrentCell = trackedItemsGrid[trackedItemsGrid.CurrentCell.ColumnIndex,
                Math.Min(trackedItemsGrid.CurrentCell.RowIndex + 1, trackedItemsGrid.RowCount - 1)];
        }

        private void OnStartTimerPress()
        {
            _timerManager.StartTimer(GetCurrentRunName());
        }

        private void OnResetTimerPress()
        {
            var currentRun = GetCurrentRunName();
            var duration = _timerManager.GetDuration(currentRun);
            if (duration == TimeSpan.Zero)
            {
                return;
            }
            _runRecords.Add(new RunRecord
            {
                Run = currentRun,
                Duration = duration,
                Items = _trackedItems[currentRun].ToList()
            });
            logTextBox.Text = string.Format("{0}: {1}\r\n", currentRun, duration.ToString("g", CultureInfo.InvariantCulture)) + logTextBox.Text;
            _timerManager.ResetTimer(currentRun);
            _trackedItems[currentRun] = new BindingList<Item>(
                _runs[_currentRun].TrackedItems.Select(i => new Item(i)
                {
                    Count = 0
                }).ToList()
            ); 
            InitializeTrackedItemsGrid();
        }

        private void OnStopTimerPress()
        {
            _timerManager.StopTimer(GetCurrentRunName());
        }

        private void OnChangeRunPress()
        {
            _currentRun = (_currentRun + 1) % _runs.Count;
            UpdateCurrentRunLabel();
            InitializeTrackedItemsGrid();
        }

        private void UpdateCurrentRunLabel()
        {
            currentRunLabel.Text = GetCurrentRunName();
        }

        private void InitializeKeyboardHook()
        {
            _hook.Hook();
            this.Closing += (sender, args) => { _hook.Unhook(); };
        }
    }
}
