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
        public string getbalance(string cardnumber)
        {
            string token = nibkendclient.gettoken(cardnumber);

            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("netint.redis.cache.windows.net:6379,password=i8QKgmJgG3FWYpukKmpw+KcK/pZAOxWxF8EQLuucxZ8=,syncTimeout=10000,abortConnect=False");
            // Connection refers to a property that returns a ConnectionMultiplexer
            // as shown in the previous example.
            IDatabase cache = Connection.GetDatabase();
            // Perform cache operations using the cache object...
            // Simple put of integral data types into the cache

            // Perform cache operations using the cache object...
            // Simple put of integral data types into the cache
            string balance = cache.HashGet("tokens:"+token, "balance");
            return balance;
          
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