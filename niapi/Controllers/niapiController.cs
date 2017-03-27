using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackExchange.Redis;

namespace niapi.Controllers
{
    public class niapiController : Controller
    {
        nibackendservice.Controllers.tokenController nibkendclient = new nibackendservice.Controllers.tokenController();
        public double getbalance(string cardnumber)
        {
            string token = nibkendclient.gettoken(cardnumber);

            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("netint.redis.cache.windows.net:6379,password=i8QKgmJgG3FWYpukKmpw+KcK/pZAOxWxF8EQLuucxZ8=,syncTimeout=10000,abortConnect=False");
            // Connection refers to a property that returns a ConnectionMultiplexer
            // as shown in the previous example.
            IDatabase cache = Connection.GetDatabase();
            // Perform cache operations using the cache object...
            // Simple put of integral data types into the cache
            cache.StringSet("key1", "value");
            cache.StringSet("key2", 25);

            // Simple get of data types from the cache
            string key1 = cache.StringGet("key1");
            int key2 = (int)cache.StringGet("key2");
            // Perform cache operations using the cache object...
            // Simple put of integral data types into the cache
            return 10;//(double) cache.HashGet("tokens", token);
          
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect("netint.redis.cache.windows.net:6379,password=i8QKgmJgG3FWYpukKmpw+KcK/pZAOxWxF8EQLuucxZ8=,syncTimeout=10000,abortConnect=False");
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}