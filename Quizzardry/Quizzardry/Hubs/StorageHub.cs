using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizzardry.Models;

namespace Quizzardry.Hubs
{
    public class StorageHub<T>
    {
        private readonly Dictionary<T, Player> _connections =
             new Dictionary<T, Player>();

        public int Count
        {
            get
            {
                return _connections.Count;
            }
        }

        public void Add(T key, Player connectionId)
        {
            lock (_connections)
            {
                Player connections;
                if (!_connections.TryGetValue(key, out connections))
                {
                    _connections.Add(key, connectionId);
                }
            }

        }


        public Dictionary<T, Player> GetConnections()
        {
            return _connections;

        }

        public List<Player> GetList()
        {
            var connections = _connections.Select(x => x.Value).ToList();
            return connections;
        }
    }
}
