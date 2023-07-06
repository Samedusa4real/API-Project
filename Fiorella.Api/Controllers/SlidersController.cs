using Fiorella.Services.Dtos.Common;
using Fiorella.Services.Dtos.SliderDtos;
using Fiorella.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiorella.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [HttpPost("")]
        public ActionResult<CreatedItemDto> Create([FromForm]SliderPostDto postDto)
        {
            var data = _sliderService.Create(postDto);

            return StatusCode(201, data);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _sliderService.Delete(id);

            return NoContent();
        }

        [HttpPut("Edit/{id}")]
        public ActionResult Edit(int id,[FromForm] SliderPutDto sliderPutDto)
        {
            _sliderService.Edit(id, sliderPutDto);

            return NoContent();
        }

        [HttpGet("Get/{id}")]
        public ActionResult<SliderGetItemDto> Get(int id)
        {
            var data = _sliderService.Get(id);

            return Ok(data);
        }

        [HttpGet("all")]
        public ActionResult<List<SliderGetAllItemDto>> GetAll()
        {
            var data = _sliderService.GetAll();

            return Ok(data);
        }
    }
}
