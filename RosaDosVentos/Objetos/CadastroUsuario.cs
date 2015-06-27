using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entidades;
using Regras.Interface;

namespace Regras
{
    public class CadastroUsuario : Cadastro<Usuario>
    {
        public Usuario Retorna(string usuario, string senha)
        {
            var consulta = RetornaTodos().FirstOrDefault(x => x.Login == usuario && x.Senha == senha);
            return consulta;
        }

        public bool Logar(string usuario, string senha, out Usuario retorno)
        {
            retorno = new Usuario();
            try
            {
                if (string.IsNullOrEmpty(usuario))
                    throw new Exception("Usuário Inválido!");

                if (string.IsNullOrEmpty(senha))
                    throw new Exception("Senha Inválida!");

                var user = Retorna(usuario, senha);

                if (user != null)
                {
                    if (!user.Ativo)
                        throw new Exception("Usuário Inativo!");

                    retorno = user;
                    return true;
                }
                throw new Exception("Usuário e/ou Senha Inválido(s)!");
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public bool ValidarLogin(string login, int? id = null)
        {
            var consulta = RetornaTodos().Where(x => x.Login.ToUpper().Trim().Contains(login.ToUpper().Trim()));
            if (id != null)
                consulta = consulta.Where(x => x.Id != id);

            return consulta.Any();
        }

        public bool ValidarEmail(string email, int? id = null)
        {
            var consulta = RetornaTodos().Where(x => x.Email.ToUpper().Trim().Contains(email.ToUpper().Trim()));
            if (id != null)
                consulta = consulta.Where(x => x.Id != id);

            return consulta.Any();
        }

        public bool VerificarEMail(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            return match.Success;
        }
    }
}
