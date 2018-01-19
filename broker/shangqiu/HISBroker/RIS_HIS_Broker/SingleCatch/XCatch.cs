using System;
using System.Collections.Generic;  

namespace RISBroker
{
    /// <summary>
    /// 缓存类
    /// </summary>
    public  class XCatch
    {
        public static IDictionary<string, object> Catches { get; private set; }
        static XCatch()
        {
            Catches = new Dictionary<string, object>();
        }



    }
}
