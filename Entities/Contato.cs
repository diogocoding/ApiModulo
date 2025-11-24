using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiModulo.Entities
{
    public class Contato
    {
        public int Id {get; set;}
        public string Nome {get;set;}
        public string Telefone {get;set;}
        public string Ativo {get;set;}
    }
}

