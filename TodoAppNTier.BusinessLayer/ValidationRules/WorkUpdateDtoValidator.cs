using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DtosLayer.WorkDtos;

namespace TodoAppNTier.BusinessLayer.ValidationRules
{
    public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            //definition ıscompleted trueyken boş olamaz
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definiton is required").When(x=>x.IsCompleted).Must(NotBeYavuz).WithMessage("Definiton yavuz olamaz");

        }

        private bool NotBeYavuz(string arg)
        {
          //  yavuza eşit olmassa doğru başarılı dedik
            return arg != "Yavuz" && arg != "yavuz";
        }
    }
}
