using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DtosLayer.WorkDtos;

namespace TodoAppNTier.BusinessLayer.ValidationRules
{
    public class WorkUpdateDtoValidator : AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateDtoValidator()
        {
            //definition ıscompleted trueyken boş olamaz
            // RuleFor(x => x.Definition).NotEmpty().WithMessage("Definiton is required").When(x=>x.IsCompleted).Must(NotBeYavuz).WithMessage("Definiton yavuz olamaz");
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definiton is required");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Definiton is required");

        }

        //private bool NotBeYavuz(string arg)
        //{WorkUpdateeDtoValidator 
        //  //  yavuza eşit olmassa doğru başarılı dedik
        //    return arg != "Yavuz" && arg != "yavuz";
        //}
    }
}
