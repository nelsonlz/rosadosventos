using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Obra : Entidade
    {
        public Obra()
        {
            if (this.Eventos == null)
                this.Eventos = new List<Evento>();
        }
        public string Nome { get; set; }
        public DateTime DataDeInicio { get; set; }
        public DateTime? DataDeTermino { get; set; }
        public ICollection<Evento> Eventos { get; set; }

    }
}
