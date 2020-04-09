using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mercearia
{
    class Produto
    {

        /// <summary>
        /// Este é o nome do produto
        /// </summary>
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Id { get; set; }
        public int Quantidade { get; set; }

        public void Salvar()
        {
            Produto.produtos.Add(this);
            salvarArquivo();
        }

        private void salvarArquivo()
        {
            var caminho = "db.csv";
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                writer.WriteLine("Id;Nome;Preco;Quantidade;");

                foreach (var produto in Produto.produtos)
                {
                    writer.WriteLine($"{produto.Id};{produto.Nome};{produto.Preco};{produto.Quantidade}");
                }
            }
        }

        public void Remover()
        {
            Produto.produtos.Remove(this);
            salvarArquivo();
        }



        public static List<Produto> produtos = new List<Produto>();

        public static List<Produto> ListaProdutos()
        {
            produtos = new List<Produto>();

            var caminho = "db.csv";
            if (File.Exists(caminho))
            {
                using (StreamReader reader = new StreamReader(caminho))
                {
                    while (reader.Peek() >= 0)
                    {
                        var linha = reader.ReadLine();
                        var colunas = linha.Split(';');
                        if (colunas[0] == "Id")
                        {
                            continue;
                        }

                        var produto = new Produto();
                        produto.Id = Convert.ToInt32(colunas[0]);
                        produto.Nome = colunas[1];
                        produto.Preco = Convert.ToDouble(colunas[2]);
                        produto.Quantidade = Convert.ToInt32(colunas[3]);

                        produtos.Add(produto);
                    }
                }
            }

            return Produto.produtos;
        }

        public static Produto BuscaPorId(int id)
        {
            foreach (var item in Produto.ListaProdutos())
            {
                if (id == item.Id)
                {
                    return item;
                }

            }

            return null;
        }
    }


}