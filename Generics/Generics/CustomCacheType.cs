using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache
{
    public class CustomCacheType<TKey,TValue>
    {
        private Dictionary<TKey, TValue> cache = new Dictionary<TKey, TValue>();
        private Stopwatch stopwatch = new Stopwatch();

        public Tuple<bool,TValue> TryGetValue(TKey key)
        {
            if (cache.ContainsKey(key) && stopwatch.ElapsedMilliseconds < 10000)
                return new Tuple<bool,TValue>(true,cache[key]);
            else
                return new Tuple<bool, TValue>(false, item2: default);
        }

        public void EnterValue(TKey key,TValue value)
        {
            cache.Add(key, value);
            stopwatch.Reset();
            stopwatch.Start();
        }

        private void RemoveEntry(TKey key)
        {
            cache.Remove(key);
        }
    }
}
