using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Evento : Entidade
    {
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string Titulo { get; set; }
        public DateTime DataDoOcorrido { get; set; }

        public Obra Obra { get; set; }
    }
}
