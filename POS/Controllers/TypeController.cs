using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POS.Data;
using POS.Models;
using Type = POS.Data.Type;

namespace POS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TypeController : Controller
    {
        private readonly ILogger<TypeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TypeController(ILogger<TypeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Types.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Type Type)
        {
            try
            {
                await _unitOfWork.Types.CreateAsync(Type);

                await _unitOfWork.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                _logger.LogError(500, exception.Message);
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            try
            {
                var Type = await _unitOfWork.Types.GetAsync(id);

                if (Type is null)
                {
                    return NotFound();
                }

                return View(Type);
            }
            catch (Exception exception)
            {
                _logger.LogError(500, exception.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Edit(Type Type)
        {
            try
            {
                _unitOfWork.Types.Update(Type);

                _unitOfWork.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                _logger.LogError(500, exception.Message);
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _unitOfWork.Types.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return StatusCode(200);
            }
            catch (Exception exception)
            {
                _logger.LogError(500, exception.Message);
                return StatusCode(500);
            }
        }
    }
}
