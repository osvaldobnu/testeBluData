using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Paginas_Empresa_CadEmpresa : System.Web.UI.Page
{
    OperacoesBanco operacoes = new OperacoesBanco();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        string uf = ufCampo.Text;
        string nomeFantasia = nomeFantasiaCampo.Text;
        string cnpj = cnpjCampo.Text;

        operacoes.SalvaEmpresa(uf, nomeFantasia, cnpj);

        Server.Transfer("ListaEmpresa.aspx");
    }
}