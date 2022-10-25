using Microsoft.AspNetCore.Mvc;
using webapp1.DTOs;
using webapp1.Models;
using webapp1.Services.Interfaces;

namespace webapp1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Add([FromForm] AddProductDto dto)
        {
            string image = "default.jpg";
            if (dto.Image != null)
            {
                image = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(dto.Image.FileName);
                using (var stream = new FileStream("wwwroot/" + image, FileMode.CreateNew))
                {
                    dto.Image.CopyTo(stream);
                }
            }
            _unitOfWork.ProductService.Add(new Product() { Name = dto.Name, CategoryId = dto.CategoryId, Price = dto.Price, Image = image });
            _unitOfWork.SaveChange();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _unitOfWork.ProductService.GetAll();
            return Ok(products);
        }

        [HttpGet]
        public IActionResult GetOne([FromQuery] int id)
        {
            var products = _unitOfWork.ProductService.GetOne(id);
            return Ok(products);
        }


        [HttpPost]
        public IActionResult Update([FromForm] AddProductDto dto)
        {
            string image = "default.jpg";
            
            if (dto.Image != null)
            {
                image = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(dto.Image.FileName);
                using (var stream = new FileStream("wwwroot/" + image, FileMode.CreateNew))
                {
                    dto.Image.CopyTo(stream);
                }
            }

            _unitOfWork.ProductService.Add(new Product() { Name = dto.Name, CategoryId = dto.CategoryId, Price = dto.Price, Image = image });
            _unitOfWork.SaveChange();
            return Ok();
        }


        [HttpDelete]
        public IActionResult Remove([FromQuery] int id)
        {
            _unitOfWork.ProductService.Remove(new Product { Id = id });
            _unitOfWork.SaveChange();

            return Ok();
        }
    }
}