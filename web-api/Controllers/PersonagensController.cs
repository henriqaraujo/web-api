using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Models;

namespace web_api.Controllers {
    //Rota pra acessar o controller
    [ApiController]
    [Route("api/[controller]")]

    public class PersonagensController : ControllerBase {

        //Variável para acessar o banco de dados(AppDbContext) somente para leitura
        private readonly AppDbContext _appDbContext;

        //Construtor para injetar a dependência do banco de dados
        public PersonagensController(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagem([FromBody] Personagem personagem) {

            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }
            _appDbContext.DBZ.Add(personagem);
            await _appDbContext.SaveChangesAsync();

            return Created("Personagem adicionado com sucesso!", personagem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens() {

            var personagens = await _appDbContext.DBZ.ToListAsync();

            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personagem>> GetPersonagem(int id) {

            var personagem = await _appDbContext.DBZ.FindAsync(id);

            if (personagem == null) {
                return NotFound("Personagem não encontrado");
            }

            return Ok(personagem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonagem(int id, [FromBody] Personagem PersonagemAtualizado) {
            var personagemExistente = await _appDbContext.DBZ.FindAsync(id);

            if (personagemExistente == null) {
                return NotFound("Personagem não encontrado");
            }

            _appDbContext.Entry(personagemExistente).CurrentValues.SetValues(PersonagemAtualizado);

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, personagemExistente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonagem(int id) {
            var personagem = await _appDbContext.DBZ.FindAsync(id);

            if (personagem == null) {
                return NotFound("Personagem não encontrado");
            }

            _appDbContext.DBZ.Remove(personagem);

            await _appDbContext.SaveChangesAsync();

            return Ok("Personagem deletado");
        }
    }
}
