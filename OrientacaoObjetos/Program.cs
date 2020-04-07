using System;
using System.Collections.Generic;
using LogicaAvanade.OrientacaoObjetos;

namespace OrientacaoObjetos
{
    class Program
    {
        static void Main(string[] args)
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
                for(var i = 0; i < quantidadeAlunos; i++)
                {
                    Aluno a = new Aluno();
                    Console.WriteLine($"Digite o nome do {(i+1)}º aluno");
                    a.Nome = Console.ReadLine();

                    Console.WriteLine($"Digite a matrícula do aluno {a.Nome}");
                    a.Matricula = Console.ReadLine();

                    for(int x = 0; x < 2; x++)
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

                foreach(var aluno in alunos)
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
