<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="CadEmpresa.aspx.cs" Inherits="Paginas_Empresa_CadEmpresa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Cadastro de Empresa</h2>
    
    <form>
      <div class="form-group">
        <asp:Label runat="server">UF</asp:Label>
        <asp:TextBox CssClass="form-control" runat="server" id="ufCampo" placeholder="Exemplo: SC"></asp:TextBox>
      </div>
      <div class="form-group">
        <asp:Label runat="server">Nome Fantasia</asp:Label>
        <asp:TextBox CssClass="form-control" runat="server" id="nomeFantasiaCampo" placeholder="Exemplo: Nome Fantasia"></asp:TextBox>
      </div>
      <div class="form-group">
        <asp:Label runat="server">CNPJ</asp:Label>
        <asp:TextBox CssClass="form-control" runat="server" id="cnpjCampo" placeholder="Exemplo: 00.000/0000-10"></asp:TextBox>
      </div>
      <asp:Button id="btnSalvar" CssClass="btn btn-primary" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    </form>
</asp:Content>
