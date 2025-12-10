using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reprise_back.Models.Dto;
using Reprise_back.Service.Interface;
using System.Security.Claims;

namespace Reprise_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDataFilmController : ControllerBase
    {
        private readonly IUserDataFilmService _service;
        public UserDataFilmController(IUserDataFilmService service) => _service = service;

        private string GetUserId()
        {
            // "oid" = Object ID (unique par tenant)
            var oid = User.FindFirstValue("http://schemas.microsoft.com/identity/claims/objectidentifier");
            if (!string.IsNullOrEmpty(oid)) return oid;

            // "sub" = Subject (unique par app)
            var sub = User.FindFirstValue("sub");
            return sub ?? throw new Exception("User ID not found in token");
        }


        [HttpPost("update")]
        [Authorize]
        public async Task<IActionResult> UpdateUserFilmRate([FromBody] UpdateFilmRateDto dto)
        {
            string userId = GetUserId();
            await _service.UpdateFilmRate(dto.Rate, dto.FilmId, userId);
            return Ok();
        }
    }
}
