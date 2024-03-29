using MediaDevices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MTPMediaCopier.util
{
    class Mtp : IDisposable
    {
        readonly static string[] EXTENSIONS = { ".jpg", ".jpeg", ".gif", ".raw" };
        public IEnumerable<MediaDevice> findPhone()
        {
            var devices = MediaDevice.GetDevices();
            return devices;
        }

        public static void CopyAllImages(string deviceName, string folderToWrite, DateTime startFrom, 
            ProgressBar progressBar, Label label)
        {
            var devices = MediaDevice.GetDevices();
            using (var device = devices.First(d => (string.IsNullOrEmpty(d.FriendlyName) ? d.Description : d.FriendlyName) == deviceName))
            {
                device.Connect();

                // iterate over file systems - catch SD-cards etc...
                IEnumerable<string> ifs = device.EnumerateFileSystemEntries("/");


                foreach (var fsName in ifs)
                {
                    IEnumerable<string> idir = device.EnumerateDirectories(fsName + @"/");
                    var photoDir = device.GetDirectoryInfo(fsName + @"\DCIM\Camera");

                    var files = photoDir.EnumerateFiles("*.*", SearchOption.AllDirectories);

                    label.Invoke((MethodInvoker)(() => label.Text = "Scanning " + fsName.Replace("\\", "")));
                    var result = from p in files
                                 where EXTENSIONS.Any(val => p.FullName.Contains(val) && p.LastWriteTime > startFrom)
                                 select p;

                    if (result.Count() == 0)
                        continue;
                    // first path - just check and count
                    ulong total_bytes = 0;
                    uint files_to_copy = 0;
                    List<MediaFileInfo> list_to_copy = new List<MediaFileInfo>();
                    Console.WriteLine("count: " + result.Count());
                    progressBar.Invoke((MethodInvoker)(() => progressBar.Maximum = result.Count()));
                    progressBar.Invoke((MethodInvoker)(() => progressBar.Value = 1));

                    foreach (var file in result)
                    {
                        progressBar.Invoke((MethodInvoker)(() => progressBar.PerformStep()));

                        string targetPath = folderToWrite + "\\" + file.Name;
                        var fi = new FileInfo(targetPath);
                        if (fi.Exists &&
                            fi.Length == (long)file.Length &&
                            (file.LastWriteTime != null && fi.LastWriteTime == file.LastWriteTime))
                            continue;
                        list_to_copy.Add(file);
                        total_bytes += file.Length;
                        files_to_copy++;
                    }
                    Console.WriteLine("to copy " + files_to_copy + " - total " + total_bytes + " " + total_bytes / (1024L * 1024L * 1024L));

                    label.Invoke((MethodInvoker)(() => label.Text = "Copying " + files_to_copy + " files from " + fsName.Replace("\\", "")));
                    progressBar.Invoke((MethodInvoker)(() => progressBar.Value = 1));
                    foreach (var file in list_to_copy)
                    {
                        progressBar.Invoke((MethodInvoker)(() => progressBar.PerformStep()));

                        string targetPath = folderToWrite + "\\" + file.Name;

                        MemoryStream memoryStream = new MemoryStream();
                        device.DownloadFile(file.FullName, memoryStream);
                        memoryStream.Position = 0;
                        Console.WriteLine("copying " + targetPath);
                        WriteSreamToDisk(targetPath, memoryStream);
                        if (file.LastWriteTime != null)
                            File.SetLastWriteTime(targetPath, (System.DateTime)file.LastWriteTime);
                    }
                }
                device.Disconnect();
            }
        }

        static void WriteSreamToDisk(string filePath, MemoryStream memoryStream)
        {
            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                byte[] bytes = new byte[memoryStream.Length];
                memoryStream.Read(bytes, 0, (int)memoryStream.Length);
                file.Write(bytes, 0, bytes.Length);
                memoryStream.Close();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
