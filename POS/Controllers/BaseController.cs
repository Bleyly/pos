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

        public BaseController(IService<T> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        public virtual Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(View());
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

        public virtual async Task<IActionResult> Edit([FromRoute] int id)
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
        public async Task<IActionResult> Edit(T entity)
        {
            try
            {
                await _service.UpdateAsync(entity);

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
