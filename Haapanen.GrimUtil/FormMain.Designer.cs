namespace Haapanen.GrimUtil.Ui
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.setupKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.currentRunLabel = new System.Windows.Forms.Label();
            this.currentRunTimeHeaderLabel = new System.Windows.Forms.Label();
            this.currentRunTimeLabel = new System.Windows.Forms.Label();
            this.copyToClipboardButon = new System.Windows.Forms.Button();
            this.clearLogButton = new System.Windows.Forms.Button();
            this.trackedItemsLabel = new System.Windows.Forms.Label();
            this.trackedItemsGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackedItemsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupKeysToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(627, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // setupKeysToolStripMenuItem
            // 
            this.setupKeysToolStripMenuItem.Name = "setupKeysToolStripMenuItem";
            this.setupKeysToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.setupKeysToolStripMenuItem.Text = "Settings";
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Location = new System.Drawing.Point(12, 287);
            this.logTextBox.MaxLength = 2147483647;
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(603, 170);
            this.logTextBox.TabIndex = 1;
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(9, 271);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(25, 13);
            this.logLabel.TabIndex = 2;
            this.logLabel.Text = "Log";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current run";
            // 
            // currentRunLabel
            // 
            this.currentRunLabel.AutoSize = true;
            this.currentRunLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentRunLabel.Location = new System.Drawing.Point(13, 48);
            this.currentRunLabel.Name = "currentRunLabel";
            this.currentRunLabel.Size = new System.Drawing.Size(103, 20);
            this.currentRunLabel.TabIndex = 4;
            this.currentRunLabel.Text = "Unknown run";
            // 
            // currentRunTimeHeaderLabel
            // 
            this.currentRunTimeHeaderLabel.AutoSize = true;
            this.currentRunTimeHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentRunTimeHeaderLabel.Location = new System.Drawing.Point(123, 24);
            this.currentRunTimeHeaderLabel.Name = "currentRunTimeHeaderLabel";
            this.currentRunTimeHeaderLabel.Size = new System.Drawing.Size(145, 24);
            this.currentRunTimeHeaderLabel.TabIndex = 5;
            this.currentRunTimeHeaderLabel.Text = "Current run time";
            // 
            // currentRunTimeLabel
            // 
            this.currentRunTimeLabel.AutoSize = true;
            this.currentRunTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentRunTimeLabel.Location = new System.Drawing.Point(123, 48);
            this.currentRunTimeLabel.Name = "currentRunTimeLabel";
            this.currentRunTimeLabel.Size = new System.Drawing.Size(14, 20);
            this.currentRunTimeLabel.TabIndex = 6;
            this.currentRunTimeLabel.Text = "-";
            // 
            // copyToClipboardButon
            // 
            this.copyToClipboardButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyToClipboardButon.Location = new System.Drawing.Point(515, 258);
            this.copyToClipboardButon.Name = "copyToClipboardButon";
            this.copyToClipboardButon.Size = new System.Drawing.Size(100, 23);
            this.copyToClipboardButon.TabIndex = 7;
            this.copyToClipboardButon.Text = "Copy to clipboard";
            this.copyToClipboardButon.UseVisualStyleBackColor = true;
            // 
            // clearLogButton
            // 
            this.clearLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearLogButton.Location = new System.Drawing.Point(434, 258);
            this.clearLogButton.Name = "clearLogButton";
            this.clearLogButton.Size = new System.Drawing.Size(75, 23);
            this.clearLogButton.TabIndex = 8;
            this.clearLogButton.Text = "Clear log";
            this.clearLogButton.UseVisualStyleBackColor = true;
            // 
            // trackedItemsLabel
            // 
            this.trackedItemsLabel.AutoSize = true;
            this.trackedItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackedItemsLabel.Location = new System.Drawing.Point(274, 24);
            this.trackedItemsLabel.Name = "trackedItemsLabel";
            this.trackedItemsLabel.Size = new System.Drawing.Size(128, 24);
            this.trackedItemsLabel.TabIndex = 9;
            this.trackedItemsLabel.Text = "Tracked items";
            // 
            // trackedItemsGrid
            // 
            this.trackedItemsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackedItemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trackedItemsGrid.Location = new System.Drawing.Point(278, 51);
            this.trackedItemsGrid.Name = "trackedItemsGrid";
            this.trackedItemsGrid.Size = new System.Drawing.Size(337, 201);
            this.trackedItemsGrid.TabIndex = 10;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 469);
            this.Controls.Add(this.trackedItemsGrid);
            this.Controls.Add(this.trackedItemsLabel);
            this.Controls.Add(this.clearLogButton);
            this.Controls.Add(this.copyToClipboardButon);
            this.Controls.Add(this.currentRunTimeLabel);
            this.Controls.Add(this.currentRunTimeHeaderLabel);
            this.Controls.Add(this.currentRunLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Grim Dawn Utilities";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackedItemsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem setupKeysToolStripMenuItem;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentRunLabel;
        private System.Windows.Forms.Label currentRunTimeHeaderLabel;
        private System.Windows.Forms.Label currentRunTimeLabel;
        private System.Windows.Forms.Button copyToClipboardButon;
        private System.Windows.Forms.Button clearLogButton;
        private System.Windows.Forms.Label trackedItemsLabel;
        private System.Windows.Forms.DataGridView trackedItemsGrid;
    }
}

