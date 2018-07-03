using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie
{
    public class PaytweakData
    {

        public class theToken
        {
            [DeserializeAs(Name = "Paytweak-Security-Token")]
            public string PaytweakSecurityToken { get; set; }

            [DeserializeAs(Name = "Paytweak-Work-Token")]
            public string PaytweakWorkToken { get; set; }
        }
    }
}
