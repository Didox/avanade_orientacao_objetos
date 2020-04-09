using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Mercearia
{
    class ProdutoSql
    {

        /// <summary>
        /// Este é o nome do produto
        /// </summary>
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Id { get; set; }
        public int Quantidade { get; set; }

        private static string connectionString = "Server=localhost;Database=avanade_aula;Uid=sa;Pwd=!1#2a3d4c5g6v";

        public void Salvar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var queryString = "insert into produtos (Nome, Preco, Quantidade) values('" + this.Nome + "'," + this.Preco + "," + this.Quantidade + ");";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Remover()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand Command = new SqlCommand("DELETE FROM produtos WHERE id=@id", connection);
                Command.Parameters.AddWithValue("@id", this.Id);
                connection.Open();
                Command.ExecuteNonQuery();
                connection.Close();
            }
        }


        public static List<ProdutoSql> ListaProdutos(int id=0)
        {
            var produtos = new List<ProdutoSql>();
            using (var _connection = new SqlConnection(connectionString))
            {
                _connection.Open();

                var query = "SELECT * from produtos";
                if(id > 0)
                {
                    query += " where id = " + id;
                }
                using (SqlCommand command = new SqlCommand(query, _connection))
                {

                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            var produto = new ProdutoSql();
                            produto.Id = Convert.ToInt32(sqlDataReader["Id"]);
                            produto.Nome = sqlDataReader["Nome"].ToString();
                            produto.Preco = Convert.ToDouble(sqlDataReader["Preco"]);
                            produto.Quantidade = Convert.ToInt32(sqlDataReader["Quantidade"]);

                            produtos.Add(produto);
                        }
                    }
                    sqlDataReader.Close();
                }
                _connection.Close();
                return produtos;
            }
        }

        public static ProdutoSql BuscaPorId(int id)
        {
            var lista = ProdutoSql.ListaProdutos(id);
            if(lista.Count > 0) return lista[0];
            return null;
        }
    }


}