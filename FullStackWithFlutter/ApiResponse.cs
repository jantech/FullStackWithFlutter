using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackWithFlutter
{
    public class ApiResponse
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
