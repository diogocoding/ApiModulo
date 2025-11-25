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
            return Ok(contato);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
          var contato = _context.Contatos.Find(id);

        if (contato == null) 
            return NotFound();


          return Ok(contato);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar (int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }
    }
}