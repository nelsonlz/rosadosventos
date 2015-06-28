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
            var cadastroDeObra = new CadastroDeObra();

            cadastroUsuario.Incluir(new Usuario { Ativo = true, DataCriacao = DateTime.Now, Email = "teste@teste.com", Login = "admin", Nome = "Admin", Nivel = "A", Senha = "admin" });
            cadastroUsuario.Incluir(new Usuario { Ativo = true, DataCriacao = DateTime.Now, Email = "teste@teste.com", Login = "user", Nome = "User", Nivel = "L", Senha = "user" });
            //Inserir aqui os cadastros que devem estar no banco em sua criação

            foreach (var item in cadastroUsuario.RetornaTodos())
            {
                Console.WriteLine("ID = {0}, Nome = {1}, Nivel = {2}", item.Id, item.Nome, item.NivelEnum);
            }

            cadastroDeObra.Incluir(new Obra
            {
                Nome = "Obra teste",
                DataDeInicio = DateTime.Now,
                Eventos = new List<Evento>(){ new Evento{  Descricao = "Evento 01", Titulo = "Evento 01", DataDoOcorrido = DateTime.Now.AddDays(0), Imagem = "Imagens/Evento/1-01.jpg"},
                                              new Evento{  Descricao = "Evento 02", Titulo = "Evento 02", DataDoOcorrido = DateTime.Now.AddDays(1), Imagem = "Imagens/Evento/1-02.jpg"},
                                              new Evento{  Descricao = "Evento 03", Titulo = "Evento 03", DataDoOcorrido = DateTime.Now.AddDays(2), Imagem = "Imagens/Evento/1-03.jpg"},
                                              new Evento{  Descricao = "Evento 04", Titulo = "Evento 04", DataDoOcorrido = DateTime.Now.AddDays(3), Imagem = "Imagens/Evento/1-04.jpg"},
                                              new Evento{  Descricao = "Evento 05", Titulo = "Evento 05", DataDoOcorrido = DateTime.Now.AddDays(4), Imagem = "Imagens/Evento/1-05.jpg"},
                                              new Evento{  Descricao = "Evento 06", Titulo = "Evento 06", DataDoOcorrido = DateTime.Now.AddDays(5), Imagem = "Imagens/Evento/1-06.jpg"},
                                              new Evento{  Descricao = "Evento 07", Titulo = "Evento 07", DataDoOcorrido = DateTime.Now.AddDays(6), Imagem = "Imagens/Evento/1-07.jpg"},
                                              new Evento{  Descricao = "Evento 08", Titulo = "Evento 08", DataDoOcorrido = DateTime.Now.AddDays(7), Imagem = "Imagens/Evento/1-08.jpg"},
                                              new Evento{  Descricao = "Evento 09", Titulo = "Evento 09", DataDoOcorrido = DateTime.Now.AddDays(8), Imagem = "Imagens/Evento/1-09.jpg"},
                                              new Evento{  Descricao = "Evento 10", Titulo = "Evento 10", DataDoOcorrido = DateTime.Now.AddDays(10), Imagem = "Imagens/Evento/1-10.jpg"},
                                            }

            });

            foreach (var item in cadastroDeObra.RetornaTodos())
            {
                Console.WriteLine("ID = {0}, Nome = {1}, Data de Inicio = {2}, Data de Término = {3}", item.Id, item.Nome, item.DataDeInicio, item.DataDeTermino);
                Console.WriteLine("-----------");
                foreach (var evento in item.Eventos)
                {
                    Console.WriteLine("ID = {0}, Titulo = {1}, Descricao = {2}, Data = {3}, Imagem = {4}", evento.Id, evento.Titulo, evento.Descricao, evento.DataDoOcorrido, evento.Imagem);
                }
            }

            Console.ReadLine();
        }
    }
}
