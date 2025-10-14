using FluentResults;
using Microsoft.AspNetCore.Mvc;
using NewsChecker.Data.DTO.News;
using NewsChecker.Services;

namespace NewsChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly NewsService _service;

        public NewsController(NewsService service)
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
            ReadNewsDTO? newsDTO = _service.Get(id);

            if (newsDTO != null)
            {
                return Ok(newsDTO);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateNewsDTO newsDTO)
        {
            ReadNewsDTO readDTO = _service.Post(newsDTO);

            return CreatedAtAction(nameof(Get), new { readDTO.Id }, readDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateNewsDTO newDTO)
        {
            Result result = _service.Put(newDTO, id);

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
