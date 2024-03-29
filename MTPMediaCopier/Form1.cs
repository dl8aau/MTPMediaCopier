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
        public string getDeviceName()
        {
            return cd_deviceName.SelectedItem.ToString();
        }

        public string getPathToSave()
        {
            return txt_folder.Text;
        }

        public Form1()
        {
            InitializeComponent();
            Icon = Properties.Resources.mtp;
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                var param1 = getDeviceName();
                var param2 = getPathToSave();
                // Display the ProgressBar control.
                progressBar1.Visible = true;

                Task myTask = Task.Factory.StartNew(() => Mtp.CopyAllImages(param1, param2, 
                    dateTimePicker1.Value, progressBar1, label2));
                btn_copy.Enabled = false;
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
                }
            }
            finally
            {
                mtp.Dispose();
            }
            if (cd_deviceName.Items.Count > 0)
            {
                cd_deviceName.SelectedIndex = 0;
            } else
            {
                MessageBox.Show("Please make sure your device is connected and data transfer is allowed", "Device not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txt_folder.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
