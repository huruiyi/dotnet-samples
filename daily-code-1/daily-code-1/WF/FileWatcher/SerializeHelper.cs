using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;//–Ú¡–ªØ

namespace FileWatcher
{
    public class SerializeHelper<T>
    {
        public static void Serialize(T t)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\config";
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, t);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static T DeSerialize()
        {
            T t = default(T);
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\config";
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    t = (T)bf.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return t;
        }
    }
}