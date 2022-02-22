using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SquaresAPI.Dtos;
using SquaresAPI.Models;
using SquaresAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SquaresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly PointService _pointService;

        public PointController(PointService pointService)
        {
            _pointService = pointService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _pointService.GetAll());
            }
            catch
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PointInsertDto pointInsertDto)
        {
            try
            {
                return Created("", await _pointService.Insert(pointInsertDto));
            }
            catch (DuplicateEntryException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong. Please try again.");
            }

        }

        [Route("import")]
        [HttpPost]
        public async Task<IActionResult> ImportFile()
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();

            await this._pointService.Import(file);

            return Ok();
        }

        // PUT api/<PointController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PointController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
