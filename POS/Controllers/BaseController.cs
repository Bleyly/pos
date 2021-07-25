using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.Data;
using POS.Service;

namespace POS.Controllers
{
    public abstract class BaseController<T> : Controller where T : class
    {
        protected readonly IService<T> _service;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _service = new BaseService<T>(unitOfWork);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(T entity)
        {
            try
            {
                await _service.CreateAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            try
            {
                var entity = await _service.GetAsync(id);

                if (entity is null)
                {
                    return NotFound();
                }

                return View(entity);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Edit(T entity)
        {
            try
            {
                _service.UpdateAsync(entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _service.DeleteAsync(id);

                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
