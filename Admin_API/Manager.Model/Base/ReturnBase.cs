using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Model.Base
{
    public class ReturnBase<T>
    {
        public int code { get; set; } = -1;
        public string msg { get; set; }
        public int count { get; set; } = 0;
        public T data { get; set; }
    }
}
