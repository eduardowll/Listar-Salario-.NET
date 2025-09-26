using Projeto_ESIG.NET.Repository;
using Projeto_ESIG.NET.Models;
using System;

namespace Projeto_ESIG.NET
{
    public partial class CadastroPessoa : System.Web.UI.Page
    {
        PessoaRepository repo = new PessoaRepository();

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa
            {
                PessoaNome = txtNome.Text,
                Cidade = txtCidade.Text,
                Email = txtEmail.Text,
                Data_Nascimento = txtData.Text,
                CargoId = int.Parse(txtCargoId.Text),
                CEP = "",
                Endereco = "",
                Pais = "",
                Usuario = "",
                Telefone = ""
            };

            repo.Add(p);
            Response.Redirect("Default.aspx");
        }
    }
}