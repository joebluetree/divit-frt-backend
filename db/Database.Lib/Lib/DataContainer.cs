using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Lib
{
    public class DataContainer
    {
        private readonly Dictionary<string, object> _data = new Dictionary<string, object>();

        // Set a value and return the instance for fluent chaining
        public DataContainer Set(string key, object value)
        {
            _data[key] = value;
            return this;
        }

        // Retrieve a value and return it
        public T Get<T>(string key)
        {
            if (_data.TryGetValue(key, out var value))
            {
                return (T)value; // Cast the value to the specified type
            }

            throw new KeyNotFoundException($"The key '{key}' was not found.");
        }

        // Check if a key exists in the dictionary
        public bool Contains(string key)
        {
            return _data.ContainsKey(key);
        }

        // Remove a key and return the instance for fluent chaining
        public DataContainer Remove(string key)
        {
            _data.Remove(key);
            return this;
        }

        // Clear all data and return the instance for fluent chaining
        public DataContainer Clear()
        {
            _data.Clear();
            return this;
        }

        // Print all key-value pairs for debugging
        public void PrintAll()
        {
            foreach (var kvp in _data)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
        public void ForEach(Action<string, object> action)
        {
            foreach (var kvp in _data)
            {
                action(kvp.Key, kvp.Value);
            }
        }
    }
}
