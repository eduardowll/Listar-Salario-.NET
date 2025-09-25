<%@ Page Title="Página Inicial" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Projeto_ESIG.NET.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Listagem de Salários</h1>
        <p class="lead">Exibe os salários de funcionários e permite o recálculo.</p>
    </div>

    <div class="row">
        <div class="col-md-12" style="margin-bottom: 20px;">
            <asp:Button ID="btnRecalcular" runat="server" Text="Calcular/Recalcular Salários" OnClick="btnRecalcular_Click" CssClass="btn btn-primary btn-lg" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gvPessoaSalario" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped" EmptyDataText="Nenhum registro de salário encontrado. Clique em 'Calcular' para popular os dados.">
                <Columns>
                    <asp:BoundField DataField="pessoa_id" HeaderText="ID" />
                    <asp:BoundField DataField="pessoa_nome" HeaderText="Nome da Pessoa" />
                    <asp:BoundField DataField="cargo_nome" HeaderText="Cargo" />
                    <asp:BoundField DataField="salario" HeaderText="Salário" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
