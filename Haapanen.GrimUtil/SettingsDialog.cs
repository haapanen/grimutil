using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haapanen.GrimUtil.Ui
{
    public partial class SettingsDialog : Form
    {
        private BindingList<GridViewRun> _dataSource;
        private GridViewRun _selectedItem;

        private class GridViewRun
        {
            public GridViewRun()
            {
            }

            public GridViewRun(string name)
            {
                Name = name;
            }

            public string Name { get; set; }
        }
        public Settings Settings { get; private set; }

        public SettingsDialog(Settings settings)
        {
            Settings = settings.Clone();
            InitializeComponent();
            InitializeKeysComboboxes();
            InitializeRunGridView();

            runDataGridView.SelectionChanged += RunDataGridViewOnSelectionChanged;
            okButton.Click += OkButtonOnClick;
            cancelButton.Click += CancelButtonOnClick;
            moveUpButton.Click += MoveUpButtonOnClick;
            moveDownButton.Click += MoveDownButtonOnClick;
        }

        private void RunDataGridViewOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            _selectedItem = null;
            if (runDataGridView.SelectedCells.Count > 0)
            {
                _selectedItem = _dataSource[runDataGridView.SelectedCells[0].RowIndex];
            }

            moveDownButton.Enabled = _selectedItem != null;
            moveUpButton.Enabled = _selectedItem != null;
        }

        private void MoveDownButtonOnClick(object sender, EventArgs eventArgs)
        {
            var item = _selectedItem;
            var currentIndex = _dataSource.IndexOf(_selectedItem);
            var newIndex = Math.Min(currentIndex + 1, _dataSource.Count - 1);
            _dataSource.RemoveAt(currentIndex);
            _dataSource.Insert(newIndex, item);
            runDataGridView.ClearSelection();
            runDataGridView.Rows[newIndex].Selected = true;
        }

        private void MoveUpButtonOnClick(object sender, EventArgs eventArgs)
        {
            var item = _selectedItem;
            var currentIndex = _dataSource.IndexOf(item);
            var newIndex = Math.Max(currentIndex - 1, 0);
            _dataSource.RemoveAt(currentIndex);
            _dataSource.Insert(newIndex, item);
            runDataGridView.ClearSelection();
            runDataGridView.Rows[newIndex].Selected = true;
        }

        private void InitializeRunGridView()
        {
            //runDataGridView.Columns.Add(nameof(GridViewRun.Name), "Name");
            
            _dataSource = new BindingList<GridViewRun>(Settings.Runs.Select(r => new GridViewRun(r)).ToList());
            runDataGridView.DataSource = _dataSource;
        }

        private void InitializeKeysComboboxes()
        {
            startTimerKeyCombobox.DataSource = Enum.GetValues(typeof(Keys));
            stopTimerKeyCombobox.DataSource = Enum.GetValues(typeof(Keys));
            resetTimerKeyCombobox.DataSource = Enum.GetValues(typeof(Keys));
            changeRunKeyCombobox.DataSource = Enum.GetValues(typeof(Keys));

            startTimerKeyCombobox.SelectedItem = Settings.StartTimerKey;
            stopTimerKeyCombobox.SelectedItem = Settings.StopTimerKey;
            resetTimerKeyCombobox.SelectedItem = Settings.ResetTimerKey;
            changeRunKeyCombobox.SelectedItem = Settings.ChangeRunKey;
        }

        private void CancelButtonOnClick(object sender, EventArgs eventArgs)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButtonOnClick(object sender, EventArgs eventArgs)
        {
            DialogResult = DialogResult.OK;
            Settings.StartTimerKey = (Keys)startTimerKeyCombobox.SelectedItem;
            Settings.ResetTimerKey = (Keys)resetTimerKeyCombobox.SelectedItem;
            Settings.StopTimerKey = (Keys)stopTimerKeyCombobox.SelectedItem;
            Settings.ChangeRunKey = (Keys)changeRunKeyCombobox.SelectedItem;
            Settings.Runs = ((BindingList<GridViewRun>) runDataGridView.DataSource).Where(r => !string.IsNullOrEmpty(r.Name.Trim())).Select(r => r.Name).ToList();
            Close();
        }
    }
}
