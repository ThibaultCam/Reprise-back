using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Reprise_back.Models;
using Reprise_back.Models.DTO;
using Reprise_back.Service.Interface;

namespace Reprise_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SerieController : ControllerBase
    {
        private readonly ISeriesService _service;
        public SerieController(ISeriesService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(SerieDto film)
        {
            var created = await _service.AddAsync(film);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, SerieDto serie)
        {
            serie.Id = id;
            await _service.UpdateAsync(serie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
