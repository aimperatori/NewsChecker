using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsChecker.Models;
using NewsChecker.Data.DTO.Edition;
using NewsChecker.Data;
using NewsChecker.Services;
using FluentResults;

namespace NewsChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditionController : ControllerBase
    {
        EditionService _editionService;

        public EditionController(EditionService editionService)
        {
            _editionService = editionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_editionService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ReadEditionDTO? editionDTO = _editionService.Get(id);

            if (editionDTO != null)
            {
                return Ok(editionDTO);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateEditionDTO editionDTO)
        {
            ReadEditionDTO readDTO = _editionService.Post(editionDTO);

            return CreatedAtAction(nameof(Get), new { readDTO.Id }, readDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateEditionDTO editionDTO)
        {
            Result result = _editionService.Put(editionDTO, id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Result result = _editionService.Delete(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
