using Microsoft.AspNetCore.Mvc;

namespace Reprise_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VocabController : ControllerBase
    {
        private static readonly List<string> Mots = new List<string>
        {
            "chat",
            "chien",
            "maison",
            "voiture",
            "arbre"
        };

        [HttpGet("{id}")]
        public ActionResult<string> GetMotById(int id)
        {
            if (id < 0 || id >= Mots.Count)
                return NotFound("Mot non trouvé.");

            return Ok(new { mot = Mots[id] });
        }

        // GET api/vocab
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetTousLesMots()
        {
            return Ok(Mots);
        }
    }
}
