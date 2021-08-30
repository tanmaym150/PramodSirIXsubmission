using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryOutMiddleware.Models
{
    public class MyModelClass
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
