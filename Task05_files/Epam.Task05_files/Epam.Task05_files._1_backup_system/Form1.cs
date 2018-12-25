using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epam.Task05_files._1_backup_system
{
    public partial class Form1 : Form
    {
        private bool isWatching = false;

        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dateNow = DateTime.Now;
            folderTB.Text = Properties.Settings.Default.folderPath;
            dateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
        }

        private void ChooseFolderBu_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderTB.Text = folderBrowserDialog.SelectedPath + "\\";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.folderPath = folderTB.Text;
            Properties.Settings.Default.Save();
        }

        private void StartStopWatchingBu_Click(object sender, EventArgs e)
        {
            if (!this.isWatching)
            {
                startStopWatchingBu.Text = "Stop watching";
                goToDateBu.Enabled = false;
                deleteStorageBu.Enabled = false;
                infoLabel.Text = $"Watching for {folderTB.Text}";
                if (string.IsNullOrEmpty(folderTB.Text))
                {
                    infoLabel.Text = "Please enter folder for watching (press \"Choose button\").";
                    return;
                }

                FileStorage.WatchingPath = folderTB.Text;
                if (!FileStorage.StartWatching())
                {
                    infoLabel.Text = "Some problems in work FileStorage class. Please contact the developer.";
                }
            }
            else
            {
                startStopWatchingBu.Text = "Start watching";
                goToDateBu.Enabled = true;
                deleteStorageBu.Enabled = true;
                infoLabel.Text = "Ready to work.";
                if (!FileStorage.StopWatching())
                {
                    infoLabel.Text = "Some problems in work FileStorage class. Please contact the developer.";
                }
            }

            this.isWatching = !this.isWatching;
        }

        private void GoToDateBu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(folderTB.Text))
            {
                infoLabel.Text = "Please select path for watching folder";
                return;
            }

            Restore.Date = dateTimePicker.Value;
            Restore.WatchgerPath = folderTB.Text;
            if (Restore.DoRestore())
            {
                infoLabel.Text = $"{folderTB.Text} was successfully restore for {dateTimePicker.Value}";
            }
            else
            {
                infoLabel.Text = $"Having some trouble with restore :(";
            }
        }

        private void DeleteStorageBu_Click(object sender, EventArgs e)
        {
            if (FileStorage.DeleteStorageFolder())
            {
                infoLabel.Text = "Storage successful deleted.";
            }
            else
            {
                infoLabel.Text = "Could not deleted storage.";
            }
        }

        private void ShowStorageBu_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(FileStorage.StoragePath))
            {
                System.Diagnostics.Process.Start("explorer", FileStorage.StoragePath);
            }
            else
            {
                infoLabel.Text = "Storage is not exist.";
            }
        }
    }
}
