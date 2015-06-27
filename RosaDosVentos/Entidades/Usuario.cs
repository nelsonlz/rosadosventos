using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario : Entidade
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        [Description("Nome Completo: ")]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        public string Nivel { get; set; }

        public Nivel NivelEnum { get { var helper = new NivelHelper(); return helper.ObtemValor(Nivel); } }

        public bool Ativo { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        public DateTime? DataInativo { get; set; }

        public string CodigoAtivacao { get; set; }

        public Usuario()
        {
            this.Nivel = "L";
        }
    }

    public enum Nivel
    {
        Administrador,
        Colaborador,
        Leitor
    }

    public class NivelHelper
    {
        public string RetornaValor(Nivel valor)
        {
            switch (valor)
            {
                case Nivel.Administrador:
                    return "A";
                case Nivel.Colaborador:
                    return "C";
                default:
                    return "L";
            }
        }

        public Nivel ObtemValor(string valor)
        {
            switch (valor)
            {
                case "A":
                    return Nivel.Administrador;
                case "C":
                    return Nivel.Colaborador;
                default:
                    return Nivel.Leitor;
            }
        }
    }
}
