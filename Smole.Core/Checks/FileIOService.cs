using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Smole.Core
{
    /// <summary>
    /// Class for Serialize and Deserialize info
    /// </summary>
    public class FileIOService
    {
        #region PATH Initialize

        // File path
        private readonly string PATH;
        // Give path
        public FileIOService(string path) =>
            PATH = path;

        #endregion

        #region Json Serializer

        /// <summary>
        /// JsonConvert Serializing
        /// </summary>
        public void JsonSerialization<T>(T data)
            where T : class, new()
        {
            using (StreamWriter sw = File.CreateText(PATH))
            {
                // Read data from list
                string output = JsonConvert.SerializeObject(data);
                // save data to file
                sw.Write(output);
            }
        }

        /// <summary>
        /// JsonConvert Deserializing
        /// </summary>
        public T JsonDeserialization<T>()
            where T : class, new()
        {
            // check for existence
            var fileExist = File.Exists(PATH);

            if (!fileExist)
            {
                // create file
                File.CreateText(PATH).Dispose();

                // return empty T
                return new T();
            }

            // Read data from file
            using (StreamReader sr = File.OpenText(PATH))
            {
                var fileText = sr.ReadToEnd();
                if (fileText.Length == 0)
                    // return empty T
                    return new T();

                // return data
                return JsonConvert.DeserializeObject<T>(fileText);
            }
        }

        #endregion
    }
}
