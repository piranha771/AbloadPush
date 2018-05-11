using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace AbloadPush
{
    class Config
    {
        public static readonly string SettingsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UploadPushService\\settings.json");
        private sealed class MemoryStore
        {
            public byte[] cookies;
        }
        private CookieContainer cookies;

        public CookieContainer Cookies => cookies;

        public void Save()
        {
            if (!Directory.Exists(Path.GetDirectoryName(SettingsFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(SettingsFile));
            }
            if (!File.Exists(SettingsFile))
            {
                File.Create(SettingsFile);
            }

            string content = JsonConvert.SerializeObject(new MemoryStore()
            {
                cookies = CookiesToArray(cookies)
            });

            File.WriteAllText(SettingsFile, content);
        }

        public void Load()
        {
            if (File.Exists(SettingsFile))
            {
                string content = File.ReadAllText(SettingsFile);
                var store = JsonConvert.DeserializeObject<MemoryStore>(content);

                if (store != null)
                {
                    cookies = ArrayToCookies(store.cookies);
                }
                else
                {
                    cookies = new CookieContainer();
                }
            }
            else
            {
                cookies = new CookieContainer();
            }
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
