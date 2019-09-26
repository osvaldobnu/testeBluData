using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Fornecedor_CadFornecedor : System.Web.UI.Page
{
    OperacoesBanco operacoes = new OperacoesBanco();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["erro"] != null)
        {

        }

        if (!IsPostBack)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM EMPRESA";

                    SqlDataAdapter adpt = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    dropEmpresaCampo.DataSource = dt;
                    dropEmpresaCampo.DataBind();
                    dropEmpresaCampo.DataTextField = "nome_fantasia";
                    dropEmpresaCampo.DataValueField = "id_empresa";
                    dropEmpresaCampo.DataBind();
                }
                conn.Close();
            }
        }
    }

    protected int CalculaIdade(string dataNascimento)
    {
        int idade = 0;
        int anoNascimento = Convert.ToDateTime(dataNascimento).Year;
        int mesNascimento = Convert.ToDateTime(dataNascimento).Month;
        int diaNascimento = Convert.ToDateTime(dataNascimento).Day;

        var DNascimento = new DateTime(anoNascimento, mesNascimento, diaNascimento);
        var hoje = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        idade = hoje.Year - DNascimento.Year;

        return idade;
    }

    protected bool ValidaIdade(string idEmpresa)
    {
        int idade = 0;
        string uf = operacoes.PegaUfEmpresa(idEmpresa);

        if (uf.ToUpper() == "PR")
        {
            idade = CalculaIdade(dataNasciCampo.Text);
        }

        if (idade >= 18)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        string empresa = dropEmpresaCampo.SelectedItem.Value;
        string nome = nomeCampo.Text;
        string cpfCnpj = cpfCnpjCampo.Text;
        string telefone = telefoneCampo.Text;

        // Caso for pessoa fisica
        string rg = rgCampo.Text;
        string dataNascimento = dataNasciCampo.Text;

        // Cadastra pessoa Juridica
        if (cpfCnpj.Length == 14)
        {
            operacoes.SalvaFornecedorPessoaJuridica(empresa, nome, cpfCnpj, telefone);
            Server.Transfer("ListaFornecedor.aspx");

        }
        else // Cadastra pessoa Fisica
        {
            bool maiorDeIdade = ValidaIdade(empresa.ToString());

            if (maiorDeIdade)
            {
                operacoes.SalvaFornecedorPessoaFisica(empresa, nome, cpfCnpj, telefone, dataNascimento, rg);
                Server.Transfer("ListaFornecedor.aspx");
            }
            else
            {
                Response.Write("<script>alert('Empresas do Paraná não podem cadastrar Fornecedores menor de idade!')</script>");
                Server.Transfer("ListaFornecedor.aspx");
            }
        }
    }
}