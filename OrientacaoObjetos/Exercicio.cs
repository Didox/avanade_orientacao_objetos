using System;
using System.Collections.Generic;
using LogicaAvanade.OrientacaoObjetos;
using Mercearia;

namespace OrientacaoObjetos
{
    public class Exercicio
    {
        private static void ListaItens()
        {
            var lista = Produto.ListaProdutos();
            foreach (var item in lista)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("Nome: " + item.Nome);
                Console.WriteLine("Quantidade: " + item.Quantidade);
                Console.WriteLine("Preco: " + item.Preco);
                Console.WriteLine("=======================");
            }
        }

        private static void CadastrarProduto()
        {
            Console.WriteLine("Cadastre o nome do produto");
            var prod = new Produto();
            prod.Nome = Console.ReadLine();
            Console.WriteLine("Cadastre o preco do produto");
            prod.Preco = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Cadastre o id do produto");
            prod.Id = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Cadastre o quantidade do produto");
            prod.Quantidade = Convert.ToInt16(Console.ReadLine());
            prod.Salvar();
        }

        public static void ExercicioCadastrarProdutosSql()
        {
            Console.WriteLine("Bem vindo Joao, vc tem: " + ProdutoSql.ListaProdutos().Count + " Produtos");

            while (true)
            {
                Console.WriteLine("1 - Cadastrar");
                Console.WriteLine("2 - Remover");
                Console.WriteLine("3 - Listar");
                Console.WriteLine("4 - Sair");

                Console.WriteLine("O que vc deseja fazer, digite a opcao:");
                var opcao = Convert.ToInt16(Console.ReadLine());

                if (opcao == 4) break;

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        CadastrarProdutoSql();
                        break;

                    case 2:
                        ListaItensSql();
                        Console.WriteLine("Digite o Id do produto que deseja excluir");
                        var lixo = Convert.ToInt16(Console.ReadLine());

                        var produto = ProdutoSql.BuscaPorId(lixo);
                        if (produto != null) produto.Remover();
                        else Console.WriteLine("Produto não encontradao");

                        break;

                    case 3:
                        ListaItensSql();
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            }
        }

        private static void ListaItensSql()
        {
            var lista = ProdutoSql.ListaProdutos();
            foreach (var item in lista)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("Nome: " + item.Nome);
                Console.WriteLine("Quantidade: " + item.Quantidade);
                Console.WriteLine("Preco: " + item.Preco);
                Console.WriteLine("=======================");
            }
        }

        private static void CadastrarProdutoSql()
        {
            Console.WriteLine("Cadastre o nome do produto");
            var prod = new ProdutoSql();
            prod.Nome = Console.ReadLine();
            Console.WriteLine("Cadastre o preco do produto");
            prod.Preco = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Cadastre o quantidade do produto");
            prod.Quantidade = Convert.ToInt16(Console.ReadLine());
            prod.Salvar();
        }

        public static void ExercicioCadastrarProdutos()
        {
            Console.WriteLine("Bem vindo Joao, vc tem: " + Produto.ListaProdutos().Count + " Produtos");

            while (true)
            {
                Console.WriteLine("1 - Cadastrar");
                Console.WriteLine("2 - Remover");
                Console.WriteLine("3 - Listar");
                Console.WriteLine("4 - Sair");

                Console.WriteLine("O que vc deseja fazer, digite a opcao:");
                var opcao = Convert.ToInt16(Console.ReadLine());

                if (opcao == 4) break;

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        CadastrarProduto();
                        break;

                    case 2:
                        ListaItens();
                        Console.WriteLine("Digite o Id do produto que deseja excluir");
                        var lixo = Convert.ToInt16(Console.ReadLine());

                        var produto = Produto.BuscaPorId(lixo);
                        if (produto != null) produto.Remover();
                        else Console.WriteLine("Produto não encontradao");

                        break;

                    case 3:
                        ListaItens();
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            }

        }

        public static void ExercicioMediaAlunos()
        {
            while (true)
            {
                Console.WriteLine("Digite 10 para sair do programa ou qualquer coisa para continuar");

                var sair = Convert.ToInt32(Console.ReadLine());
                if (sair == 10) break;


                Console.WriteLine("====================");
                Console.WriteLine("Programa média de alunos");
                Console.WriteLine("====================");

                List<Aluno> alunos = new List<Aluno>();

                Console.WriteLine("Quantos alunos você deseja ?");
                var quantidadeAlunos = Convert.ToInt32(Console.ReadLine());
                for (var i = 0; i < quantidadeAlunos; i++)
                {
                    Aluno a = new Aluno();
                    Console.WriteLine($"Digite o nome do {(i + 1)}º aluno");
                    a.Nome = Console.ReadLine();

                    Console.WriteLine($"Digite a matrícula do aluno {a.Nome}");
                    a.Matricula = Console.ReadLine();

                    for (int x = 0; x < 2; x++)
                    {
                        Console.WriteLine($"Digite a nota {(x + 1)}º do aluno {a.Nome}");
                        var nota = Convert.ToInt32(Console.ReadLine());
                        a.Notas.Add(nota);
                    }
                    alunos.Add(a);
                }


                Console.WriteLine("====================");
                Console.WriteLine("Relatório de alunos");
                Console.WriteLine("====================");

                foreach (var aluno in alunos)
                {
                    Console.WriteLine($"Nome: {aluno.Nome}");
                    Console.WriteLine($"Matrícula: {aluno.Matricula}");
                    Console.WriteLine($"Notas: {String.Join(",", aluno.Notas.ToArray())}");
                    Console.WriteLine($"Media: {aluno.Media()}");
                    Console.WriteLine("====================");
                }

            }
        }
    }
}
