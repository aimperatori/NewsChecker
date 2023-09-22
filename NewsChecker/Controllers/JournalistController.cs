using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using NewsChecker.Data;
using NewsChecker.Data.DTO.Journalist;
using NewsChecker.Models;
using NewsChecker.Services;

namespace NewsChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JournalistController : ControllerBase
    {
        JournalistService _journalitService;

        public JournalistController(JournalistService _journalistService)
        {        
            _journalitService = _journalistService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_journalitService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ReadJournalistDTO? journalistDTO = _journalitService.Get(id);

            if (journalistDTO != null)
            {
                return Ok(journalistDTO);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateJournalistDTO journalistDTO)
        {
            ReadJournalistDTO readDTO = _journalitService.Post(journalistDTO);

            return CreatedAtAction(nameof(Get), new { readDTO.Id }, readDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdateJournalistDTO journalistDTO, int id)
        {
            Result result = _journalitService.Put(journalistDTO, id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Result result = _journalitService.Delete(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
