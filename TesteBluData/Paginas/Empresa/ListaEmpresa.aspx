<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="ListaEmpresa.aspx.cs" Inherits="Paginas_Empresa_ListaEmpresa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <a href="CadEmpresa.aspx" class="btn btn-primary" role="button">Novo</a>
    <br /><br />
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gridEmpresa" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True"
                CssClass="table table-responsive table-striped table-hover">
                <Columns>
                    <asp:BoundField DataField="id_empresa" HeaderText="id_empresa" InsertVisible="False" ReadOnly="True" SortExpression="id_empresa" Visible="False" />
                    <asp:BoundField DataField="uf" HeaderText="UF" SortExpression="uf" />
                    <asp:BoundField DataField="nome_fantasia" HeaderText="Nome" SortExpression="nome_fantasia" />
                    <asp:BoundField DataField="cnpj" HeaderText="CNPJ" SortExpression="cnpj" />
                </Columns>

            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoSqlServer %>" SelectCommand="SELECT [id_empresa], [uf], [nome_fantasia], [cnpj] FROM [empresa]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
