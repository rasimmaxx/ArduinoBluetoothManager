using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArduinoBluetoothManager
{

    public class BluetoothCache
    {
        private readonly string cacheFilePath;

        public BluetoothCache(string filePath)
        {
            cacheFilePath = filePath;
            LoadCache();
        }

        private List<string> bluetoothNames = new List<string>();

        private void LoadCache()
        {
            if (File.Exists(cacheFilePath))
            {
                XDocument doc = XDocument.Load(cacheFilePath);
                bluetoothNames = doc.Root.Elements("Device")
                                          .Select(e => e.Attribute("Name").Value)
                                          .ToList();
            }
        }

        public void AddBluetoothName(string name)
        {
            if (!bluetoothNames.Contains(name))
            {
                bluetoothNames.Add(name);
                SaveCache();
            }
        }

        public void RemoveBluetoothName(string name)
        {
            if (bluetoothNames.Contains(name))
            {
                bluetoothNames.Remove(name);
                SaveCache();
            }
        }

        public List<string> GetBluetoothNames()
        {
            return new List<string>(bluetoothNames);
        }

        public void ClearCache()
        {
            bluetoothNames.Clear();
            if (File.Exists(cacheFilePath))
            {
                File.Delete(cacheFilePath);
            }
        }

        private void SaveCache()
        {
            XDocument doc = new XDocument(
                new XElement("BluetoothDevices",
                    bluetoothNames.Select(name => new XElement("Device", new XAttribute("Name", name)))
                )
            );
            doc.Save(cacheFilePath);
        }
    }
}
