using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

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
    }
}
