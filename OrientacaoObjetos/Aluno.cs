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

            
            /*private string nome2;

            public string Nome {
                get
                {
                    return this.nome2.ToUpper();
                }
                set
                {
                    this.nome2 = value;
                }
            }*/
            

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
