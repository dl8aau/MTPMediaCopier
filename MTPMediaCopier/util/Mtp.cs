using MediaDevices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public static void CopyAllImages(string deviceName, string folderToWrite)
        {
            var devices = MediaDevice.GetDevices();
            using (var device = devices.First(d => d.FriendlyName == deviceName))
            {
                device.Connect();
                var photoDir = device.GetDirectoryInfo(@"\");

                var files = photoDir.EnumerateFiles("*.*", SearchOption.AllDirectories);

                var result = from p in files
                             where EXTENSIONS.Any(val => p.FullName.Contains(val))
                             select p;

                foreach (var file in result)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    device.DownloadFile(file.FullName, memoryStream);
                    memoryStream.Position = 0;
                    WriteSreamToDisk(folderToWrite + "\\" + file.Name, memoryStream);
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
