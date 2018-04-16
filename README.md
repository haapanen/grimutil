# Grim Dawn Utilities
A simple Windows utility for timing things on Grim Dawn

## What?

Grim Dawn utilities is a simple program to track different runs and loot in the runs. Data can be exported to a spreadsheet (e.g. Google Spreadsheet and Excel)

## Setup

Run the main executable. 

When the application is started for the first time, default settings (shortcuts, available runs and tracked items) will be created for user. These can and should be edited by opening the settings dialog. Pressing the settings menu item on the left upper corner will open the settings dialog.

![Main view][mainView]

Keyboard shortcuts, available runs and the runs' tracked items can be configured in the settings view. Shortcuts can be configured by selecting the preferred key from the key combobox.

Available runs can be added, edited and deleted. Typing to an empty row will add a new run. Empty runs will be ignored. Double clicking the cell item enables editing. Selecting a row (by pressing the leftmost cell) and pressing delete will delete key the row.

Selecting a run enables the editing of tracked items for the run. The tracked items table works just like the available runs table.

![Settings view][settings]

Pressing OK saves the settings. Pressing cancel cancels the changes. Settings are stored to `%LOCALAPPDATA%\GrimUtil`. After changes are saved, the main view displays the first run on the list.

![Main view with a run][mainViewWithRun]

Once runs have been created the timer can be used. Resetting the timer will save the run results to the log. These can be copied in a spreadsheet format by clicking Copy to clipboard. Clear log button empties the run log.

Multiple runs can be running at the same time by switching to a different run while a run is running.

![Main view with an active run][mainWithWithAnActiveRun]

Happy grinding!

[mainView]: ./images/MainView.png
[settings]: ./images/Settings.png
[mainViewWithRun]: ./images/MainViewWithRun.png
[mainWithWithAnActiveRun]: ./images/MainViewWithAnActiveRun.png
