using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppNTier.EntityLayer.Concrete_Domains
{
    public class Work:Base_Entity
    {
        
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
