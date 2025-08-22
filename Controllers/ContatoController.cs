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
            var contato = _context.Contato.Find(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }
    }
}