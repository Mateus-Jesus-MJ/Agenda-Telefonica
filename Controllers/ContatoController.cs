using Microsoft.AspNetCore.Mvc;
using ModuloApi.Entities;
using ModuloApi.Context;

namespace ModuloApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return OK(contato);
        }


        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorId(nome id)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, ContatoController contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contato == null)
                return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contato == null)
                return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
