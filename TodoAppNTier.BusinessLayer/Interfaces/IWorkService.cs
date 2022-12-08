using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Common.ResponseObjects;
using TodoAppNTier.DtosLayer.Interfaces;
using TodoAppNTier.DtosLayer.WorkDtos;

namespace TodoAppNTier.BusinessLayer.Interfaces
{
   public interface IWorkService
    {
     //   Task<List<WorkListDto>> GetAll();
        Task<IResponse<List<WorkListDto>>> GetAll();
        //neden IResponse değilde IResponse<WorkCreateDto> baktığnızda sadece task di
        //sebebeide şu gelen dtonun içerisinde validation hatası olabilir dolayısıyla ne yapmam lazım
        //dtoyla beraber validation hatalarını geri dönmemm lazım bunun için
      //  Task Create(WorkCreateDto dto);
        Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto);
        //Task<IDto> GetById<IDto>(int id);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        //Remove işlemi için sadece response kullanabilirim neden çünkü benim validation 
        //işlemim yok bir hatayla karşılaşırsam o ıdyı bulamamdım şeklinde geri dönecek
     //   Task Remove(int id);
        Task<IResponse> Remove(int id);
       // Task Update(WorkUpdateDto dto);
        Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto);
    }
}
