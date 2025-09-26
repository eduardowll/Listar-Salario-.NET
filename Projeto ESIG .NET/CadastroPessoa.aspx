<%@ Page Title="Cadastro de Pessoas" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="CadastroPessoa.aspx.cs" 
    Inherits="Projeto_ESIG.NET.CadastroPessoa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Cadastro de Pessoa</h2>
    <hr />

    <div class="form-group">
        <label>Nome:</label>
        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Cidade:</label>
        <asp:TextBox ID="txtCidade" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>CEP:</label>
        <asp:TextBox ID="txtCEP" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Endereço:</label>
        <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>País:</label>
        <asp:TextBox ID="txtPais" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Usuário:</label>
        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Telefone:</label>
        <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Data de Nascimento (MM/DD/YYYY):</label>
        <asp:TextBox ID="txtData" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Cargo ID:</label>
        <asp:TextBox ID="txtCargoId" runat="server" CssClass="form-control" />
    </div>

    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="btnSalvar_Click" />
</asp:Content>
