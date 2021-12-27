using System;

namespace Polpware.Configuration.Json
{
    /// <summary>
    /// Loads the settings from a JSON file and allows for 
    /// type safely converting into a target type. 
    /// </summary>
    public class JsonSettingsProvider 
    {
        private string _data;
        private string _filepath;

        /// <summary>
        /// Default constructor
        /// </summary>
        public JsonSettingsProvider() { }

        /// <summary>
        /// Absolute path of a JSON file.
        /// The existence of the following constructor allows for
        /// DI.
        /// </summary>
        /// <param name="filepath"></param>
        public JsonSettingsProvider(string filepath)
        {
            Build(filepath);
        }

        public JsonSettingsProvider Build(string filepath)
        {
            _data = null;
            _filepath = filepath;
            return this;
        }

        /// <summary>
        /// Reads the content of the given file as a string.
        /// </summary>
        private void Loadfile()
        {
            using (var r = new System.IO.StreamReader(_filepath))
            {
                _data = r.ReadToEnd();
            }
        }

        public T ReadAs<T>(Func<string, T> func)
        {
            var x = ReadAsString();
            return func(x);
        }

        public string ReadAsString()
        {
            if (_data == null)
            {
                Loadfile();
            }

            return _data;
        }

    }
}
