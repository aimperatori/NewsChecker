using Microsoft.AspNetCore.Mvc;
using NewsChecker.Services;
using System.Collections;

namespace NewsChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly SearchService _searchSerive;

        public SearchController(SearchService searchSerive)
        {
            _searchSerive = searchSerive;
        }

        [HttpGet("basic")]
        public IActionResult SearchBasic([FromQuery] string text)
        {
            IEnumerable list = _searchSerive.BasicSearch(text);

            return Ok(list);
        }
    }
}
