using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsChecker.Data;
using NewsChecker.Data.DTO.Newspaper;
using NewsChecker.Models;
using NewsChecker.Services;

namespace NewsChecker.Controllers
{
    [ApiController]
    //[Route("[controller]"), Authorize]
    [Route("[controller]")]
    public class NewspaperController : ControllerBase
    {
        NewspaperService _service;

        public NewspaperController(NewspaperService service)
        {
            _service = service;;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ReadNewspaperDTO newspaperDTO = _service.Get(id);

            if (newspaperDTO != null)
            {
                return Ok(newspaperDTO);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin, regular", Policy = "MinAge")]
        public IActionResult Post([FromBody] CreateNewspaperDTO newspaperDTO)
        {
            ReadNewspaperDTO readDTO = _service.Post(newspaperDTO);

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
