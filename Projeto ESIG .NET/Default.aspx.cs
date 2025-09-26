using Projeto_ESIG.NET.Repository;
using Projeto_ESIG.NET.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_ESIG.NET
{
    public partial class Default : Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["PEConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CarregarSalarios();
        }

        private void CarregarSalarios()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT pessoa_id, pessoa_nome, cargo_nome, salario FROM dbo.pessoa_salario", con))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                gvPessoaSalario.DataSource = dt;
                gvPessoaSalario.DataBind();
            }
        }

        protected void btnRecalcular_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_atualizar_pessoa_salario", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            CarregarSalarios();
        }

        protected void gvPessoaSalario_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPessoaSalario.EditIndex = e.NewEditIndex;
            CarregarSalarios();

            DropDownList ddlCargos = (DropDownList)gvPessoaSalario.Rows[e.NewEditIndex].FindControl("ddlCargos");

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT CargoId, CargoNome FROM Cargo", con))
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                ddlCargos.DataSource = rdr;
                ddlCargos.DataTextField = "CargoNome";
                ddlCargos.DataValueField = "CargoId";
                ddlCargos.DataBind();
            }
        }

        protected void gvPessoaSalario_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPessoaSalario.EditIndex = -1;
            CarregarSalarios();
        }

        protected void gvPessoaSalario_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int pessoaId = Convert.ToInt32(gvPessoaSalario.DataKeys[e.RowIndex].Value);
            DropDownList ddlCargos = (DropDownList)gvPessoaSalario.Rows[e.RowIndex].FindControl("ddlCargos");
            int novoCargoId = int.Parse(ddlCargos.SelectedValue);

            PessoaRepository repo = new PessoaRepository();
            repo.UpdateCargo(pessoaId, novoCargoId);

            gvPessoaSalario.EditIndex = -1;
            CarregarSalarios();
        }

        protected void gvPessoaSalario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int pessoaId = Convert.ToInt32(gvPessoaSalario.DataKeys[e.RowIndex].Value);

            PessoaRepository repo = new PessoaRepository();
            repo.Delete(pessoaId);

            CarregarSalarios();
        }
    }
}
