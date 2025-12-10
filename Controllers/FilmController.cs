using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reprise_back.Models.Dto;
using Reprise_back.Service.Interface;
using System.Security.Claims;

namespace Reprise_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _service;
        public FilmController(IFilmService service) => _service = service;

        private string GetUserId()
        {
            var oid = User.FindFirstValue("http://schemas.microsoft.com/identity/claims/objectidentifier");
            if (!string.IsNullOrEmpty(oid)) return oid;
            var sub = User.FindFirstValue("sub");
            return sub ?? "";
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            string userId = GetUserId();
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) {
            var userId = GetUserId();
            return Ok(await _service.GetByIdAsync(id, userId));
        }
        

        [HttpPost("update")]
        public async Task<IActionResult> Create(FilmDto film)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.AddAsync(film);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(FilmDto film)
        {
            if (!ModelState.IsValid || film.Id.Equals(null))
                return BadRequest(ModelState);
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
