using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.BusinessLayer.Extension;
using TodoAppNTier.BusinessLayer.Interfaces;
using TodoAppNTier.BusinessLayer.ValidationRules;
using TodoAppNTier.Common.ResponseObjects;
using TodoAppNTier.DataAccesLayer.UnitofWork;
using TodoAppNTier.DtosLayer.Interfaces;
using TodoAppNTier.DtosLayer.WorkDtos;
using TodoAppNTier.EntityLayer.Concrete_Domains;

namespace TodoAppNTier.BusinessLayer.Services
{
    public class WorkService : IWorkService
    {
       private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDto> _createdtovalidator;
        private readonly IValidator<WorkUpdateDto> _updatedtovalidator;
        public WorkService(IUow uow, IMapper mapper, IValidator<WorkCreateDto> createdtovalidator, IValidator<WorkUpdateDto> updatedtovalidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createdtovalidator = createdtovalidator;
            _updatedtovalidator = updatedtovalidator;
        }

        public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
        {
            // var validator = new WorkCreateDtoValidator();
            //var validatorResult= validator.Validate(dto);
            var validationResult = _createdtovalidator.Validate(dto);
          
            if (validationResult.IsValid)
            { 
                await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _uow.SaveChanges();
                return new Response<WorkCreateDto>(ResponseType.Success, dto);

            }
            else
            {
               
                return new Response<WorkCreateDto>(ResponseType.ValidationError, dto,validationResult.ConvertToCustomValidationError());
            }
            //biz burda bir dto yu alıyoruz o dto yu çevirip  work gönderiyoruz 
         //await  _uow.GetRepository<Work>().Create(new()
         //   {
         //       IsCompleted=dto.IsCompleted,
         //       Definition=dto.Definition
         //   });
         //bunu newle ele almak yerine
         //WorkCreateDto yu Work e çeviriyoruz.
           
        }

        public async Task<IResponse<List<WorkListDto>>> GetAll()
        {
            //bana work listesi geliyor
            //bunu worklistdto ya çeviriyorum geri dönüyorum
            //ben bir nesneyi başşka bir nesneye çevirirken bazı kütüphanelerden yararlanabilirim
            //unitofwork aracılığıyla datacaccess e gidiyorum
            //daha sonra çekmiş olduğum veride kontrol yapıyorum
            //kontrollden sonra mableme işlemini gerçekleştiriyorum
            //geriye dönüyorum
            //var list= await _uow.GetRepository<Work>().GetAll();

            //var workList = new List<WorkListDto>();

            //if(list!= null && list.Count > 0)
            //{
            //    foreach (var work in list)
            //    {
            //        workList.Add(new()
            //        {
            //            Definition = work.Definition,
            //            Id=work.Id,
            //            IsCompleted=work.IsCompleted
            //        }) ;
            //    }
            //}
            //önce neye çevireceğimi yazıyorum sonra neyi çevireceğimi
            var data= _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
            return new Response<List<WorkListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            //var work = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);
            //return new()
            //{
            //    Definition = work.Definition,
            //    IsCompleted = work.IsCompleted

            //};
            var data= _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $" {id} ye ait data BULUNAMADI");
            }
            return new Response<IDto>(ResponseType.Success,data);

        }

        public async Task<IResponse> Remove(int id)
        {
            //var deletıd = await _uow.GetRepository<Work>().GetById(id);
        var entry  =await _uow.GetRepository<Work>().GetByFilter(x=>x.Id == id);
            if(entry!= null)
            {
               _uow.GetRepository<Work>().Remove(entry);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $" {id} ye ait data BULUNAMADI");
            
        }

        public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
        {
            var result = _updatedtovalidator.Validate(dto);
            if (result.IsValid)
            {
                var updateentity = await _uow.GetRepository<Work>().Find(dto.Id);
                if (updateentity != null)
                {
                    _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto), updateentity);
                    await _uow.SaveChanges();
                    return new Response<WorkUpdateDto>(ResponseType.Success, dto);

                }
                return new Response<WorkUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data BULUNAMADI");
            }
            else
            {
               
                return new Response<WorkUpdateDto>(ResponseType.ValidationError, dto,result.ConvertToCustomValidationError());
            }

            }
            
        }
    }

