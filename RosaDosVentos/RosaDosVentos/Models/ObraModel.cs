using Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosaDosVentos.Models
{
    public class ObraModel
    {
        public ObraModel()
        {
            this.Eventos = new List<EventosModel>();
        }
        public List<EventosModel> Eventos { get; set; }
    }


    public class EventosModel
    {
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string Titulo { get; set; }
        public DateTime DataDoOcorrido { get; set; }
    }
}