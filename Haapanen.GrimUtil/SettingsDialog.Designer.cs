namespace Haapanen.GrimUtil.Ui
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.startTimerKeyCombobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resetTimerKeyCombobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stopTimerKeyCombobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.changeRunKeyCombobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.runDataGridView = new System.Windows.Forms.DataGridView();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.runDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(330, 305);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(249, 305);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start timer";
            // 
            // startTimerKeyCombobox
            // 
            this.startTimerKeyCombobox.FormattingEnabled = true;
            this.startTimerKeyCombobox.Location = new System.Drawing.Point(15, 25);
            this.startTimerKeyCombobox.Name = "startTimerKeyCombobox";
            this.startTimerKeyCombobox.Size = new System.Drawing.Size(121, 21);
            this.startTimerKeyCombobox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Reset timer";
            // 
            // resetTimerKeyCombobox
            // 
            this.resetTimerKeyCombobox.FormattingEnabled = true;
            this.resetTimerKeyCombobox.Location = new System.Drawing.Point(15, 65);
            this.resetTimerKeyCombobox.Name = "resetTimerKeyCombobox";
            this.resetTimerKeyCombobox.Size = new System.Drawing.Size(121, 21);
            this.resetTimerKeyCombobox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Stop timer";
            // 
            // stopTimerKeyCombobox
            // 
            this.stopTimerKeyCombobox.FormattingEnabled = true;
            this.stopTimerKeyCombobox.Location = new System.Drawing.Point(15, 105);
            this.stopTimerKeyCombobox.Name = "stopTimerKeyCombobox";
            this.stopTimerKeyCombobox.Size = new System.Drawing.Size(121, 21);
            this.stopTimerKeyCombobox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Change run";
            // 
            // changeRunKeyCombobox
            // 
            this.changeRunKeyCombobox.FormattingEnabled = true;
            this.changeRunKeyCombobox.Location = new System.Drawing.Point(15, 145);
            this.changeRunKeyCombobox.Name = "changeRunKeyCombobox";
            this.changeRunKeyCombobox.Size = new System.Drawing.Size(121, 21);
            this.changeRunKeyCombobox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Available runs";
            // 
            // runDataGridView
            // 
            this.runDataGridView.AllowUserToOrderColumns = true;
            this.runDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.runDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.runDataGridView.Location = new System.Drawing.Point(145, 25);
            this.runDataGridView.MultiSelect = false;
            this.runDataGridView.Name = "runDataGridView";
            this.runDataGridView.Size = new System.Drawing.Size(260, 141);
            this.runDataGridView.TabIndex = 12;
            // 
            // moveDownButton
            // 
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Location = new System.Drawing.Point(330, 172);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(75, 23);
            this.moveDownButton.TabIndex = 13;
            this.moveDownButton.Text = "Move down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            // 
            // moveUpButton
            // 
            this.moveUpButton.Enabled = false;
            this.moveUpButton.Location = new System.Drawing.Point(249, 172);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(75, 23);
            this.moveUpButton.TabIndex = 14;
            this.moveUpButton.Text = "Move up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 340);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.runDataGridView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.changeRunKeyCombobox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stopTimerKeyCombobox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resetTimerKeyCombobox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startTimerKeyCombobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "SettingsDialog";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.runDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox startTimerKeyCombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox resetTimerKeyCombobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox stopTimerKeyCombobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox changeRunKeyCombobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView runDataGridView;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
    }
}