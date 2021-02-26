using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaDevices;
using MTPMediaCopier.util;

namespace MTPMediaCopier
{
    public partial class Form1 : Form
    {
        bool isRunning = false;
        
        public string getDeviceName()
        {
            return cd_deviceName.SelectedItem.ToString();
        }

        public string getPathToSave()
        {
            return textBox2.Text;
        }

        public Form1()
        {
            InitializeComponent();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                var param1 = getDeviceName();
                var param2 = getPathToSave();
                Task myTask = Task.Factory.StartNew(() => Mtp.copyAllImages(param1, param2));
                Visible = true;
                isRunning = true;
                button3.Enabled = false;
                myTask.ContinueWith((t) => Application.Exit(), new CancellationToken());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cd_deviceName.Items.Clear();
            Mtp mtp = new Mtp();
            try
            {
                foreach (MediaDevice device in mtp.findPhone())
                {
                    cd_deviceName.Items.Add(device.FriendlyName);
                    Console.WriteLine(device.FriendlyName);
                }
            }
            finally
            {
                mtp.Dispose();
            }
            if (cd_deviceName.Items.Count > 0)
            {
                cd_deviceName.SelectedIndex = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox2.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
    }
}
