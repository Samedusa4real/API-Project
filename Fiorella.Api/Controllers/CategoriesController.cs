using Fiorella.Services.Dtos.CategoryDtos;
using Fiorella.Services.Dtos.Common;
using Fiorella.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiorella.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("")]
        public ActionResult<CreatedItemDto> Create(CategoryPostDto postDto)
        {
            var data = _categoryService.Create(postDto);
            return StatusCode(201, data);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _categoryService.Delete(id);

            return NoContent();
        }

        [HttpPut("Edit/{id}")]
        public ActionResult Edit(int id, CategoryPutDto putDto)
        {
            _categoryService.Edit(id, putDto);

            return NoContent();
        }

        [HttpGet("Get/{id}")]
        public ActionResult<CategoryGetItemDto> Get(int id)
        {
            var data = _categoryService.Get(id);

            return Ok(data);
        }

        [HttpGet("all")]
        public ActionResult<List<CategoryGetAllItemDto>> GetAll()
        {
            var data = _categoryService.GetAll();

            return Ok(data);
        }

    }
}
