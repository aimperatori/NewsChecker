using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsChecker.Data;
using NewsChecker.Data.DTO.Newspapper;
using NewsChecker.Models;
using NewsChecker.Services;

namespace NewsChecker.Controllers
{
    [ApiController]
    //[Route("[controller]"), Authorize]
    [Route("[controller]")]
    public class NewspapperController : ControllerBase
    {
        NewspapperService _service;

        public NewspapperController(NewspapperService service)
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
            ReadNewspapperDTO NewspapperDTO = _service.Get(id);

            if (NewspapperDTO != null)
            {
                return Ok(NewspapperDTO);
            }

            return NotFound();
        }

        [HttpPost]
        //[Authorize(Roles = "admin, regular", Policy = "MinAge")]
        public IActionResult Post([FromBody] CreateNewspapperDTO NewspapperDTO)
        {
            ReadNewspapperDTO readDTO = _service.Post(NewspapperDTO);

            return CreatedAtAction(nameof(Get), new { readDTO.Id }, readDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateNewspapperDTO newpaperDTO)
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
