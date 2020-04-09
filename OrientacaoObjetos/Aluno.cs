using System;
using System.Collections.Generic;

namespace LogicaAvanade
{
    namespace OrientacaoObjetos
    {
        public class Aluno
        {
            public Aluno()
            {
                this.Notas = new List<int>();
            }

            public string Nome { get; set; }
            public string Matricula { get; set; }
            public List<int> Notas { get; set; }

            public int Media()
            {
                int somaNotas = 0;
                foreach (var nota in this.Notas)
                {
                    somaNotas += nota;
                }
                return somaNotas / this.Notas.Count;
            }

        }
    }
}
