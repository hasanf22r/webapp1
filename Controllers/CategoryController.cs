using Microsoft.AspNetCore.Mvc;
using webapp1.Models;
using webapp1.Services.Interfaces;

namespace webapp1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Add([FromQuery] string name)
        {
            _unitOfWork.CategoryService.Add(new Category() { Name = name });
            _unitOfWork.SaveChange();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _unitOfWork.CategoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet]
        public IActionResult Update([FromQuery] string name, [FromQuery] int id)
        {
            _unitOfWork.CategoryService.Update(new Category { Id = id, Name = name });
            _unitOfWork.SaveChange();

            return Ok();
        }
        [HttpGet]
        public IActionResult GetOne([FromQuery] int id)
        {
            var category = _unitOfWork.CategoryService.GetOne(id);
            return Ok(category);
        }

        [HttpDelete]
        public IActionResult Remove([FromQuery] int id)
        {
            _unitOfWork.CategoryService.Remove(new Category { Id = id });
            _unitOfWork.SaveChange();
            return Ok();
        }
    }
}