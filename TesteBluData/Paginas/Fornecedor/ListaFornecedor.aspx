<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="ListaFornecedor.aspx.cs" Inherits="Paginas_Fornecedor_ListaFornecedor" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <a href="CadFornecedor.aspx" class="btn btn-primary" role="button">Novo</a>
    <div class="row">
        <h2>Filtros</h2>
        <div class="col-md-4">
            <asp:Label runat="server">Nome</asp:Label>
            <asp:TextBox CssClass="form-control" runat="server" id="nomeCampo"></asp:TextBox>
            
            <br />
        </div>
        <div class="col-md-4">
            <asp:Label runat="server">CPF/CNPJ</asp:Label>
            <asp:TextBox CssClass="form-control" runat="server" id="cpfCnpjCampo"></asp:TextBox>
            
            <br />
        </div>
        <div class="col-md-4">
            <asp:Label runat="server">Data de Nascimento</asp:Label>
            <asp:TextBox CssClass="form-control" runat="server" id="dataNascimentoCampo"></asp:TextBox>
            <ajaxtoolkit:maskededitextender ID="MaskedEditExtender5" runat="server"
                TargetControlID="dataNascimentoCampo"
                Mask="99/99/9999"
                MessageValidatorTip="true"
                OnFocusCssClass="MaskedEditFocus"
                OnInvalidCssClass="MaskedEditError"
                MaskType="Date"
                DisplayMoney="Left"
                AcceptNegative="Left"
                ErrorTooltipEnabled="True"/>
            <br />
        </div>
        <div class="col-md-1">
            <asp:Button id="btnFiltra" CssClass="btn btn-info" runat="server" Text="Filtrar" OnClick="btnFiltra_Click" /><br /><br />
        </div>
        <div class="col-md-1">
            <asp:Button id="btnLimpaFiltro" CssClass="btn btn-info" runat="server" Text="Limpar Filtro" OnClick="btnLimpaFiltro_Click" /><br /><br />
        </div>
        <div class="col-md-12">
            <asp:GridView ID="gridFornecedor" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True"
                CssClass="table table-responsive table-striped table-hover" AllowSorting="True" OnRowDataBound="gridFornecedor_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="id_fornecedor" HeaderText="id_fornecedor" InsertVisible="False" ReadOnly="True" SortExpression="id_fornecedor" Visible="False" />
                    <asp:BoundField DataField="id_empresa" HeaderText="Empresa" SortExpression="id_empresa" />
                    <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome" />
                    <asp:BoundField DataField="cpf_cnpj" HeaderText="CPF/CNPJ" SortExpression="cpf_cnpj" />
                    <asp:BoundField DataField="telefone" HeaderText="Telefone" SortExpression="telefone" />
                    <asp:BoundField DataField="data_cadastro" HeaderText="Data Cadastrado" SortExpression="data_cadastro" />
                    <asp:BoundField DataField="data_nascimento" HeaderText="Data de Nascimento" SortExpression="data_nascimento" />
                    <asp:BoundField DataField="rg" HeaderText="rg" SortExpression="rg" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConexaoSqlServer %>" SelectCommand="SELECT * FROM [fornecedor]" ></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
