using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Primitives
{
    public class ResponseJson
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class ResponseJson<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    
}
