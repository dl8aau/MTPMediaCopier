using MediaDevices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTPMediaCopier.util
{
    class Mtp : IDisposable
    {
        public IEnumerable<MediaDevice> findPhone()
        {
            var devices = MediaDevice.GetDevices();
            return devices;
        }

        public static void copyAllImages(string deviceName, string folderToWrite)
        {
            var devices = MediaDevice.GetDevices();
            using (var device = devices.First(d => d.FriendlyName == deviceName))
            {
                device.Connect();
                var photoDir = device.GetDirectoryInfo(@"\");

                var files = photoDir.EnumerateFiles("*.jpg", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    MemoryStream memoryStream = new System.IO.MemoryStream();
                    device.DownloadFile(file.FullName, memoryStream);
                    memoryStream.Position = 0;
                    WriteSreamToDisk(folderToWrite + "\\" + file.Name, memoryStream);
                }
                device.Disconnect();
            }
        }

        static void WriteSreamToDisk(string filePath, MemoryStream memoryStream)
        {
            using (FileStream file = new FileStream(filePath, FileMode.Create, System.IO.FileAccess.Write))
            {
                byte[] bytes = new byte[memoryStream.Length];
                memoryStream.Read(bytes, 0, (int)memoryStream.Length);
                file.Write(bytes, 0, bytes.Length);
                memoryStream.Close();
            }
        }

        public void Dispose()
        {
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
