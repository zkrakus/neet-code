namespace neetcode.BinarySearch;

public class TimeBasedKeyValueStore
{
    private readonly Dictionary<string, List<(int timestamp, string value)>> keyValueStore = new();

    public TimeBasedKeyValueStore()
    {
        
    }

    public void Set(string key, string value, int timestamp)
    {
        if (keyValueStore.TryGetValue(key, out var output))
            output.Add((timestamp, value));
        else
            keyValueStore[key] = new List<(int, string)>() { (timestamp, value) };
    }

    public string Get(string key, int timestamp)
    {
        string result = "";
        if (!keyValueStore.ContainsKey(key))
            return result;
        
        var list = keyValueStore[key];
        int l = 0, r = list.Count - 1;
        while (l <= r)
        {
            int mid = l + (r - l) / 2;
            var cur = list[mid];
            if (cur.timestamp <= timestamp)
            {
                result = cur.value;
                r = mid - 1;
            } 
            else
            {
                l = mid + 1;
            }
        }

        return result;
    }
}
