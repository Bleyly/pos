using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Data;
using POS.Models;
using POS.Service;
using Type = POS.Data.Type;

namespace POS.Controllers
{
    [Authorize(Roles = "Admin")]
    public sealed class ProductController : BaseController<Product>
    {
        private IService<Type> _typeService;
        private IWebHostEnvironment _hostEnvironment;
        public ProductController(IProductService service, IService<Type> typeService, IWebHostEnvironment hostEnvironment) : base(service)
        {
            _hostEnvironment = hostEnvironment;
            _typeService = typeService;
        }

        public override async Task<IActionResult> Create()
        {
            ViewData["Types"] = await _typeService.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWithImage(ProductCreateViewModel productViewModel)
        {
            try
            {
                string imageURL = ProcessUploadedFile(productViewModel.Image);

                var product = new Product
                {
                    Description = productViewModel.Description,
                    Name = productViewModel.Name,
                    ImageURL = imageURL,
                    TypeId = productViewModel.TypeId,
                    Price = productViewModel.Price
                };

                await _service.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public override async Task<IActionResult> Edit([FromRoute] int id)
        {
            try
            {
                var product = await _service.GetAsync(id);

                if (product is null)
                {
                    return NotFound();
                }

                ViewData["Types"] = await _typeService.GetAllAsync();

                return View(new ProductEditViewModel
                {
                    Description = product.Description,
                    Id = product.Id,
                    Image = null,
                    ImageURL = product.ImageURL,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    TypeId = product.TypeId,
                    Price = product.Price
                });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditWithImage(ProductEditViewModel productViewModel)
        {
            try
            {
                var product = await _service.GetAsync(productViewModel.Id);

                product.Description = productViewModel.Description;
                product.Name = productViewModel.Name;
                product.TypeId = productViewModel.TypeId;
                product.Price = productViewModel.Price;

                if (productViewModel.Image != null)
                {
                    System.IO.File.Delete(product.ImageURL);

                    product.ImageURL = ProcessUploadedFile(productViewModel.Image);
                }

                await _service.UpdateAsync(product);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private string ProcessUploadedFile(IFormFile image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                string imagesFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(imagesFolder, uniqueFileName);

                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
