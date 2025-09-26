using Projeto_ESIG.NET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Projeto_ESIG.NET.Repository
{
    public class PessoaRepository
    {
        private string connString = ConfigurationManager.ConnectionStrings["PEConnectionString"].ConnectionString;

        public List<Pessoa> GetAll()
        {
            var pessoas = new List<Pessoa>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM Pessoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pessoas.Add(new Pessoa
                    {
                        PessoaId = (int)reader["PessoaId"],
                        PessoaNome = reader["PessoaNome"].ToString(),
                        Cidade = reader["Cidade"].ToString(),
                        Email = reader["Email"].ToString(),
                        CEP = reader["CEP"].ToString(),
                        Endereco = reader["Endereco"].ToString(),
                        Pais = reader["Pais"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                        Telefone = reader["Telefone"].ToString(),
                        Data_Nascimento = reader["Data_Nascimento"].ToString(),
                        CargoId = (int)reader["CargoId"]
                    });
                }
            }

            return pessoas;
        }

        public void Add(Pessoa p)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                // Buscar próximo ID
                SqlCommand getIdCmd = new SqlCommand("SELECT ISNULL(MAX(PessoaId), 0) + 1 FROM Pessoa", conn);
                int novoId = (int)getIdCmd.ExecuteScalar();

                string query = @"
                    INSERT INTO Pessoa(PessoaId, PessoaNome, Cidade, Email, CEP, Endereco, Pais, Usuario, Telefone, Data_Nascimento, CargoId)
                    VALUES(@PessoaId, @PessoaNome, @Cidade, @Email, @CEP, @Endereco, @Pais, @Usuario, @Telefone, @DataNascimento, @CargoId)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PessoaId", novoId);
                cmd.Parameters.AddWithValue("@PessoaNome", p.PessoaNome);
                cmd.Parameters.AddWithValue("@Cidade", p.Cidade);
                cmd.Parameters.AddWithValue("@Email", p.Email);
                cmd.Parameters.AddWithValue("@CEP", p.CEP);
                cmd.Parameters.AddWithValue("@Endereco", p.Endereco);
                cmd.Parameters.AddWithValue("@Pais", p.Pais);
                cmd.Parameters.AddWithValue("@Usuario", p.Usuario);
                cmd.Parameters.AddWithValue("@Telefone", p.Telefone);
                cmd.Parameters.AddWithValue("@DataNascimento", p.Data_Nascimento);
                cmd.Parameters.AddWithValue("@CargoId", p.CargoId);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCargo(int pessoaId, int novoCargoId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = @"UPDATE Pessoa 
                         SET CargoId = @CargoId
                         WHERE PessoaId = @PessoaId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PessoaId", pessoaId);
                cmd.Parameters.AddWithValue("@CargoId", novoCargoId);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int pessoaId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "DELETE FROM Pessoa WHERE PessoaId=@PessoaId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PessoaId", pessoaId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
