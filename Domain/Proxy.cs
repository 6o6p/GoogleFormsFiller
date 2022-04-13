using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Domain
{
    class Proxy
    {
        private readonly string[] _proxyList;

        private int _currentProxyIndex;

        public Proxy()
        {
            _proxyList = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Resources\ProxyList.txt"));
            _currentProxyIndex = 0;
        }

        public string GetNextProxy()
        {
            lock (_proxyList)
            {
                var result = _proxyList[_currentProxyIndex];
                _currentProxyIndex = (_currentProxyIndex + 1) % _proxyList.Length;
                return result;
            }
        }
    }
}
