using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Pool
    {
        public string PoolId { get; set; }
        public string PlayerId { get; set; }
        public string CeratedBy { get; set; }
        public string PoolLevel { get; set; }
    }
}
