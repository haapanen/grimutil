using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Haapanen.GrimUtil.Ui.Entities;

namespace Haapanen.GrimUtil.Ui.Dialogs
{
    public partial class SettingsDialog : Form
    {
        private class ItemWrapper
        {
            public string Name { get; set; }
        }

        private BindingList<Run> _runDataSource;
        private Run _selectedRun;
        private BindingList<ItemWrapper> _itemsDataSource;
        private ItemWrapper _selectedItem;

        public Settings Settings { get; private set; }

        public SettingsDialog(Settings settings)
        {
            Settings = settings.Clone();
            InitializeComponent();
            InitializeKeysComboboxes();
            InitializeRunGridView();
            InitializeTrackedItemsGridView();

            runDataGridView.SelectionChanged += RunDataGridViewOnSelectionChanged;
            okButton.Click += OkButtonOnClick;
            cancelButton.Click += CancelButtonOnClick;
            moveUpButton.Click += MoveUpButtonOnClick;
            moveDownButton.Click += MoveDownButtonOnClick;
            trackedItemsGrid.SelectionChanged += TrackedItemsGridOnSelectionChanged;
            trackedItemsMoveUpButton.Click += TrackedItemsMoveUpButtonOnClick;
            trackedItemsMoveDownButton.Click += TrackedItemsMoveDownButtonOnClick;
        }

        #region Initialization

        private void InitializeTrackedItemsGridView()
        {
            if (_selectedRun == null)
            {
                _itemsDataSource = new BindingList<ItemWrapper>();
                trackedItemsGrid.Enabled = false;
            }
            else
            {
                _itemsDataSource = new BindingList<ItemWrapper>(
                    _selectedRun.TrackedItems.Select(ti => new ItemWrapper { Name = ti }).ToList()
                );
                trackedItemsGrid.Enabled = true;
            }
            trackedItemsGrid.DataSource = _itemsDataSource;
        }

        private void InitializeRunGridView()
        {
            _runDataSource = new BindingList<Run>(Settings.Runs.ToList());
            runDataGridView.DataSource = _runDataSource;
        }

        private void InitializeKeysComboboxes()
        {
            startTimerKeyCombobox.DataSource = Enum.GetValues(typeof(Keys));
            stopTimerKeyCombobox.DataSource = Enum.GetValues(typeof(Keys));
            resetTimerKeyCombobox.DataSource = Enum.GetValues(typeof(Keys));
            changeRunKeyCombobox.DataSource = Enum.GetValues(typeof(Keys));
            selectNextCombobox.DataSource = Enum.GetValues(typeof(Keys));
            selectPreviousKeyCombobox.DataSource = Enum.GetValues(typeof(Keys));
            incrementCountKeyCombobox.DataSource = Enum.GetValues(typeof(Keys));
            decrementCountKeyCombobox.DataSource = Enum.GetValues(typeof(Keys));

            startTimerKeyCombobox.SelectedItem = Settings.StartTimerKey;
            stopTimerKeyCombobox.SelectedItem = Settings.StopTimerKey;
            resetTimerKeyCombobox.SelectedItem = Settings.ResetTimerKey;
            changeRunKeyCombobox.SelectedItem = Settings.ChangeRunKey;
            selectNextCombobox.SelectedItem = Settings.SelectedNextItemKey;
            selectPreviousKeyCombobox.SelectedItem = Settings.SelectPreviousItemKey;
            incrementCountKeyCombobox.SelectedItem = Settings.IncrementCurrentItemKey;
            decrementCountKeyCombobox.SelectedItem = Settings.DecrementCurrentItemKey;
        }


        #endregion

        #region Internal API

        private void UpdateTrackedItems()
        {
            _selectedRun.TrackedItems = ((BindingList<ItemWrapper>)_itemsDataSource).Select(i => i.Name).ToList();
        }

        #endregion

        #region Event handlers

        private void TrackedItemsGridOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            _selectedItem = null;
            if (trackedItemsGrid.SelectedCells.Count > 0)
            {
                _selectedItem = _itemsDataSource[trackedItemsGrid.SelectedCells[0].RowIndex];
            }

            trackedItemsMoveDownButton.Enabled = _selectedRun != null;
            trackedItemsMoveUpButton.Enabled = _selectedRun != null;
        }

        private void TrackedItemsMoveDownButtonOnClick(object sender, EventArgs eventArgs)
        {
            var item = _selectedItem;
            var currentIndex = _itemsDataSource.IndexOf(_selectedItem);
            var newIndex = Math.Min(currentIndex + 1, _itemsDataSource.Count - 1);
            _itemsDataSource.RemoveAt(currentIndex);
            _itemsDataSource.Insert(newIndex, item);
            trackedItemsGrid.ClearSelection();
            trackedItemsGrid.Rows[newIndex].Selected = true;
        }

        private void TrackedItemsMoveUpButtonOnClick(object sender, EventArgs eventArgs)
        {
            var item = _selectedItem;
            var currentIndex = _itemsDataSource.IndexOf(item);
            var newIndex = Math.Max(currentIndex - 1, 0);
            _itemsDataSource.RemoveAt(currentIndex);
            _itemsDataSource.Insert(newIndex, item);
            trackedItemsGrid.ClearSelection();
            trackedItemsGrid.Rows[newIndex].Selected = true;
        }

        private void RunDataGridViewOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            if (_selectedRun != null)
            {
                UpdateTrackedItems();
            }
            _selectedRun = null;
            if (runDataGridView.SelectedCells.Count > 0)
            {
                _selectedRun = _runDataSource[runDataGridView.SelectedCells[0].RowIndex];
            }

            moveDownButton.Enabled = _selectedRun != null;
            moveUpButton.Enabled = _selectedRun != null;
            InitializeTrackedItemsGridView();
        }

        private void MoveDownButtonOnClick(object sender, EventArgs eventArgs)
        {
            var item = _selectedRun;
            var currentIndex = _runDataSource.IndexOf(_selectedRun);
            var newIndex = Math.Min(currentIndex + 1, _runDataSource.Count - 1);
            _runDataSource.RemoveAt(currentIndex);
            _runDataSource.Insert(newIndex, item);
            runDataGridView.ClearSelection();
            runDataGridView.Rows[newIndex].Selected = true;
        }

        private void MoveUpButtonOnClick(object sender, EventArgs eventArgs)
        {
            var item = _selectedRun;
            var currentIndex = _runDataSource.IndexOf(item);
            var newIndex = Math.Max(currentIndex - 1, 0);
            _runDataSource.RemoveAt(currentIndex);
            _runDataSource.Insert(newIndex, item);
            runDataGridView.ClearSelection();
            runDataGridView.Rows[newIndex].Selected = true;
        }

        private void CancelButtonOnClick(object sender, EventArgs eventArgs)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButtonOnClick(object sender, EventArgs eventArgs)
        {
            UpdateTrackedItems();
            DialogResult = DialogResult.OK;
            Settings.StartTimerKey = (Keys)startTimerKeyCombobox.SelectedItem;
            Settings.ResetTimerKey = (Keys)resetTimerKeyCombobox.SelectedItem;
            Settings.StopTimerKey = (Keys)stopTimerKeyCombobox.SelectedItem;
            Settings.ChangeRunKey = (Keys)changeRunKeyCombobox.SelectedItem;
            Settings.SelectedNextItemKey = (Keys)selectNextCombobox.SelectedItem;
            Settings.SelectPreviousItemKey = (Keys)selectPreviousKeyCombobox.SelectedItem;
            Settings.IncrementCurrentItemKey = (Keys)incrementCountKeyCombobox.SelectedItem;
            Settings.DecrementCurrentItemKey = (Keys)decrementCountKeyCombobox.SelectedItem;
            Settings.Runs = ((BindingList<Run>)runDataGridView.DataSource).Where(r => !string.IsNullOrEmpty(r.Name.Trim())).ToList();
            Close();
        }

        #endregion
    }
}
