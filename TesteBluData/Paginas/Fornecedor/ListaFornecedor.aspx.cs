using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Fornecedor_ListaFornecedor : System.Web.UI.Page
{
    OperacoesBanco operacoes = new OperacoesBanco();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnFiltra_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;

                string query = "SELECT * FROM FORNECEDOR WHERE 1 = 1";

                if (nomeCampo.Text != "" || cpfCnpjCampo.Text != "" || dataNascimentoCampo.Text != "")
                {

                    if (nomeCampo.Text != "")
                    {
                        query += " AND NOME LIKE'%" + nomeCampo.Text + "%'";
                    }

                    if (cpfCnpjCampo.Text != "")
                    {
                        query += " AND CPF_CNPJ = '" + cpfCnpjCampo.Text + "'";
                    }

                    if (dataNascimentoCampo.Text != "")
                    {
                        query += " AND DATA_NASCIMENTO ='" + dataNascimentoCampo.Text + "'";
                    }
                }

                cmd.CommandText = query;
                conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();



                sda.Fill(ds);

                gridFornecedor.DataSourceID = null;

                gridFornecedor.DataSource = ds;
                gridFornecedor.DataBind();

                conn.Close();
            }
        }
    }

    protected void btnLimpaFiltro_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;

                string query = "SELECT * FROM FORNECEDOR WHERE 1 = 1";

                cmd.CommandText = query;
                conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();



                sda.Fill(ds);

                gridFornecedor.DataSourceID = null;

                gridFornecedor.DataSource = ds;
                gridFornecedor.DataBind();

                conn.Close();
            }
        }
    }

    protected void gridFornecedor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Text = operacoes.PegaNomeEmpresa(e.Row.Cells[1].Text);
        }
    }
}