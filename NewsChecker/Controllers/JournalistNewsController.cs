using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using NewsChecker.Data;
using NewsChecker.Data.DTO.Journalist;
using NewsChecker.Data.DTO.JournalistNews;
using NewsChecker.Models;
using NewsChecker.Services;

namespace NewsChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JournalistNewsController : ControllerBase
    {
        JournalistNewsService _service;

        public JournalistNewsController(JournalistNewsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        [HttpGet("{journalistId}/{newsId}")]
        public IActionResult Get(int journalistId, int newsId)
        {
            ReadJournalistNewsDTO? journalistNewsDTO = _service.Get(journalistId, newsId);

            if (journalistNewsDTO != null)
            {
                return Ok(journalistNewsDTO);
            }

            return NotFound();
        }

        [HttpGet("News/{newsId}")]
        public IActionResult GetByNews(int newsId)
        {
            return Ok(_service.GetByNews(newsId));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateJournalistNewsDTO journalistNewsDTO)
        {
            ReadJournalistNewsDTO readDTO = _service.Post(journalistNewsDTO);

            return CreatedAtAction(nameof(Get), new { readDTO.JournalistId, readDTO.NewsId }, readDTO);
        }

        [HttpDelete("{journalistId}/{newsId}")]
        public IActionResult Delete(int journalistId, int newsId)
        {
            Result result = _service.Delete(journalistId, newsId);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
