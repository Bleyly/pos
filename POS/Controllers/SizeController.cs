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

namespace POS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SizeController : Controller
    {
        private readonly ILogger<SizeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SizeController(ILogger<SizeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Sizes.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Size Size)
        {
            try
            {
                await _unitOfWork.Sizes.CreateAsync(Size);

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
                var Size = await _unitOfWork.Sizes.GetAsync(id);

                if (Size is null)
                {
                    return NotFound();
                }

                return View(Size);
            }
            catch (Exception exception)
            {
                _logger.LogError(500, exception.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Edit(Size Size)
        {
            try
            {
                _unitOfWork.Sizes.Update(Size);

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
                await _unitOfWork.Sizes.DeleteAsync(id);
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
