using FluentResults;
using Microsoft.AspNetCore.Mvc;
using NewsChecker.Data.DTO.Newspaper;
using NewsChecker.Services;

namespace NewsChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewspaperController : ControllerBase
    {
        private readonly NewspaperService _service;

        public NewspaperController(NewspaperService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var newspaperDto = _service.Get(id);

            if (newspaperDto != null)
            {
                return Ok(newspaperDto);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateNewspaperDTO newspaperDto)
        {
            ReadNewspaperDTO readDTO = _service.Post(newspaperDto);

            return CreatedAtAction(nameof(Get), new { readDTO.Id }, readDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateNewspaperDTO newpaperDTO)
        {
            Result result = _service.Put(newpaperDTO, id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Result result = _service.Delete(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
