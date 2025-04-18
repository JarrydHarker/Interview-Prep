using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    internal class HashTable<T> //AKA Dictionary
    {
        private readonly List<HashValue<T>>[] indexes;

        public HashTable(int size) 
        { 
            indexes = new List<HashValue<T>>[size];

            for (int i = 0; i < size; i++)
            {
                indexes[i] = new List<HashValue<T>>();
            }
        }

        private int GenerateIndex(string key)
        {
            return Math.Abs(key.GetHashCode()) % indexes.Length;
        }

        public void Add(HashValue<T> value)
        {
            int index = GenerateIndex(value.key);
            var bucket = indexes[index];

            foreach (var item in bucket)
            {
                if (item.key == value.key)
                    throw new ArgumentException("Duplicate key exception");
            }

            bucket.Add(value);
        }

        public HashValue<T>? Get(string key)
        {
            int index = GenerateIndex(key);
            var bucket = indexes[index];

            foreach (var item in bucket)
            {
                if (item.key == key)
                    return item;
            }

            return null;
        }

        public HashValue<T>? Remove(string key)
        {
            int index = GenerateIndex(key);
            var content = indexes[index];

            for (int i = 0; i < content.Count; i++)
            {
                if (content[i].key == key)
                {
                    HashValue<T> influencer = content[i];
                    content.RemoveAt(i);
                    return influencer;
                }
            }

            return null;
        }
    }

    class HashValue<T>
    {
        public string key;
        public T value;

        public HashValue(string key, T value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
