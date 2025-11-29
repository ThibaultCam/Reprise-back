using Microsoft.AspNetCore.Mvc;
using Reprise_back.Models;
using Reprise_back.Models.Dto;
using Reprise_back.Service.Interface;

namespace Reprise_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _service;
        public FilmController(IFilmService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(FilmDto film)
        {
            var created = await _service.AddAsync(film);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, FilmDto film)
        {
            film.Id = id;
            await _service.UpdateAsync(film);
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
