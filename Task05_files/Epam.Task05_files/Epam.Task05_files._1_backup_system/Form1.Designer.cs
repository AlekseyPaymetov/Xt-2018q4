namespace Epam.Task05_files._1_backup_system
{
    partial class Form1
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
            this.startStopWatchingBu = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.folderTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.chooseFolderBu = new System.Windows.Forms.Button();
            this.goToDateBu = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.deleteStorageBu = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.showStorageBu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // startStopWatchingBu
            // 
            this.startStopWatchingBu.Location = new System.Drawing.Point(12, 12);
            this.startStopWatchingBu.Name = "startStopWatchingBu";
            this.startStopWatchingBu.Size = new System.Drawing.Size(125, 50);
            this.startStopWatchingBu.TabIndex = 0;
            this.startStopWatchingBu.Text = "Start watching";
            this.startStopWatchingBu.UseVisualStyleBackColor = true;
            this.startStopWatchingBu.Click += new System.EventHandler(this.StartStopWatchingBu_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(310, 42);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(181, 20);
            this.dateTimePicker.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ChooseDate";
            // 
            // folderTB
            // 
            this.folderTB.Enabled = false;
            this.folderTB.Location = new System.Drawing.Point(310, 108);
            this.folderTB.Name = "folderTB";
            this.folderTB.Size = new System.Drawing.Size(260, 20);
            this.folderTB.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Watchinf folder";
            // 
            // chooseFolderBu
            // 
            this.chooseFolderBu.Location = new System.Drawing.Point(310, 134);
            this.chooseFolderBu.Name = "chooseFolderBu";
            this.chooseFolderBu.Size = new System.Drawing.Size(100, 50);
            this.chooseFolderBu.TabIndex = 0;
            this.chooseFolderBu.Text = "Choose folder";
            this.chooseFolderBu.Click += new System.EventHandler(this.ChooseFolderBu_Click);
            // 
            // goToDateBu
            // 
            this.goToDateBu.Location = new System.Drawing.Point(152, 12);
            this.goToDateBu.Name = "goToDateBu";
            this.goToDateBu.Size = new System.Drawing.Size(125, 50);
            this.goToDateBu.TabIndex = 12;
            this.goToDateBu.Text = "Go to date";
            this.goToDateBu.UseVisualStyleBackColor = true;
            this.goToDateBu.Click += new System.EventHandler(this.GoToDateBu_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoLabel.Location = new System.Drawing.Point(12, 72);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(265, 136);
            this.infoLabel.TabIndex = 13;
            this.infoLabel.Text = "Ready to work.";
            // 
            // deleteStorageBu
            // 
            this.deleteStorageBu.Location = new System.Drawing.Point(470, 200);
            this.deleteStorageBu.Name = "deleteStorageBu";
            this.deleteStorageBu.Size = new System.Drawing.Size(100, 50);
            this.deleteStorageBu.TabIndex = 14;
            this.deleteStorageBu.Text = "Delete storage";
            this.deleteStorageBu.UseVisualStyleBackColor = true;
            this.deleteStorageBu.Click += new System.EventHandler(this.DeleteStorageBu_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // showStorageBu
            // 
            this.showStorageBu.Location = new System.Drawing.Point(310, 200);
            this.showStorageBu.Name = "showStorageBu";
            this.showStorageBu.Size = new System.Drawing.Size(100, 50);
            this.showStorageBu.TabIndex = 15;
            this.showStorageBu.Text = "Show storage";
            this.showStorageBu.UseVisualStyleBackColor = true;
            this.showStorageBu.Click += new System.EventHandler(this.ShowStorageBu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.showStorageBu);
            this.Controls.Add(this.deleteStorageBu);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.goToDateBu);
            this.Controls.Add(this.chooseFolderBu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.folderTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.startStopWatchingBu);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Epam.Task05.Files.Backaup files ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startStopWatchingBu;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox folderTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button chooseFolderBu;
        private System.Windows.Forms.Button goToDateBu;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button deleteStorageBu;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button showStorageBu;
    }
}

