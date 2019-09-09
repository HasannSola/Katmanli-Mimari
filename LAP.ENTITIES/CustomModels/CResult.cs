using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LAP.ENTITIES.CustomModels
{
    public class CResult<T>
    {
        [DefaultValue(false)]
        public bool Succeeded { get; set; }
        public string Desc { get; set; }
        public string Data { get; set; }
        public int Id { get; set; }
        public T Object { get; set; }
        public Exception ex { get; set; }
    }
}
