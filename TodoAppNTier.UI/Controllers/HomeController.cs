
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppNTier.BusinessLayer.Interfaces;
using TodoAppNTier.Common.ResponseObjects;
using TodoAppNTier.DtosLayer.WorkDtos;
using TodoAppNTier.UI.Extension;

namespace TodoAppNTier.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;


        public HomeController(IWorkService workService)
        {
            _workService = workService;

        }

        public async Task<IActionResult> Index()
        {
           // var list = await _workService.GetAll();
           var response= await _workService.GetAll();
           
                 return View(response.Data);
            
           
        }
        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {


           var response= await _workService.Create(dto);
            return this.ResponseRedirecToAction(response, "index");
           // if (response.ResponseType == ResponseType.ValidationError)
           // {
           //      foreach (var error in response.ValidationErrors)
           //     {
           //         ModelState.AddModelError(error.ProperTyName, error.Errormesage);
           //     }
           //     return View(dto);

           //}
           // else
           // {
           //     return RedirectToAction("index");
           // }
          
           


            
        }
        public async Task<IActionResult> Update(int id)
        {

            //var dto = await _workService.GetById(id);
            //return View(_mapper.Map<WorkUpdateDto>(dto));
            //getbyıd bana doğrudan workliststo dönüyor dolayısıyla ben 
            //dönen worklistdto yu work uptade dtoya çevirmek zorunda kalıyorum
            //bunu düzeltecz Refactor
            //var dto = await _workService.GetById<WorkUpdateDto>(id);
            var response = await _workService.GetById<WorkUpdateDto>(id);
            return this.ResponseView(response);
            //if (response.ResponseType == ResponseType.NotFound)
            //{
            //    return NotFound();
            //}
            //return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            //ModalSattelere gerek yok validationı business tarafında yapıyoruz
            // if (ModelState.IsValid)
            // {

           var response= await _workService.Update(dto);
            return this.ResponseRedirecToAction(response, "index");
            //if (response.ResponseType == ResponseType.ValidationError)
            //{
            //    foreach (var error in response.ValidationErrors)
            //    {
            //        ModelState.AddModelError(error.ProperTyName, error.Errormesage);
            //    }
            //    return View(dto);

            //}
            //return RedirectToAction("index");
            //}

            // return View(dto);
        }
        public async Task<IActionResult> Remove(int id)
        {
           var response= await _workService.Remove(id);
            return this.ResponseRedirecToAction(response, "index");
            //if (response.ResponseType == ResponseType.NotFound)
            //{
            //    return NotFound();
            //}
            //return RedirectToAction("index");
        }
        public  IActionResult NotFound(int code)
        {
            return View();
        }
    }
}
