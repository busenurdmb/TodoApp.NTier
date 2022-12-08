using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DtosLayer.Interfaces;

namespace TodoAppNTier.DtosLayer.WorkDtos
{
    public class WorkListDto:IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
