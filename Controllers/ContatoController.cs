using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiModulo.Context;
using ApiModulo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiModulo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        //atrubuto privado (somente leitura)
        private readonly AgendaContext _context;
        
        //costrutor para receber  context
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new{id = contato.Id}, contato);
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
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }



        
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}