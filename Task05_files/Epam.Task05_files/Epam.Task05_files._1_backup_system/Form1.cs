using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epam.Task05_files._1_backup_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dateNow = DateTime.Now;
            hoursUD.Value = dateNow.Hour;
            minutesUP.Value = dateNow.Minute;
            secondsUD.Value = dateNow.Second;
            folderTB.Text = Properties.Settings.Default.folderPath;
            StartStopWatchingBu_Click(sender,e);
        }

        private void ChooseFolderBu_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderTB.Text = folderBrowserDialog.SelectedPath+"\\";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.folderPath = folderTB.Text;
            Properties.Settings.Default.Save();
        }

        bool isWatching = false;

        private void StartStopWatchingBu_Click(object sender, EventArgs e)
        {
            //long time = DateTime.Now.ToBinary();
            //MessageBox.Show(DateTime.Now.ToString());
            //MessageBox.Show(time.ToString());
            //MessageBox.Show(DateTime.FromBinary(time).ToString());
            if (!isWatching)
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
            //infoLabel.Text = Environment.SystemDirectory;
            isWatching = !isWatching;
        }

        private void goToDateBu_Click(object sender, EventArgs e)
        {
            infoLabel.Text = Environment.SystemDirectory;
        }

        private void deleteStorageBu_Click(object sender, EventArgs e)
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
    }
}
