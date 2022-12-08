using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DtosLayer.Interfaces;

namespace TodoAppNTier.DtosLayer.WorkDtos
{
   public class WorkCreateDto : IDto
    {
      //  [Required(ErrorMessage ="Definition is required")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
