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
    public class ColorController : Controller
    {
        private readonly ILogger<ColorController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ColorController(ILogger<ColorController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Colors.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Color color)
        {
            try
            {
                await _unitOfWork.Colors.CreateAsync(color);

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
                var color = await _unitOfWork.Colors.GetAsync(id);

                if (color is null)
                {
                    return NotFound();
                }

                return View(color);
            }
            catch (Exception exception)
            {
                _logger.LogError(500, exception.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Edit(Color color)
        {
            try
            {
                _unitOfWork.Colors.Update(color);

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
                await _unitOfWork.Colors.DeleteAsync(id);
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
