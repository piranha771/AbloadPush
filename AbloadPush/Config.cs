using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace AbloadPush
{
    class Config
    {
        public static readonly uint VERSION = 1;
        public static readonly string ConfigFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UploadPushService\\settings.json");

        private class MemoryStore {
            public uint version;
        };

        private sealed class MemoryStoreV1 : MemoryStore
        {
            public byte[] cookies;
            public bool doSaveToDisk;
            public string imagePath;

            public MemoryStoreV1() => version = 1;
        }

        private CookieContainer cookies;
        private bool doSaveToDisk;
        private string imagePath;

        public CookieContainer Cookies => cookies;
        public bool DoSaveToDisk { get => doSaveToDisk; set => doSaveToDisk = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }

        public void Save()
        {
            if (!Directory.Exists(Path.GetDirectoryName(ConfigFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(ConfigFile));
            }

            string content = JsonConvert.SerializeObject(new MemoryStoreV1()
            {
                cookies = CookiesToArray(cookies),
                doSaveToDisk = doSaveToDisk,
                imagePath = imagePath
            });

            File.WriteAllText(ConfigFile, content);
        }

        public void Load()
        {
            if (File.Exists(ConfigFile))
            {
                string content = File.ReadAllText(ConfigFile);
                var store = JsonConvert.DeserializeObject<MemoryStore>(content);

                if (store != null)
                {
                    switch (store.version)
                    {
                        case 1:
                            var v1 = JsonConvert.DeserializeObject<MemoryStoreV1>(content); ;
                            cookies = ArrayToCookies(v1.cookies);
                            doSaveToDisk = v1.doSaveToDisk;
                            imagePath = v1.imagePath;
                            return;
                        default:
                            // new Exception($"Unknown config file version: {store.version}. The configuration will be skipped and the default configuration is loaded.");
                            break;
                    }
                }
            }

            // Default Settings
            cookies = new CookieContainer();
            doSaveToDisk = true;
            imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "UploadPushService");
        }

        public static byte[] CookiesToArray(CookieContainer cookies)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, cookies);
                    return stream.ToArray();

                }
                catch
                {
                    return new byte[0];
                }
            }
        }

        public static CookieContainer ArrayToCookies(byte[] cookies)
        {
            try
            {
                using (Stream stream = new MemoryStream(cookies))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (CookieContainer)formatter.Deserialize(stream);
                }
            }
            catch
            {
                return new CookieContainer();
            }
        }
    }
}
