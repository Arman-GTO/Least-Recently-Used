namespace Least_Recently_Used
{
    public class LRUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, (LinkedListNode<int> node, int value)> _cache;
        private readonly LinkedList<int> _list;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new Dictionary<int, (LinkedListNode<int> node, int value)>(capacity); // Create new cache with given capacity
            _list = new LinkedList<int>();
        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key)) // There's no such an element with that key
                return -1;

            var node = _cache[key]; // Make the relevant node most recently used
            _list.Remove(node.node);
            _list.AddFirst(node.node);

            return node.value; // Return the weanted value for that key
        }

        public void Put(int key, int value)
        {
            if (_cache.ContainsKey(key)) // Update the existing elements value
            {
                var node = _cache[key];
                _list.Remove(node.node);
                _list.AddFirst(node.node);

                _cache[key] = (node.node, value);
            }
            else
            {
                if (_cache.Count == _capacity) // Remove least recently used element to open  up sapce for new element
                {
                    var removeKey = _list.Last!.Value; // Get the key stored as Value in node
                    _cache.Remove(removeKey);
                    _list.RemoveLast();
                }

                _cache.Add(key, (_list.AddFirst(key), value)); // Add node by key, and add to dictionary by key and value
            }
        }

        public Dictionary<int, (LinkedListNode<int> node, int value)> GetCache() { return _cache; } // Return the whole cache
    }
}