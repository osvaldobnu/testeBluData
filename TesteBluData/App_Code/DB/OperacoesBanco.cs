using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de OperacoesBanco
/// </summary>
public class OperacoesBanco
{
    public OperacoesBanco()
    {

    }

    public string PegaNomeEmpresa(string idEmpresa)
    {
        string ufEmpresa = "";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EMPRESA WHERE ID_EMPRESA = " + idEmpresa;

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ufEmpresa = dr["nome_fantasia"].ToString();
                }
            }
            conn.Close();
        }

        return ufEmpresa;
    }

    public string PegaUfEmpresa(string idEmpresa)
    {
        string ufEmpresa = "";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EMPRESA WHERE ID_EMPRESA = " + idEmpresa;

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ufEmpresa = dr["uf"].ToString();
                }
            }
            conn.Close();
        }

        return ufEmpresa;
    }

    public void SalvaEmpresa(string uf, string nomeFantasia, string cnpj)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO empresa (uf, nome_fantasia, cnpj) VALUES (@uf, @nomeFantasia, @cnpj)";

                cmd.Parameters.Add("uf", SqlDbType.NVarChar).Value = uf;
                cmd.Parameters.Add("nomeFantasia", SqlDbType.NVarChar).Value = nomeFantasia;
                cmd.Parameters.Add("cnpj", SqlDbType.NVarChar).Value = cnpj;

                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }

    public void SalvaFornecedorPessoaJuridica(string idempresa, string nome, string cpfCnpj, string telefone)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO fornecedor (id_empresa, nome, cpf_cnpj, telefone, data_cadastro) VALUES (@id_empresa, @nome, @cpf_cnpj, @telefone, @data_cadastro)";

                cmd.Parameters.Add("id_empresa", SqlDbType.NVarChar).Value = idempresa;
                cmd.Parameters.Add("nome", SqlDbType.NVarChar).Value = nome;
                cmd.Parameters.Add("cpf_cnpj", SqlDbType.NVarChar).Value = cpfCnpj;
                cmd.Parameters.Add("telefone", SqlDbType.NVarChar).Value = telefone;
                cmd.Parameters.Add("data_cadastro", SqlDbType.NVarChar).Value = DateTime.Now;

                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }

    public void SalvaFornecedorPessoaFisica(string idempresa, string nome, string cpfCnpj, string telefone, string data_cadastro, string rg)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO fornecedor (id_empresa, nome, cpf_cnpj, telefone, data_cadastro, data_nascimento, rg) 
                                    VALUES (@id_empresa, @nome, @cpf_cnpj, @telefone, @data_cadastro, @data_nascimento, @rg)";

                cmd.Parameters.Add("id_empresa", SqlDbType.NVarChar).Value = idempresa;
                cmd.Parameters.Add("nome", SqlDbType.NVarChar).Value = nome;
                cmd.Parameters.Add("cpf_cnpj", SqlDbType.NVarChar).Value = cpfCnpj;
                cmd.Parameters.Add("telefone", SqlDbType.NVarChar).Value = telefone;
                cmd.Parameters.Add("data_cadastro", SqlDbType.NVarChar).Value = DateTime.Now;
                cmd.Parameters.Add("data_nascimento", SqlDbType.NVarChar).Value = data_cadastro;
                cmd.Parameters.Add("rg", SqlDbType.NVarChar).Value = rg;

                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}