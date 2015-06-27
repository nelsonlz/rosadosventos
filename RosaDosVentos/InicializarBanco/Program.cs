using Entidades;
using MySql.Data.MySqlClient;
using Persistencia;
using Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InicializarBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            var cadastroUsuario = new CadastroUsuario();

            cadastroUsuario.Incluir(new Usuario { Ativo = true, DataCriacao = DateTime.Now, Email = "teste@teste.com", Login = "admin", Nome = "Admin", Nivel = "A", Senha = "teste" });
            //Inserir aqui os cadastros que devem estar no banco em sua criação

            foreach (var item in cadastroUsuario.RetornaTodos())
            {
                Console.WriteLine("ID = {0}, Nome = {1}, Nivel = {2}", item.Id, item.Nome, item.NivelEnum);
            }
            Console.ReadLine();

           
        }
    }
}
