<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="CadFornecedor.aspx.cs" Inherits="Paginas_Fornecedor_CadFornecedor" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Cadastro de Fornecedor</h2>

    <form>
        <div class="form-group">
            <asp:Label runat="server">Empresa</asp:Label><br />
            <asp:DropDownList CssClass="selectpicker" ID="dropEmpresaCampo" runat="server">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label runat="server">Nome</asp:Label><br />
            <asp:TextBox CssClass="form-control" runat="server" ID="nomeCampo" placeholder="Exemplo: Osvaldo"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server">CPF OU CNPJ</asp:Label><br />
            <asp:TextBox CssClass="form-control" runat="server" ID="cpfCnpjCampo" placeholder="Digite CPF ou CNPJ" onchange="javascript: verificaTipoPessoa(this.value);"></asp:TextBox>
        </div>
        <div id="divRG" class="form-group" hidden>
            <asp:Label Visible="true" ID="lbRG" runat="server">RG</asp:Label><br />
            <asp:TextBox Visible="true" ID="rgCampo" CssClass="form-control" runat="server" placeholder="Digite RG"></asp:TextBox>
        </div>
        <div id="divDataNasci" class="form-group" hidden>
            <asp:Label Visible="true" ID="lbDataNasci" runat="server">Data Nascimento</asp:Label><br />
            <asp:TextBox Visible="true" ID="dataNasciCampo" CssClass="form-control" runat="server" placeholder="Digite Data de Nascimento"></asp:TextBox>
            <ajaxtoolkit:maskededitextender ID="MaskedEditExtender5" runat="server"
                TargetControlID="dataNasciCampo"
                Mask="99/99/9999"
                MessageValidatorTip="true"
                OnFocusCssClass="MaskedEditFocus"
                OnInvalidCssClass="MaskedEditError"
                MaskType="Date"
                DisplayMoney="Left"
                AcceptNegative="Left"
                ErrorTooltipEnabled="True"/>
        </div>
        <div class="form-group">
            <asp:Label runat="server">Telefone(s)</asp:Label><br />
            <asp:TextBox CssClass="form-control" runat="server" ID="telefoneCampo" placeholder="Exemplo: 47 9 9695-3207"></asp:TextBox>
        </div>
        <asp:Button ID="btnSalvar" CssClass="btn btn-primary" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    </form>

    <script type="text/javascript">

        function getUrlParam(parameter, defaultvalue){
            var urlparameter = defaultvalue;
            if(window.location.href.indexOf(parameter) > -1){
                urlparameter = getUrlVars()[parameter];
                }
            alert(urlparameter);
        }

        function verificaTipoPessoa(campo) {
            if (campo.length == 11) {
                document.getElementById("divRG").removeAttribute("hidden");
                document.getElementById("divDataNasci").removeAttribute("hidden");
            } else if (campo.length == 14) {
                document.getElementById("divRG").setAttribute("hidden", "");
                document.getElementById("divDataNasci").setAttribute("hidden","");
            } else {
                alert('Informe um cnpj ou cpf válido');
            }
        }
    </script>
</asp:Content>
