using System;
using System.Collections.Generic;

namespace LogicaAvanade
{
    class Program
    {
        public static void calculaMedia()
        {
            Console.WriteLine("Digite a quantidade de notas");
            var qtd = Convert.ToInt16(Console.ReadLine());
            int[] notas = new int[qtd];

            int i = 0;
            while (i < qtd)
            {
                Console.WriteLine("Digite a nota " + (i + 1) + "º do aluno ");
                notas[i] = Convert.ToInt16(Console.ReadLine());

                i++;
            }

            var somaNotas = 0;
            foreach (int nota in notas)
            {
                somaNotas += nota;
            }

            var media = somaNotas / notas.Length;

            Console.WriteLine("A média do aluno é: " + media);

            if (media < 5)
            {
                Console.WriteLine("Poxa você reprovou este semestre");
            }
            else if (media >= 5 && media <= 7)
            {
                Console.WriteLine("Opa sua média precisa ser melhorada");
            }
            else
            {
                Console.WriteLine("Você está aprovado");
            }

            switch (media)
            {
                case 5:
                    Console.WriteLine("Você precisa melhorar");
                    break;
                case 6:
                    Console.WriteLine("Você precisa melhorar quase lá");
                    break;
                case 7:
                    Console.WriteLine("Você precisa melhorar é isso ai");
                    break;
                default:
                    if (media > 7)
                    {
                        Console.WriteLine("Parabéns");
                    }
                    else
                    {
                        Console.WriteLine("Você está reprovado");
                    }
                    break;
            }
        }

        private static void tabuadaRecurviva(int numeroInicial, int multiplicador, int numeroFinal)
        {
            if (numeroInicial > numeroFinal) return;

            Console.WriteLine($"{numeroInicial} x {multiplicador} = {(numeroInicial * multiplicador)}");

            tabuadaRecurviva(numeroInicial + 1, multiplicador, numeroFinal);

            Console.WriteLine("Estado número inicial: " + numeroInicial);
        }

        static void Main(string[] args)
        { 

            while (true)
            {
                Program.mostraDadosTela();
                var n = Convert.ToInt16(Console.ReadLine());

                var sair = false;
                switch (n)
                {
                    case 1:
                        Program.calculaMediaRecursiva();
                        break;
                    case 2:
                        Program.executaTabuadaRecurvida();
                        break;
                    case 10:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                if (sair) break;
            }
        }

        private static void mostraDadosTela()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("*************************************");
            Console.WriteLine("Digite uma das opções abaixo");
            Console.WriteLine("1) Executar média");
            Console.WriteLine("2) Calculo de tabuada");
            Console.WriteLine("10) Sair do programa");
            Console.WriteLine("*************************************");
        }

        private static void executaTabuadaRecurvida()
        {
            Console.WriteLine("Digite o numero inicial");
            var nInicial = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Digite o multiplicador");
            var multiplicador = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Digite o numero final");
            var nFinal = Convert.ToInt16(Console.ReadLine());
            Program.tabuadaRecurviva(nInicial, multiplicador, nFinal);
        }

        private static void calculaMediaRecursiva()
        {
            List<string> nomes = new List<string>();
            List<string> matriculas = new List<string>();
            List<List<int>> notasAlunos = new List<List<int>>();

            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine("O nome do aluno " + (i+1) + "");
                var nome = Console.ReadLine();
                nomes.Add(nome);

                Console.WriteLine("A matricula do aluno " + (i + 1) + "");
                var matricula = Console.ReadLine();
                matriculas.Add(matricula);

                Console.WriteLine("Digite a quantidade de notas");
                var qtd = Convert.ToInt16(Console.ReadLine());
                var notas = new List<int>();
                notas = preencheNotasAluno(1, qtd, notas);
                notasAlunos.Add(notas);
            }

            for(var i=0;i< nomes.Count; i++)
            {
                Console.WriteLine($"Nome: {nomes[i]}");
                Console.WriteLine($"Matrícula: {matriculas[i]}");
                var notas = notasAlunos[i];
                Console.WriteLine($"Notas: {String.Join(",", notas.ToArray())}");

                int somaNotas = 0;
                foreach(var nota in notas)
                {
                    somaNotas += nota;
                }
                int media = somaNotas / notas.Count;

                Console.WriteLine($"Media: {media}");
                Console.WriteLine("====================");
            }
            

        }

        private static List<int> preencheNotasAluno(int i, int qtd, List<int> notas)
        {
            if (i > qtd) return notas;

            Console.WriteLine($"Digite a {i}º nota do aluno");
            var nota = Convert.ToInt16(Console.ReadLine());
            notas.Add(nota);

            return preencheNotasAluno(i + 1, qtd, notas);
        }
    }
}
